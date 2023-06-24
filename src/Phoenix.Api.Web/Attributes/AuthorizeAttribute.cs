using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Phoenix.Shared.Enums.Roles;
using Phoenix.Shared.Extensions;

namespace Phoenix.Api.Web.Attributes
{
   internal sealed class AuthorizationAttribute : AuthorizeAttribute
   {
      public AuthorizationAttribute(Permission permission, AccessLevel accessLevel)
      {
         IEnumerable<string> roles = Enum
            .GetValues<AccessLevel>()
            .Where(x => x.GetKey() >= accessLevel.GetKey())
            .Select(x => new KeyValuePair<Permission, AccessLevel>(permission, x))
            .Select(x => x.CreateRoleKeyValue());

         Roles = string.Join(',', roles);
      }
   }
}
