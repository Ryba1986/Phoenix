using Microsoft.Extensions.Configuration;

namespace Phoenix.Shared.Extensions
{
   public static class ConfigurationExtensions
   {
      public static T GetSettings<T>(this IConfiguration configuration, string suffix = "Settings") where T : class, new()
      {
         T value = new();

         configuration
            .GetSection(typeof(T).Name.Replace(suffix, string.Empty))
            .Bind(value);

         return value;
      }
   }
}
