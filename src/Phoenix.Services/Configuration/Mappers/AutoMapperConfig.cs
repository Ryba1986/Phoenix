using AutoMapper;

namespace Phoenix.Services.Configuration.Mappers
{
   internal static class AutoMapperConfig
   {
      public static IMapper Initialize()
      {
         return new MapperConfiguration(config => config.AddMaps(typeof(AutoMapperConfig)))
            .CreateMapper();
      }
   }
}
