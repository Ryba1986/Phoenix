using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Phoenix.Entities.Roles;
using Phoenix.Entities.Users;
using Phoenix.Services.Settings;
using Phoenix.Shared.Enums.Jwt;
using Phoenix.Shared.Enums.Roles;
using Phoenix.Shared.Extensions;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Helpers
{
   internal static class JwtHandlerHelper
   {
      public static TokenResult CreateClient(int locationId, JwtSettings settings)
      {
         (DateTime StartDate, DateTime EndDate) range = GetTokenRange(settings.ExpireMinutes);
         Claim[] claims = new[]
         {
            locationId.CreateIdClaim()
         };

         return CreateToken(range, claims, JwtIssuer.Client, settings.Key);
      }

      public static TokenResult CreateWeb(User user, IReadOnlyCollection<RolePermission> rolePermissions, JwtSettings settings)
      {
         (DateTime StartDate, DateTime EndDate) range = GetTokenRange(settings.ExpireMinutes);

         List<Claim> claims = new()
         {
            user.Id.CreateIdClaim(),
            user.Name.CreateNameClaim(),
         };

         claims.AddRange(
            rolePermissions
               .Select(x => new KeyValuePair<Permission, AccessLevel>(x.Permission, x.AccessLevel))
               .Select(x => x.CreateRoleClaim())
         );

         return CreateToken(range, claims, JwtIssuer.Web, settings.Key);
      }

      private static (DateTime StartDate, DateTime EndDate) GetTokenRange(ushort expireMinutes)
      {
         DateTime createDate = DateTime.UtcNow;
         DateTime expiresDate = createDate.AddMinutes(expireMinutes);

         return new(createDate, expiresDate);
      }

      private static TokenResult CreateToken((DateTime StartDate, DateTime EndDate) range, IReadOnlyCollection<Claim> claims, JwtIssuer issuer, string tokenKey)
      {
         SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(tokenKey));
         SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);

         JwtSecurityToken jwt = new(
            claims: claims,
            notBefore: range.StartDate,
            expires: range.EndDate,
            signingCredentials: credentials,
            issuer: issuer.GetDescription()
         );

         return new()
         {
            Value = new JwtSecurityTokenHandler().WriteToken(jwt)
         };
      }
   }
}
