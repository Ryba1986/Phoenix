using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Users.Dto
{
   public sealed class UserDto : MetricDtoBase
   {
      public int RoleId { get; init; }
      public string Name { get; init; }
      public string Email { get; init; }

      public UserDto()
      {
         Name = string.Empty;
         Email = string.Empty;
      }
   }
}
