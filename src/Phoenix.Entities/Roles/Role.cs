using System;
using System.Collections.Generic;
using Phoenix.Entities.Base;

namespace Phoenix.Entities.Roles
{
   public sealed class Role : MetricBase
   {
      public string Name { get; set; }

      public ICollection<RolePermission> Permissions { get; }

      public Role()
      {
         Name = string.Empty;
         Permissions = Array.Empty<RolePermission>();
      }
   }
}
