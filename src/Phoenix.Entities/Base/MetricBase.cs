namespace Phoenix.Entities.Base
{
   public abstract class MetricBase : EntityBase
   {
      public bool IsActive { get; set; }
      public short Version { get; private set; }

      public void Update(short value)
      {
         Version = value;
      }
   }
}
