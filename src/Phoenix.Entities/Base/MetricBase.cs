namespace Phoenix.Entities.Base
{
   public abstract class MetricBase : EntityBase
   {
      public bool IsActive { get; set; }
      public short Version { get; set; }
   }
}
