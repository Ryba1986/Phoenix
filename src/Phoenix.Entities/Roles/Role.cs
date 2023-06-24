using System;
using System.Collections.Generic;
using Phoenix.Entities.Base;

namespace Phoenix.Entities.Roles
{
   public sealed class Role : MetricBase
   {
      public string Name { get; set; }

      public ICollection<RoleHistory> History { get; }
      public ICollection<RolePermission> Permissions { get; }

      public Role()
      {
         Name = string.Empty;
         History = Array.Empty<RoleHistory>();
         Permissions = Array.Empty<RolePermission>();
      }
   }
}
