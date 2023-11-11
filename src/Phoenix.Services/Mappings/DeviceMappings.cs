using Phoenix.Entities.Devices;
using Phoenix.Models.Devices.Dto;
using Phoenix.Shared.Extensions;

namespace Phoenix.Services.Mappings
{
   internal static class DeviceMappings
   {

      public static DeviceDto ToDeviceDto(this Device device)
      {
         return new()
         {
            Id = device.Id,
            LocationId = device.LocationId,
            Name = device.Name,
            PlcType = device.PlcType,
            ModbusId = device.ModbusId,
            BoundRate = device.BoundRate,
            DataBits = device.DataBits,
            Parity = device.Parity,
            StopBits = device.StopBits,
            SerialNumber = device.SerialNumber,
            Sequence = device.Sequence,
            IncludeReport = device.IncludeReport,
            IsActive = device.IsActive,
            Version = device.Version,
         };
      }

      public static DeviceHistoryDto ToDeviceHistoryDto(this DeviceHistory deviceHistory)
      {
         return new()
         {
            Id = deviceHistory.Id,
            LocationName = deviceHistory.Location?.Name ?? string.Empty,
            Name = deviceHistory.Name,
            PlcType = deviceHistory.PlcType?.GetDescription() ?? string.Empty,
            ModbusId = deviceHistory.ModbusId.ToString() ?? string.Empty,
            BoundRate = deviceHistory.BoundRate?.GetDescription() ?? string.Empty,
            DataBits = deviceHistory.DataBits?.GetDescription() ?? string.Empty,
            Parity = deviceHistory.Parity?.GetDescription() ?? string.Empty,
            StopBits = deviceHistory.StopBits?.GetDescription() ?? string.Empty,
            SerialNumber = deviceHistory.SerialNumber,
            Sequence = deviceHistory.Sequence.ToString() ?? string.Empty,
            IncludeReport = deviceHistory.IncludeReport,
            IsActive = deviceHistory.IsActive,
            CreatedByName = deviceHistory.CreatedBy.Name,
            CreateDate = deviceHistory.CreateDate,
         };
      }

      public static DeviceReportDto ToDeviceReportDto(this Device device)
      {
         return new()
         {
            Id = device.Id,
            Name = device.Name,
            LocationName = device.Location.Name,
            PlcType = device.PlcType,
         };
      }
   }
}
