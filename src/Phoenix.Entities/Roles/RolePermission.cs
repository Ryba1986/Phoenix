using Phoenix.Entities.Base;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Entities.Roles
{
   public sealed class RolePermission : MetricBase
   {
      public int RoleId { get; set; }
      public Role Role { get; set; }

      public Permission Permission { get; set; }
      public AccessLevel AccessLevel { get; set; }

      public RolePermission()
      {
         Role = null!;
      }
   }
}
