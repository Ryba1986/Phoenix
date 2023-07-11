using System;
using System.Linq.Expressions;
using Phoenix.Entities.Base;
using Phoenix.Models.Utilities;
using Phoenix.Services.Reports.Base;
using Phoenix.Shared.Enums.Reports;
using Phoenix.Shared.Languages;

namespace Phoenix.Services.Reports.Types
{
   internal sealed class MonthTypeProcessor : TypeProcessorBase, ITypeProcessor
   {
      public ushort RemoveTemplateRowCount { get; }
      public ReportType Type { get; }

      public MonthTypeProcessor()
      {
         RemoveTemplateRowCount = 335;
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

      public string GetLegend()
      {
         return Translations.Report_Legend_Month;
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
