namespace Phoenix.Models.Base.Dto
{
   public abstract class ReportDtoBase
   {
      public int Id { get; init; }
      public string Name { get; init; }

      public ReportDtoBase()
      {
         Name = string.Empty;
      }
   }
}
