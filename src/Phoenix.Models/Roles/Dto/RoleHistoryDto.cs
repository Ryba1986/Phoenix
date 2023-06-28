using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Roles.Dto
{
   public sealed class RoleHistoryDto : HistoryDtoBase
   {
      public string Name { get; init; }
      public bool IsAdmin { get; init; }

      public RoleHistoryDto()
      {
         Name = string.Empty;
      }
   }
}
