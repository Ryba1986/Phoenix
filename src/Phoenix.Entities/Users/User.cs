using Phoenix.Entities.Base;
using Phoenix.Shared.Extensions;

namespace Phoenix.Entities.Users
{
   public sealed class User : MetricBase
   {
      public string Name { get; private set; }
      public string Email { get; private set; }
      public string Password { get; private set; }
      public int RoleId { get; private set; }

      public User(string name, string email, string password, int roleId, bool isActive) : base(isActive)
      {
         Name = name;
         Email = email;
         Password = password.CreatePassword();
         RoleId = roleId;
      }

      public void Update(string name, string email, int roleId, bool isActive)
      {
         Name = name;
         Email = email;
         RoleId = roleId;
         IsActive = isActive;
      }

      public void Update(string newPassword)
      {
         Password = newPassword.CreatePassword();
      }
   }
}
