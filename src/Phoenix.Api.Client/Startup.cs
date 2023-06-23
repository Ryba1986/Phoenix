using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Phoenix.Shared.Enums.Jwt;
using Phoenix.Shared.Extensions;
using Phoenix.Validators.Roles;

namespace Phoenix.Api.Client
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
            .AddControllers(x =>
            {
               x.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
               x.OutputFormatters.RemoveType<StreamOutputFormatter>();
               x.OutputFormatters.RemoveType<StringOutputFormatter>();
            })
            .AddJsonOptions(x =>
            {
               x.JsonSerializerOptions.WriteIndented = false;
               x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
               x.JsonSerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver();
            });

         services
            .AddFluentValidationAutoValidation(x =>
            {
               ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
               ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

               x.DisableDataAnnotationsValidation = true;
            })
            .AddValidatorsFromAssemblyContaining<CreateRoleValidator>()
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
               x.TokenValidationParameters = new TokenValidationParameters
               {
                  ValidateLifetime = true,
                  ValidateAudience = false,
                  ValidateIssuer = true,
                  ValidIssuer = JwtIssuer.Client.GetDescription(),
                  ClockSkew = TimeSpan.Zero,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"] ?? string.Empty))
               };
            });
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
