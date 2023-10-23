using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

namespace Phoenix.Api.Shared.Configurations
{
   public static class MvcConfiguration
   {
      public static IMvcBuilder ConfigureControllers(this IServiceCollection services)
      {
         return services.AddControllers(x =>
         {
            x.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            x.OutputFormatters.RemoveType<StreamOutputFormatter>();
            x.OutputFormatters.RemoveType<StringOutputFormatter>();
         });
      }
   }
}
