using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Hosting;
using Phoenix.Client.Settings;

namespace Phoenix.Client.Workers.Base
{
   internal abstract class WorkerBase : BackgroundService
   {
      protected readonly IMediator _mediator;
      protected readonly PhoenixSettings _settings;

      public WorkerBase(IMediator mediator, PhoenixSettings settings)
      {
         _mediator = mediator;
         _settings = settings;
      }

      protected static Task GetIntervalAsync(TimeSpan elapsedTime, int interval, CancellationToken cancellationToken)
      {
         TimeSpan intervalTime = TimeSpan.FromMilliseconds(interval);
         if (elapsedTime >= intervalTime)
         {
            return Task.CompletedTask;
         }

         return Task.Delay(intervalTime - elapsedTime, cancellationToken);
      }
   }
}
