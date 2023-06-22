namespace Phoenix.Models.Base.Dto
{
   public abstract class MetricDtoBase : DtoBase
   {
      public bool IsActive { get; init; }
      public short Version { get; init; }
   }
}
