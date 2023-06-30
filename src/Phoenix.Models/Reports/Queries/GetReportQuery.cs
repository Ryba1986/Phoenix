using System;
using MediatR;
using Phoenix.Shared.Enums.Reports;
using Phoenix.Shared.Results;

namespace Phoenix.Models.Reports.Queries
{
   public sealed class GetReportQuery : IRequest<FileResult>
   {
      public DateOnly Date { get; init; }
      public ReportType Type { get; init; }

      public GetReportQuery()
      {
         Date = DateOnly.MinValue;
         Type = ReportType.Day;
      }
   }
}
