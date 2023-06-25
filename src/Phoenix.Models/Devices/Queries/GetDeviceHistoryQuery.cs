using System.Collections.Generic;
using MediatR;
using Phoenix.Models.Devices.Dto;

namespace Phoenix.Models.Devices.Queries
{
   public sealed class GetDeviceHistoryQuery : IRequest<IReadOnlyCollection<DeviceHistoryDto>>
   {
      public int DeviceId { get; init; }
   }
}
