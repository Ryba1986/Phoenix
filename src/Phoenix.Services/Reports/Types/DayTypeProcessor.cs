using System;
using System.Linq.Expressions;
using Phoenix.Entities.Base;
using Phoenix.Models.Utilities;
using Phoenix.Services.Reports.Base;
using Phoenix.Shared.Enums.Reports;
using Phoenix.Shared.Languages;

namespace Phoenix.Services.Reports.Types
{
   internal sealed class DayTypeProcessor : ITypeProcessor
   {
      public StartingPoints StartingPoints { get; init; }
      public short SummaryRowOffset { get; init; }
      public ReportType Type { get; init; }

      public DayTypeProcessor()
      {

         SummaryRowOffset = 24;

         StartingPoints = new()
         {
            MeterColumn = 35,
            PlcColumn = 2,
            Row = 8
         };

         Type = ReportType.Day;
      }

      public int GetDatePart(DateTime date)
      {
         return date.Hour;
      }

      public string GetFileName(DateOnly date)
      {
         return $"{Translations.Report_FileName}_{date:yyyy-MM-dd}.xlsx";
      }

      public string GetHeader(string locationName, DateOnly date)
      {
         return string.Format(Translations.Report_Header_Day, locationName, date.ToString("yyyy-MM-dd"));
      }

      public Expression<Func<T, PlcGroupBy>> GetPlcGroup<T>() where T : PlcBase
      {
         return x => new()
         {
            DatePart = x.Date.Hour,
            DeviceId = x.DeviceId,
         };
      }

      public DateRange GetRange(DateOnly date)
      {
         DateTime dateTime = date.ToDateTime(TimeOnly.MinValue);

         return new()
         {
            Start = dateTime,
            End = dateTime.AddDays(1),
         };
      }
   }
}