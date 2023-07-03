using System;
using System.Linq.Expressions;
using Phoenix.Entities.Base;
using Phoenix.Models.Utilities;
using Phoenix.Services.Reports.Base;
using Phoenix.Shared.Enums.Reports;
using Phoenix.Shared.Languages;

namespace Phoenix.Services.Reports.Types
{
   internal sealed class MonthTypeProcessor : ITypeProcessor
   {
      public StartingPoints StartingPoints { get; init; }
      public short SummaryRowOffset { get; init; }
      public ReportType Type { get; init; }

      public MonthTypeProcessor()
      {

         SummaryRowOffset = 31;

         StartingPoints = new()
         {
            MeterColumn = 35,
            PlcColumn = 2,
            Row = 8
         };

         Type = ReportType.Month;
      }

      public int GetDatePart(DateTime date)
      {
         return date.Day - 1;
      }

      public string GetFileName(DateOnly date)
      {
         return $"{Translations.Report_FileName}_{date:yyyy-MM}.xlsx";
      }

      public string GetHeader(string locationName, DateOnly date)
      {
         return string.Format(Translations.Report_Header_Month, locationName, date.ToString("yyyy-MM"));
      }

      public Expression<Func<T, PlcGroupBy>> GetPlcGroup<T>() where T : PlcBase
      {
         return x => new()
         {
            DatePart = x.Date.Day,
            DeviceId = x.DeviceId,
         };
      }


      public DateRange GetRange(DateOnly date)
      {
         DateTime dateTime = new(date.Year, date.Month, 1);

         return new()
         {
            Start = dateTime,
            End = dateTime.AddMonths(1),
         };
      }
   }
}