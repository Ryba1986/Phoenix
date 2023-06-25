using System.Collections.Generic;
using MediatR;
using Phoenix.Models.Devices.Dto;

namespace Phoenix.Models.Devices.Queries
{
   public sealed class GetDevicesByLocationQuery : IRequest<IReadOnlyCollection<DeviceDto>>
   {
      public int LocationId { get; init; }
   }
}
