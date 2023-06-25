using System.Collections.Generic;
using Phoenix.Entities.Base;
using Phoenix.Entities.Roles;

namespace Phoenix.Entities.Users
{
   public sealed class User : MetricBase
   {
      public int RoleId { get; set; }
      public Role Role { get; set; }

      public string Name { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }

      public ICollection<UserHistory> History { get; }

      public User()
      {
         Role = null!;
         Name = string.Empty;
         Email = string.Empty;
         Password = string.Empty;
         History = new List<UserHistory>();
      }
   }
}
