using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Shared.Extensions
{
   public static class JwtExtensions
   {
      private static readonly string _id = nameof(ClaimTypes.NameIdentifier).ToLower();
      private static readonly string _name = nameof(ClaimTypes.Name).ToLower();
      private static readonly string _role = nameof(ClaimTypes.Role).ToLower();

      public static int GetId(this IEnumerable<Claim> claims)
      {
         return Convert.ToInt32(claims.FirstOrDefault(x => x.Type == _id)?.Value);
      }

      public static Claim CreateIdClaim(this int value)
      {
         return new(_id, value.ToString(), ClaimValueTypes.Integer32);
      }

      public static Claim CreateNameClaim(this string value)
      {
         return new(_name, value, ClaimValueTypes.String);
      }

      public static Claim CreateRoleClaim(this KeyValuePair<Permission, AccessLevel> value)
      {
         return new(_role, value.CreateRoleKeyValue(), ClaimValueTypes.String);
      }

      public static string CreateRoleKeyValue(this KeyValuePair<Permission, AccessLevel> value)
      {
         return $"{value.Key.GetKey()}={value.Value.GetKey()}";
      }
   }
}
