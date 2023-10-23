using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Autofac.Features.Indexed;
using MediatR;
using Phoenix.Client.Plcs.Base;
using Phoenix.Client.Settings;
using Phoenix.Client.Workers.Base;
using Phoenix.Models.Base.Commands;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Devices.Queries;
using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Client.Workers
{
   internal sealed class PlcWorker : WorkerBase
   {
      private readonly IIndex<PlcType, IPlcProcessor> _plcProcessors;

      public PlcWorker(IMediator mediator, PhoenixSettings settings, IIndex<PlcType, IPlcProcessor> plcProcessors) : base(mediator, settings)
      {
         _plcProcessors = plcProcessors;
      }

      protected override async Task ExecuteAsync(CancellationToken cancellationToken)
      {
         await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);

         while (!cancellationToken.IsCancellationRequested)
         {
            Stopwatch sw = Stopwatch.StartNew();

            IReadOnlyCollection<DeviceDto> devices = await _mediator.Send(new GetDevicesByClientQuery(), cancellationToken);
            foreach (DeviceDto device in devices)
            {
               try
               {
                  CreatePlcCommandBase command = await _plcProcessors[device.PlcType].GetPlcAsync(device, cancellationToken);
                  await _mediator.Send(command, cancellationToken);
               }
               catch (Exception ex)
               {
                  // TODO: move to other logic
                  Console.WriteLine(ex.Message);
               }
            }

            sw.Stop();
            await GetIntervalAsync(sw.Elapsed, _settings.PlcRefreshInterval, cancellationToken);
         }
      }
   }
}
