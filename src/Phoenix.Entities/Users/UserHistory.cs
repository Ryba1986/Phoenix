using Phoenix.Entities.Base;
using Phoenix.Entities.Roles;

namespace Phoenix.Entities.Users
{
   public sealed class UserHistory : HistoryBase
   {
      public int UserId { get; init; }
      public User User { get; init; }

      public int? RoleId { get; init; }
      public Role? Role { get; init; }

      public string Name { get; init; }
      public string Email { get; init; }

      public UserHistory()
      {
         User = null!;
         Name = string.Empty;
         Email = string.Empty;
      }
   }
}
