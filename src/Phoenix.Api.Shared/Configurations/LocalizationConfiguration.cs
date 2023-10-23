using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Shared.Languages;

namespace Phoenix.Api.Shared.Configurations
{
   public static class LocalizationConfiguration
   {
      public static IServiceCollection ConfigureLocalization(this IServiceCollection services)
      {
         return services.AddRequestLocalization(x =>
         {
            x.SupportedCultures = Translations.GetCultures().ToArray();
            x.DefaultRequestCulture = new(Translations.GetDefaultCulture());
         });
      }
   }
}
