using System;
using System.Linq.Expressions;
using Phoenix.Entities.Base;
using Phoenix.Models.Utilities;
using Phoenix.Services.Reports.Base;
using Phoenix.Shared.Enums.Reports;
using Phoenix.Shared.Languages;

namespace Phoenix.Services.Reports.Types
{
   public class YearByDayProcessor : ITypeProcessor
   {
      public ushort RemoveTemplateRowCount { get; init; }
      public ushort StartingRow { get; init; }
      public ReportType Type { get; init; }

      public YearByDayProcessor()
      {
         RemoveTemplateRowCount = 0;
         StartingRow = 6;
         Type = ReportType.YearByDay;
      }

      public int GetDatePart(DateTime date)
      {
         return date.DayOfYear - 1;
      }

      public string GetFileName(DateOnly date)
      {
         return $"{Translations.Report_FileName}_{date:yyyy}_365.xlsx";
      }

      public string GetHeader(string locationName, DateOnly date)
      {
         return string.Format(Translations.Report_Header_YearByDay, locationName, date.ToString("yyyy"));
      }

      public string GetLegend()
      {
         return Translations.Report_Legend_YearByDay;
      }

      public Expression<Func<TSource, PlcGroupBy>> GetPlcGroup<TSource>() where TSource : PlcBase
      {
         return x => new()
         {
            DatePart = x.Date.DayOfYear,
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
