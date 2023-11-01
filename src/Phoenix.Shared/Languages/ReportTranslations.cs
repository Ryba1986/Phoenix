namespace Phoenix.Shared.Languages
{
   public static partial class Translations
   {
      public static string Report_FileName => Get(eng: "Report", pol: "Raport");

      public static string Report_Header_Day => Get(eng: ".:. {0} :: day report :: {1} .:.", pol: ".:. {0} :: raport dobowy :: {1} .:.");
      public static string Report_Header_Month => Get(eng: ".:. {0} :: month report :: {1} .:.", pol: ".:. {0} :: raport miesięczny :: {1} .:.");
      public static string Report_Header_Year => Get(eng: ".:. {0} :: year report :: {1} .:.", pol: ".:. {0} :: raport roczny :: {1} .:.");
      public static string Report_Header_YearByDay => Get(eng: ".:. {0} :: year report (day after day) :: {1} .:.", pol: ".:. {0} :: raport roczny (dzień po dniu) :: {1} .:.");

      public static string Report_Legend_Day => Get(eng: "Hour", pol: "Godzina");
      public static string Report_Legend_Month => Get(eng: "Day", pol: "Dzień");
      public static string Report_Legend_Year => Get(eng: "Month", pol: "Miesiąc");
      public static string Report_Legend_YearByDay => Get(eng: "Day of year", pol: "Dzień roku");
   }
}
