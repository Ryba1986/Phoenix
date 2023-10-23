using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Phoenix.Api.Shared.Configurations;
using Phoenix.Shared.Enums.Jwt;

namespace Phoenix.Api.Web
{
   internal sealed class Startup
   {
      public IConfiguration Configuration { get; }

      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public void ConfigureServices(IServiceCollection services)
      {
         services
            .ConfigureControllers()
            .ConfigureJson();

         services
            .ConfigureLocalization()
            .ConfigureValidation()
            .ConfigureJwtAuthentication(JwtIssuer.Web, Configuration["Jwt:Key"]);
      }

      public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseRouting()
            .UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto })
            .UseAuthentication()
            .UseAuthorization()
            .UseRequestLocalization()
            .UseEndpoints(options =>
            {
               options.MapControllers();
            });
      }
   }
}
