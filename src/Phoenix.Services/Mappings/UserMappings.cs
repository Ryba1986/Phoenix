using Phoenix.Entities.Users;
using Phoenix.Models.Users.Dto;

namespace Phoenix.Services.Mappings
{
   internal static class UserMappings
   {
      public static UserDto ToUserDto(this User user)
      {
         return new()
         {
            Id = user.Id,
            RoleId = user.RoleId,
            Name = user.Name,
            Email = user.Email,
            IsActive = user.IsActive,
            Version = user.Version,
         };
      }

      public static UserHistoryDto ToUserHistoryDto(this UserHistory userHistory)
      {
         return new()
         {
            Id = userHistory.Id,
            RoleName = userHistory.Role?.Name ?? string.Empty,
            Name = userHistory.Name,
            Email = userHistory.Email,
            IsActive = userHistory.IsActive,
            CreatedByName = userHistory.CreatedBy.Name,
            CreateDate = userHistory.CreateDate,
         };
      }
   }
}
