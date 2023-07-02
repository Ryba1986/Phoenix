using System;
using System.Linq.Expressions;
using Phoenix.Entities.Base;
using Phoenix.Models.Utilities;
using Phoenix.Services.Reports.Base;
using Phoenix.Shared.Enums.Reports;
using Phoenix.Shared.Languages;

namespace Phoenix.Services.Reports.Types
{
   internal sealed class YearTypeProcessor : ITypeProcessor
   {
      public StartingPoints StartingPoints { get; init; }
      public short SummaryRowOffset { get; init; }
      public ReportType Type { get; init; }

      public YearTypeProcessor()
      {
         SummaryRowOffset = 12;

         StartingPoints = new()
         {
            MeterColumn = 35,
            PlcColumn = 2,
            Row = 8
         };

         Type = ReportType.Year;
      }

      public int GetDatePart(DateTime date)
      {
         return date.Month - 1;
      }

      public string GetFileName(DateOnly date)
      {
         return $"{Translations.Report_FileName}_{date:yyyy}.xlsx";
      }

      public string GetHeader(string locationName, DateOnly date)
      {
         return string.Format(Translations.Report_Header_Year, locationName, date.ToString("yyyy"));
      }

      public Expression<Func<T, PlcGroupBy>> GetPlcGroup<T>() where T : PlcBase
      {
         return x => new()
         {
            DatePart = x.Date.Month,
            DeviceId = x.DeviceId,
         };
      }

      public DateRange GetRange(DateOnly date)
      {
         DateTime dateTime = new(date.Year, 1, 1);

         return new()
         {
            Start = dateTime,
            End = dateTime.AddYears(1),
         };
      }
   }
}
