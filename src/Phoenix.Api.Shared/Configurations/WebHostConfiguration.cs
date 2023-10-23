using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Phoenix.Services.Configuration;

namespace Phoenix.Api.Shared.Configurations
{
   public static class WebHostConfiguration
   {
      public static IHostBuilder ConfigureAutofacProvider(this IHostBuilder hostBuilder)
      {
         return hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
      }

      public static IHostBuilder ConfigureHostDefaults<T>(this IHostBuilder hostBuilder) where T : class
      {
         return hostBuilder.ConfigureWebHostDefaults(builder =>
         {
            builder
               .UseStartup<T>()
               .UseKestrel(options =>
               {
                  options.AddServerHeader = false;
               });
         });
      }

      public static IHostBuilder ConfigurePhoenixModule(this IHostBuilder hostBuilder)
      {
         return hostBuilder.ConfigureContainer<ContainerBuilder>((context, builder) =>
         {
            builder.RegisterModule(new PhoenixModule(context.Configuration));
         });
      }
   }
}
