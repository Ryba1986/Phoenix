using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using AutoMapper;
using MediatR;
using OfficeOpenXml;
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

         ep.Workbook.Worksheets.RemoveTemplateRows(typeProcessor.RemoveTemplateRowCount);
         ep.Workbook.Worksheets.RemoveSheets(templateSheetNames);

         return new()
         {
            Name = typeProcessor.GetFileName(request.Date),
            Type = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            Data = ep.GetAsByteArray(),
         };
      }
   }
}
