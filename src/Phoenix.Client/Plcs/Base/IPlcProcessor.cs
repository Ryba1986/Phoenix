using System.Threading;
using System.Threading.Tasks;
using Phoenix.Models.Base.Commands;
using Phoenix.Models.Devices.Dto;

namespace Phoenix.Client.Plcs.Base
{
   internal interface IPlcProcessor
   {
      Task<CreatePlcCommandBase> GetPlcAsync(DeviceDto device, CancellationToken cancellationToken);
   }
}
