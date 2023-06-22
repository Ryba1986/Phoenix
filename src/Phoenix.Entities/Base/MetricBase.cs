using Phoenix.Shared.Helpers;

namespace Phoenix.Entities.Base
{
   public abstract class MetricBase : EntityBase
   {
      public bool IsActive { get; protected set; }
      public short Version { get; private set; }

      public MetricBase(bool isActive)
      {
         UpdateVersion();

         IsActive = isActive;
      }

      protected void UpdateVersion()
      {
         Version = RandomHelper.NewShort();
      }
   }
}
