using System.Collections.Generic;
using System.Globalization;

namespace Phoenix.Shared.Languages
{
   public static partial class Translations
   {
      private const string English = "en";
      private const string Polish = "pl";

      public static CultureInfo GetDefaultCulture()
      {
         return new(English);
      }

      public static IReadOnlyCollection<CultureInfo> GetCultures()
      {
         return new CultureInfo[]{
            GetDefaultCulture(),
            new(Polish)
         };
      }

      private static string Get(string eng, string pol)
      {
         return CultureInfo.CurrentCulture.Name switch
         {
            English => eng,
            Polish => pol,
            _ => eng
         };
      }
   }
}
