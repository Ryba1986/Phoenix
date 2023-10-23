using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace Phoenix.Api.Shared.Configurations
{
   public static class JsonConfiguration
   {

      public static IMvcBuilder ConfigureJson(this IMvcBuilder mvcBuilder)
      {
         return mvcBuilder.AddJsonOptions(x =>
         {
            x.JsonSerializerOptions.WriteIndented = false;
            x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            x.JsonSerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver();
         });
      }
   }
}
