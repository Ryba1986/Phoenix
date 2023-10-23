using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Phoenix.Api.Shared.Configurations;

namespace Phoenix.Api.Client
{
   internal sealed class Program
   {
      public static Task Main(string[] args)
      {
         return CreateHostBuilder(args)
            .Build()
            .RunAsync();
      }

      private static IHostBuilder CreateHostBuilder(string[] args)
      {
         return Host
            .CreateDefaultBuilder(args)
            .ConfigureAutofacProvider()
            .UseSystemd()
            .ConfigureHostDefaults<Startup>()
            .ConfigurePhoenixModule();
      }
   }
}
