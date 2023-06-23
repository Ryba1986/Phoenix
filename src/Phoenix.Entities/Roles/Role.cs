using Phoenix.Entities.Base;

namespace Phoenix.Entities.Roles
{
   public sealed class Role : MetricBase
   {
      public string Name { get; private set; }

      public Role(string name, bool isActive) : base(isActive)
      {
         Name = name;
      }

      public void Update(string name, bool isActive)
      {
         Name = name;
         IsActive = isActive;
      }
   }
}
