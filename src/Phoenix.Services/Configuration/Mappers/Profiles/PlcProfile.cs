using AutoMapper;
using Phoenix.Entities.Plcs.Climatixs;
using Phoenix.Entities.Plcs.Meters;
using Phoenix.Models.Plcs.Climatixs.Dto;
using Phoenix.Models.Plcs.Meters.Dto;

namespace Phoenix.Services.Configuration.Mappers.Profiles
{
   internal sealed class PlcProfile : Profile
   {
      public PlcProfile()
      {
         CreateProjection<Climatix, ClimatixDto>();
         CreateProjection<Climatix, ClimatixChartDto>();

         CreateProjection<Kamstrup, KamstrupDto>();
         CreateProjection<Kamstrup, KamstrupChartDto>();
      }
   }
}
