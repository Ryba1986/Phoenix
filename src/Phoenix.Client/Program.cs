using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Phoenix.Client.Configuration;

namespace Phoenix.Client
{
   internal sealed class Program
   {
      private static async Task Main()
      {
         await CreateHostBuilder()
            .Build()
            .RunAsync();
      }

      private static IHostBuilder CreateHostBuilder()
      {
         return Host
            .CreateDefaultBuilder()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .UseSystemd()
            .ConfigureServices(services =>
            {
            })
            .ConfigureContainer<ContainerBuilder>((ctx, builder) =>
            {
               builder.RegisterModule(new PhoenixModule(ctx.Configuration));
            });
      }
   }
}
