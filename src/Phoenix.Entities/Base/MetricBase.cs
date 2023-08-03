using System.Security.Cryptography;

namespace Phoenix.Entities.Base
{
   public abstract class MetricBase : EntityBase
   {
      public bool IsActive { get; set; }
      public short Version { get; private set; }

      public void UpdateVersion()
      {
         Version = (short)RandomNumberGenerator.GetInt32(default(short), short.MaxValue);
      }
   }
}
