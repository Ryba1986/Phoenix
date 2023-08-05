using System;
using System.Collections.Generic;
using System.Linq;
using Phoenix.Entities.Users;
using Phoenix.Services.Settings;
using Phoenix.Shared.Enums.Roles;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Helpers
{
   internal static class RoleHandlerHelper
   {
      public static TokenResult GetTokenResult(User? user, JwtSettings settings)
      {
         if (user?.Role is null)
         {
            return new();
         }

         if (user.Role.IsAdmin)
         {
            return JwtHandlerHelper.CreateWeb(
               user,
               Enum
                  .GetValues<Permission>()
                  .Select(x => new KeyValuePair<Permission, AccessLevel>(x, AccessLevel.Write)),
               settings
            );
         }

         if (user.Role.Permissions.Count == 0)
         {
            return new();
         }

         return JwtHandlerHelper.CreateWeb(
            user,
            user.Role.Permissions
               .Where(x => x.IsActive)
               .Select(x => new KeyValuePair<Permission, AccessLevel>(x.Permission, x.AccessLevel)),
            settings
         );
      }
   }
}
