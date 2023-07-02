using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
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
         using ExcelPackage ep = ExcelExtensions.GetReportTemplate();

         IReadOnlyCollection<string> templateSheetNames = ep.Workbook.Worksheets
            .GetSheetNames()
            .ToArray();

         await CreateSheetsAsync(ep.Workbook.Worksheets, request, typeProcessor, cancellationToken);
         ep.Workbook.Worksheets.RemoveSheets(templateSheetNames);

         return new()
         {
            Name = typeProcessor.GetFileName(request.Date),
            Type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            Data = ep.GetAsByteArray(),
         };
      }

      private async Task CreateSheetsAsync(ExcelWorksheets sheets, GetReportQuery request, ITypeProcessor typeProcessor, CancellationToken cancellationToken)
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
            ExcelWorksheet sheet = sheets.CloneSheet(request.Type, location);

            sheet.View.ZoomScale = 70;
            sheet.Cells[1, 1].Value = typeProcessor.GetHeader(location, request.Date);
         }

         IReadOnlyCollection<Task> plcTasks = devices
            .GroupBy(x => x.PlcType)
            .Select(x => _plcProcessors[x.Key].FillDataAsync(sheets, request.Date, x.ToArray(), typeProcessor, cancellationToken))
            .ToArray();

         await Task.WhenAll(plcTasks);
      }
   }
}
