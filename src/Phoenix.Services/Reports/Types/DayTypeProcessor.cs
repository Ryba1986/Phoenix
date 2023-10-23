using System;
using System.Linq.Expressions;
using Phoenix.Entities.Base;
using Phoenix.Models.Plcs;
using Phoenix.Services.Reports.Base;
using Phoenix.Shared.Languages;

namespace Phoenix.Services.Reports.Types
{
   internal sealed class DayTypeProcessor : TypeProcessorBase, ITypeProcessor
   {
      public ushort RemoveTemplateRowCount { get; }

      public DayTypeProcessor()
      {
         RemoveTemplateRowCount = 342;
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

      public string GetLegend()
      {
         return Translations.Report_Legend_Day;
      }

      public Expression<Func<T, PlcGroupBy>> GetPlcGroup<T>() where T : PlcBase
      {
         return x => new()
         {
            DeviceId = x.Device.Id,
            DeviceType = x.Device.DeviceType,
            DatePart = x.Date.Hour,
         };
      }

      public Tuple<DateTime, DateTime> GetRange(DateOnly date)
      {
         DateTime dateTime = date.ToDateTime(TimeOnly.MinValue);
         return new(dateTime, dateTime.AddDays(1));
      }
   }
}
