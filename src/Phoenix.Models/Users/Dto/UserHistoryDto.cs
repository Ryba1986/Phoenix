using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Users.Dto
{
   public sealed class UserHistoryDto : HistoryDtoBase
   {
      public string RoleName { get; init; }
      public string Name { get; init; }
      public string Email { get; init; }

      public UserHistoryDto()
      {
         RoleName = string.Empty;
         Name = string.Empty;
         Email = string.Empty;
      }
   }
}
