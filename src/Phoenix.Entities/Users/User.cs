using Phoenix.Entities.Base;
using Phoenix.Entities.Roles;

namespace Phoenix.Entities.Users
{
   public sealed class User : MetricBase
   {
      public string Name { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }

      public int RoleId { get; set; }
      public Role Role { get; set; }

      public User()
      {
         Name = string.Empty;
         Email = string.Empty;
         Password = string.Empty;
         Role = null!;
      }
   }
}
