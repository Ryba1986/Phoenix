using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Client.Settings;
using Phoenix.Client.Workers.Base;
using Phoenix.Models.Clients.Commands;
using Phoenix.Models.Clients.Queries;
using Phoenix.Shared.Extensions;
using Phoenix.Shared.Helpers;
using Phoenix.Shared.Results;

namespace Phoenix.Client.Workers
{
   internal sealed class ClientWorker : WorkerBase
   {
      public ClientWorker(IMediator mediator, PhoenixSettings settings) : base(mediator, settings)
      {
      }

      protected override async Task ExecuteAsync(CancellationToken cancellationToken)
      {
         while (!cancellationToken.IsCancellationRequested)
         {
            bool refreshResult = await GetTokenRefreshAsync(cancellationToken);
            if (!refreshResult)
            {
               await GetTokenAsync(cancellationToken);
            }

            await UpdateClientInfoAsync(cancellationToken);

            await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
         }
      }

      private async Task GetTokenAsync(CancellationToken cancellationToken)
      {
         await _mediator.Send(new GetClientTokenRefreshQuery(), cancellationToken);
      }

      private async Task<bool> GetTokenRefreshAsync(CancellationToken cancellationToken)
      {
         TokenResult result = await _mediator.Send(new GetClientTokenRefreshQuery(), cancellationToken);
         return !string.IsNullOrWhiteSpace(result.Value);
      }

      private async Task UpdateClientInfoAsync(CancellationToken cancellationToken)
      {
         await _mediator.Send(new UpdateClientInfoCommand()
         {
            Hostname = await NetworkHelper.GetTorHostAsync(_settings.TorHostPath, cancellationToken),
            ClientVersion = GetType().GetVersion(),
         }, cancellationToken);
      }
   }
}
