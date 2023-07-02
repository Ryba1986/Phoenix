using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClosedXML.Excel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Reports.Queries;
using Phoenix.Services.Extensions;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Reports.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Enums.Devices;
using Phoenix.Shared.Enums.Reports;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Reports.Queries
{
   internal sealed class GetReportHandler : QueryHandlerBase, IRequestHandler<GetReportQuery, FileResult>
   {
      private readonly IIndex<PlcType, IPlcProcessor> _plcProcessors;
      private readonly IIndex<ReportType, ITypeProcessor> _typeProcessors;

      public GetReportHandler(UnitOfWork uow, IMapper mapper, IIndex<PlcType, IPlcProcessor> plcProcessors, IIndex<ReportType, ITypeProcessor> typeProcessors) : base(uow, mapper)
      {
         _plcProcessors = plcProcessors;
         _typeProcessors = typeProcessors;
      }

      public async Task<FileResult> Handle(GetReportQuery request, CancellationToken cancellationToken)
      {
         ITypeProcessor typeProcessor = _typeProcessors[request.Type];
         using IXLWorkbook workbook = ExcelExtensions.GetReportTemplate();

         IReadOnlyCollection<string> templateSheetNames = workbook.Worksheets
            .GetSheetNames()
            .ToArray();

         await CreateSheetsAsync(workbook.Worksheets, request, typeProcessor, cancellationToken);
         workbook.Worksheets.RemoveSheets(templateSheetNames);

         using MemoryStream ms = new();
         workbook.SaveAs(ms);

         return new()
         {
            Name = typeProcessor.GetFileName(request.Date),
            Type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            Data = ms.ToArray(),
         };
      }

      private async Task CreateSheetsAsync(IXLWorksheets sheets, GetReportQuery request, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
      {
         IReadOnlyCollection<DeviceReportDto> devices = await _uow.Device
            .AsNoTracking()
            .Include(x => x.Location)
            .Where(x =>
               x.IncludeReport &&
               x.Location.IncludeReport
            )
            .OrderBy(x => x.Name)
            .ProjectTo<DeviceReportDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);

         if (devices.Count == 0)
         {
            return;
         }

         IReadOnlyCollection<string> locations = devices
            .GroupBy(x => x.LocationName)
            .OrderBy(x => x.Key)
            .Select(x => x.Key)
            .ToArray();

         foreach (string location in locations)
         {
            IXLWorksheet sheet = sheets.CloneSheet(request.Type, location);

            sheet.SheetView.ZoomScale = 70;
            sheet.Cell(1, 1).Value = typeProcessor.GetHeader(location, request.Date);
         }
      }
   }
}
