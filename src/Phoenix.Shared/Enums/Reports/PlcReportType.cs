using Phoenix.Shared.Attributes;
using Phoenix.Shared.Languages;

namespace Phoenix.Shared.Enums.Reports
{
   public enum PlcReportType : byte
   {
      [Localization(nameof(Translations.PlcReportType_Day))]
      Day = 1,

      [Localization(nameof(Translations.PlcReportType_Month))]
      Month = 2,

      [Localization(nameof(Translations.PlcReportType_Year))]
      Year = 3,

      [Localization(nameof(Translations.PlcReportType_YearByDay))]
      YearByDay = 4
   }
}
