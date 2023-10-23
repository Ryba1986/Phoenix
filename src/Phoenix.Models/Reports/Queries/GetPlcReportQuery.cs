using System;
using MediatR;
using Phoenix.Shared.Enums.Reports;
using Phoenix.Shared.Results;

namespace Phoenix.Models.Reports.Queries
{
   public sealed class GetPlcReportQuery : IRequest<FileResult>
   {
      public DateOnly Date { get; init; }
      public PlcReportType Type { get; init; }

      public GetPlcReportQuery()
      {
         Date = DateOnly.MinValue;
         Type = PlcReportType.Day;
      }
   }
}
