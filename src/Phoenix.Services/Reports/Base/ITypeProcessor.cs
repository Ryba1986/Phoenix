using System;
using System.Linq.Expressions;
using Phoenix.Entities.Base;
using Phoenix.Models.Utilities;
using Phoenix.Shared.Enums.Reports;

namespace Phoenix.Services.Reports.Base
{
   internal interface ITypeProcessor
   {
      StartingPoints StartingPoints { get; init; }
      short SummaryRowOffset { get; init; }
      ReportType Type { get; init; }

      int GetDatePart(DateTime date);
      string GetFileName(DateOnly date);
      string GetHeader(string locationName, DateOnly date);
      Expression<Func<T, PlcGroupBy>> GetPlcGroup<T>() where T : PlcBase;
      DateRange GetRange(DateOnly date);
   }
}
