using Phoenix.Entities.Base;
using Phoenix.Shared.Enums.Roles;

namespace Phoenix.Entities.Roles
{
   public sealed class RolePermission : MetricBase
   {
      public int RoleId { get; private set; }
      public Permission Permission { get; private set; }
      public AccessLevel AccessLevel { get; private set; }

      public RolePermission(int roleId, Permission permission, AccessLevel accessLevel, bool isActive) : base(isActive)
      {
         RoleId = roleId;
         Permission = permission;
         AccessLevel = accessLevel;
      }

      public void Update(AccessLevel accessLevel, bool isActive)
      {
         AccessLevel = accessLevel;
         IsActive = isActive;
      }
   }
}
