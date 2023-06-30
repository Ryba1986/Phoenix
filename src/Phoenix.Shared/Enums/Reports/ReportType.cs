using Phoenix.Shared.Attributes;
using Phoenix.Shared.Languages;

namespace Phoenix.Shared.Enums.Reports
{
   public enum ReportType : byte
   {
      [Localization(nameof(Translations.ReportType_Day))]
      Day = 1,

      [Localization(nameof(Translations.ReportType_Month))]
      Month = 2,

      [Localization(nameof(Translations.ReportType_Year))]
      Year = 3,

      [Localization(nameof(Translations.ReportType_YearByDay))]
      YearByDay = 4
   }
}
