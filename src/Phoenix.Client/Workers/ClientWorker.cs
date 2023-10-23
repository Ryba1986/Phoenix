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
         bool isAuthorized;
         bool isInfoUpdated = false;

         while (!cancellationToken.IsCancellationRequested)
         {
            isAuthorized = await GetTokenRefreshAsync(cancellationToken);
            if (!isAuthorized)
            {
               isAuthorized = await GetTokenAsync(cancellationToken);
            }

            if (!isInfoUpdated && isAuthorized)
            {
               isInfoUpdated = await UpdateInfoAsync(cancellationToken);
            }

            TimeSpan delay = isAuthorized
               ? TimeSpan.FromMinutes(1)
               : TimeSpan.FromSeconds(10);

            await Task.Delay(delay, cancellationToken);
         }
      }

      private async Task<bool> GetTokenAsync(CancellationToken cancellationToken)
      {
         TokenResult result = await _mediator.Send(new GetClientTokenQuery()
         {
            MacAddress = NetworkHelper.GetMacAddress(),
         }, cancellationToken);

         return !string.IsNullOrWhiteSpace(result.Value);
      }

      private async Task<bool> GetTokenRefreshAsync(CancellationToken cancellationToken)
      {
         TokenResult result = await _mediator.Send(new GetClientTokenRefreshQuery(), cancellationToken);
         return !string.IsNullOrWhiteSpace(result.Value);
      }

      private async Task<bool> UpdateInfoAsync(CancellationToken cancellationToken)
      {
         Result result = await _mediator.Send(new UpdateClientInfoCommand()
         {
            Hostname = await NetworkHelper.GetTorHostAsync(_settings.TorHostPath, cancellationToken),
            ClientVersion = GetType().GetVersion(),
         }, cancellationToken);

         return result.IsSuccess;
      }
   }
}
