using System;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Phoenix.Shared.Enums.Jwt;
using Phoenix.Shared.Extensions;

namespace Phoenix.Api.Shared.Configurations
{
   public static class AuthenticationConfiguration
   {
      public static AuthenticationBuilder ConfigureJwtAuthentication(this IServiceCollection services, JwtIssuer jwtIssuer, string? signingKey)
      {
         return services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(x =>
            {
               x.TokenValidationParameters = new TokenValidationParameters
               {
                  ValidateLifetime = true,
                  ValidateAudience = false,
                  ValidateIssuer = true,
                  ValidIssuer = jwtIssuer.GetDescription(),
                  ClockSkew = TimeSpan.Zero,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey ?? string.Empty))
               };
            });
      }
   }
}
