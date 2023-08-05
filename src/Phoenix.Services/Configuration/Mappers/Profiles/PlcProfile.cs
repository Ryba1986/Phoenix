using System.Collections.Generic;
using System.Linq;
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
         CreateProjection<Climatix, ClimatixDto>()
            .ForMember(dst => dst.DeviceType, opt => opt.MapFrom(src => src.Device.DeviceType));
         CreateProjection<Climatix, ClimatixChartDto>();
         CreateProjection<IEnumerable<Climatix>, ClimatixReportDto>()
            .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Min(x => x.Date)))
            .ForMember(dst => dst.DeviceId, opt => opt.MapFrom(src => src.Min(x => x.DeviceId)))
            .ForMember(dst => dst.OutsideTempAvg, opt => opt.MapFrom(src => src.Average(x => x.OutsideTemp)))
            .ForMember(dst => dst.OutsideTempMin, opt => opt.MapFrom(src => src.Min(x => x.OutsideTemp)))
            .ForMember(dst => dst.OutsideTempMax, opt => opt.MapFrom(src => src.Max(x => x.OutsideTemp)))
            .ForMember(dst => dst.ChHighInletPresureAvg, opt => opt.MapFrom(src => src.Average(x => x.ChHighInletPresure)))
            .ForMember(dst => dst.ChHighInletPresureMin, opt => opt.MapFrom(src => src.Min(x => x.ChHighInletPresure)))
            .ForMember(dst => dst.ChHighInletPresureMax, opt => opt.MapFrom(src => src.Max(x => x.ChHighInletPresure)))
            .ForMember(dst => dst.ChHighOutletPresureAvg, opt => opt.MapFrom(src => src.Average(x => x.ChHighOutletPresure)))
            .ForMember(dst => dst.ChHighOutletPresureMin, opt => opt.MapFrom(src => src.Min(x => x.ChHighOutletPresure)))
            .ForMember(dst => dst.ChHighOutletPresureMax, opt => opt.MapFrom(src => src.Max(x => x.ChHighOutletPresure)))
            .ForMember(dst => dst.Ch1LowInletTempAvg, opt => opt.MapFrom(src => src.Average(x => x.Ch1LowInletTemp)))
            .ForMember(dst => dst.Ch1LowInletTempMin, opt => opt.MapFrom(src => src.Min(x => x.Ch1LowInletTemp)))
            .ForMember(dst => dst.Ch1LowInletTempMax, opt => opt.MapFrom(src => src.Max(x => x.Ch1LowInletTemp)))
            .ForMember(dst => dst.Ch1LowOutletTempAvg, opt => opt.MapFrom(src => src.Average(x => x.Ch1LowOutletTemp)))
            .ForMember(dst => dst.Ch1LowOutletTempMin, opt => opt.MapFrom(src => src.Min(x => x.Ch1LowOutletTemp)))
            .ForMember(dst => dst.Ch1LowOutletTempMax, opt => opt.MapFrom(src => src.Max(x => x.Ch1LowOutletTemp)))
            .ForMember(dst => dst.Ch1LowOutletPresureAvg, opt => opt.MapFrom(src => src.Average(x => x.Ch1LowOutletPresure)))
            .ForMember(dst => dst.Ch1LowOutletPresureMin, opt => opt.MapFrom(src => src.Min(x => x.Ch1LowOutletPresure)))
            .ForMember(dst => dst.Ch1LowOutletPresureMax, opt => opt.MapFrom(src => src.Max(x => x.Ch1LowOutletPresure)))
            .ForMember(dst => dst.Ch2LowInletTempAvg, opt => opt.MapFrom(src => src.Average(x => x.Ch2LowInletTemp)))
            .ForMember(dst => dst.Ch2LowInletTempMin, opt => opt.MapFrom(src => src.Min(x => x.Ch2LowInletTemp)))
            .ForMember(dst => dst.Ch2LowInletTempMax, opt => opt.MapFrom(src => src.Max(x => x.Ch2LowInletTemp)))
            .ForMember(dst => dst.Ch2LowOutletTempAvg, opt => opt.MapFrom(src => src.Average(x => x.Ch2LowOutletTemp)))
            .ForMember(dst => dst.Ch2LowOutletTempMin, opt => opt.MapFrom(src => src.Min(x => x.Ch2LowOutletTemp)))
            .ForMember(dst => dst.Ch2LowOutletTempMax, opt => opt.MapFrom(src => src.Max(x => x.Ch2LowOutletTemp)))
            .ForMember(dst => dst.Ch2LowOutletPresureAvg, opt => opt.MapFrom(src => src.Average(x => x.Ch2LowOutletPresure)))
            .ForMember(dst => dst.Ch2LowOutletPresureMin, opt => opt.MapFrom(src => src.Min(x => x.Ch2LowOutletPresure)))
            .ForMember(dst => dst.Ch2LowOutletPresureMax, opt => opt.MapFrom(src => src.Max(x => x.Ch2LowOutletPresure)))
            .ForMember(dst => dst.DhwTempAvg, opt => opt.MapFrom(src => src.Average(x => x.DhwTemp)))
            .ForMember(dst => dst.DhwTempMin, opt => opt.MapFrom(src => src.Min(x => x.DhwTemp)))
            .ForMember(dst => dst.DhwTempMax, opt => opt.MapFrom(src => src.Max(x => x.DhwTemp)));

         CreateProjection<Kamstrup, KamstrupDto>()
            .ForMember(dst => dst.DeviceType, opt => opt.MapFrom(src => src.Device.DeviceType));
         CreateProjection<Kamstrup, KamstrupChartDto>();
         CreateProjection<IEnumerable<Kamstrup>, KamstrupReportDto>()
            .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Min(x => x.Date)))
            .ForMember(dst => dst.DeviceId, opt => opt.MapFrom(src => src.Min(x => x.DeviceId)))
            .ForMember(dst => dst.InletTempAvg, opt => opt.MapFrom(src => src.Average(x => x.InletTemp)))
            .ForMember(dst => dst.InletTempMin, opt => opt.MapFrom(src => src.Min(x => x.InletTemp)))
            .ForMember(dst => dst.InletTempMax, opt => opt.MapFrom(src => src.Max(x => x.InletTemp)))
            .ForMember(dst => dst.OutletTempAvg, opt => opt.MapFrom(src => src.Average(x => x.OutletTemp)))
            .ForMember(dst => dst.OutletTempMin, opt => opt.MapFrom(src => src.Min(x => x.OutletTemp)))
            .ForMember(dst => dst.OutletTempMax, opt => opt.MapFrom(src => src.Max(x => x.OutletTemp)))
            .ForMember(dst => dst.PowerAvg, opt => opt.MapFrom(src => src.Average(x => x.Power)))
            .ForMember(dst => dst.PowerMin, opt => opt.MapFrom(src => src.Min(x => x.Power)))
            .ForMember(dst => dst.PowerMax, opt => opt.MapFrom(src => src.Max(x => x.Power)))
            .ForMember(dst => dst.VolumeAvg, opt => opt.MapFrom(src => src.Average(x => x.Volume)))
            .ForMember(dst => dst.VolumeMin, opt => opt.MapFrom(src => src.Min(x => x.Volume)))
            .ForMember(dst => dst.VolumeMax, opt => opt.MapFrom(src => src.Max(x => x.Volume)))
            .ForMember(dst => dst.VolumeSummaryMax, opt => opt.MapFrom(src => src.Max(x => x.VolumeSummary)))
            .ForMember(dst => dst.EnergySummaryMax, opt => opt.MapFrom(src => src.Max(x => x.EnergySummary)));

         CreateProjection<Rvd145, Rvd145Dto>()
            .ForMember(dst => dst.DeviceType, opt => opt.MapFrom(src => src.Device.DeviceType));
         CreateProjection<Rvd145, Rvd145ChartDto>();
         CreateProjection<IEnumerable<Rvd145>, Rvd145ReportDto>()
            .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Min(x => x.Date)))
            .ForMember(dst => dst.DeviceId, opt => opt.MapFrom(src => src.Min(x => x.DeviceId)))
            .ForMember(dst => dst.OutsideTempAvg, opt => opt.MapFrom(src => src.Average(x => x.OutsideTemp)))
            .ForMember(dst => dst.OutsideTempMin, opt => opt.MapFrom(src => src.Min(x => x.OutsideTemp)))
            .ForMember(dst => dst.OutsideTempMax, opt => opt.MapFrom(src => src.Max(x => x.OutsideTemp)))
            .ForMember(dst => dst.ChHighInletPresureAvg, opt => opt.MapFrom(src => src.Average(x => x.ChHighInletPresure)))
            .ForMember(dst => dst.ChHighInletPresureMin, opt => opt.MapFrom(src => src.Min(x => x.ChHighInletPresure)))
            .ForMember(dst => dst.ChHighInletPresureMax, opt => opt.MapFrom(src => src.Max(x => x.ChHighInletPresure)))
            .ForMember(dst => dst.Ch1LowInletTempAvg, opt => opt.MapFrom(src => src.Average(x => x.Ch1LowInletTemp)))
            .ForMember(dst => dst.Ch1LowInletTempMin, opt => opt.MapFrom(src => src.Min(x => x.Ch1LowInletTemp)))
            .ForMember(dst => dst.Ch1LowInletTempMax, opt => opt.MapFrom(src => src.Max(x => x.Ch1LowInletTemp)))
            .ForMember(dst => dst.Ch1LowOutletPresureAvg, opt => opt.MapFrom(src => src.Average(x => x.Ch1LowOutletPresure)))
            .ForMember(dst => dst.Ch1LowOutletPresureMin, opt => opt.MapFrom(src => src.Min(x => x.Ch1LowOutletPresure)))
            .ForMember(dst => dst.Ch1LowOutletPresureMax, opt => opt.MapFrom(src => src.Max(x => x.Ch1LowOutletPresure)))
            .ForMember(dst => dst.DhwTempAvg, opt => opt.MapFrom(src => src.Average(x => x.DhwTemp)))
            .ForMember(dst => dst.DhwTempMin, opt => opt.MapFrom(src => src.Min(x => x.DhwTemp)))
            .ForMember(dst => dst.DhwTempMax, opt => opt.MapFrom(src => src.Max(x => x.DhwTemp)))
            .ForMember(dst => dst.DhwCirculationTempAvg, opt => opt.MapFrom(src => src.Average(x => x.DhwCirculationTemp)))
            .ForMember(dst => dst.DhwCirculationTempMin, opt => opt.MapFrom(src => src.Min(x => x.DhwCirculationTemp)))
            .ForMember(dst => dst.DhwCirculationTempMax, opt => opt.MapFrom(src => src.Max(x => x.DhwCirculationTemp)));
      }
   }
}
