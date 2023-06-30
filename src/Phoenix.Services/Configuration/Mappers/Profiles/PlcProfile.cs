using AutoMapper;
using Phoenix.Entities.Plcs.Climatixs;
using Phoenix.Entities.Plcs.Meters;
using Phoenix.Entities.Plcs.Rvds;
using Phoenix.Models.Plcs.Climatixs.Dto;
using Phoenix.Models.Plcs.Meters.Dto;
using Phoenix.Models.Plcs.Rvds.Dto;

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

         CreateProjection<Rvd145, Rvd145Dto>();
         CreateProjection<Rvd145, Rvd145ChartDto>();
      }
   }
}
