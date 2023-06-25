using Phoenix.Entities.Base;

namespace Phoenix.Entities.Roles
{
   public sealed class RoleHistory : HistoryBase
   {
      public int RoleId { get; init; }
      public Role Role { get; init; }

      public string Name { get; init; }

      public RoleHistory()
      {
         Role = null!;
         Name = string.Empty;
      }
   }
}
