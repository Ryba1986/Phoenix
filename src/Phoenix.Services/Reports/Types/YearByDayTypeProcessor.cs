using System;
using System.Linq.Expressions;
using Phoenix.Entities.Base;
using Phoenix.Models.Plcs;
using Phoenix.Services.Reports.Base;
using Phoenix.Shared.Languages;

namespace Phoenix.Services.Reports.Types
{
   internal sealed class YearByDayTypeProcessor : TypeProcessorBase, ITypeProcessor
   {
      public ushort RemoveTemplateRowCount { get; }

      public YearByDayTypeProcessor()
      {
         RemoveTemplateRowCount = 0;
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

      public Expression<Func<T, PlcGroupBy>> GetPlcGroup<T>() where T : PlcBase
      {
         return x => new()
         {
            DeviceId = x.DeviceId,
            DatePart = x.Date.DayOfYear,
         };
      }

      public Tuple<DateTime, DateTime> GetRange(DateOnly date)
      {
         DateTime dateTime = new(date.Year, 1, 1);
         return new(dateTime, dateTime.AddYears(1));
      }
   }
}
