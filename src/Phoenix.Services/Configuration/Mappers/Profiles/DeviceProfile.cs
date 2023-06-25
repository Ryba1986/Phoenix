using AutoMapper;
using Phoenix.Entities.Devices;
using Phoenix.Models.Devices.Dto;
using Phoenix.Shared.Extensions;

namespace Phoenix.Services.Configuration.Mappers.Profiles
{
   internal sealed class DeviceProfile : Profile
   {
      public DeviceProfile()
      {
         CreateProjection<Device, DeviceHistory>();

         CreateProjection<DeviceHistory, DeviceHistoryDto>()
            .ForMember(dst => dst.LocationName, opt => opt.MapFrom(src => src.Location != null ? src.Location.Name : string.Empty))
            .ForMember(dst => dst.DeviceType, opt => opt.MapFrom(src => src.DeviceType != null ? src.DeviceType.GetDescription() : string.Empty))
            .ForMember(dst => dst.PlcType, opt => opt.MapFrom(src => src.PlcType != null ? src.PlcType.GetDescription() : string.Empty))
            .ForMember(dst => dst.ModbusId, opt => opt.MapFrom(src => src.ModbusId != null ? src.ModbusId.ToString() : string.Empty))
            .ForMember(dst => dst.BoundRate, opt => opt.MapFrom(src => src.BoundRate != null ? src.BoundRate.GetDescription() : string.Empty))
            .ForMember(dst => dst.DataBits, opt => opt.MapFrom(src => src.DataBits != null ? src.DataBits.GetDescription() : string.Empty))
            .ForMember(dst => dst.Parity, opt => opt.MapFrom(src => src.Parity != null ? src.Parity.GetDescription() : string.Empty))
            .ForMember(dst => dst.StopBits, opt => opt.MapFrom(src => src.StopBits != null ? src.StopBits.GetDescription() : string.Empty));
      }
   }
}
