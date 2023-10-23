using System;
using System.Linq.Expressions;
using Phoenix.Entities.Base;
using Phoenix.Models.Plcs;
using Phoenix.Services.Reports.Base;
using Phoenix.Shared.Languages;

namespace Phoenix.Services.Reports.Types
{
   internal sealed class YearTypeProcessor : TypeProcessorBase, ITypeProcessor
   {
      public ushort RemoveTemplateRowCount { get; }

      public YearTypeProcessor()
      {
         RemoveTemplateRowCount = 354;
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

      public string GetLegend()
      {
         return Translations.Report_Legend_Year;
      }

      public Expression<Func<T, PlcGroupBy>> GetPlcGroup<T>() where T : PlcBase
      {
         return x => new()
         {
            DeviceId = x.Device.Id,
            DeviceType = x.Device.DeviceType,
            DatePart = x.Date.Month,
         };
      }

      public Tuple<DateTime, DateTime> GetRange(DateOnly date)
      {
         DateTime dateTime = new(date.Year, 1, 1);
         return new(dateTime, dateTime.AddYears(1));
      }
   }
}
