using Phoenix.Models.Base.Dto;

namespace Phoenix.Models.Roles.Dto
{
   public sealed class RoleDto : MetricDtoBase
   {
      public string Name { get; init; }

      public RoleDto()
      {
         Name = string.Empty;
      }
   }
}
