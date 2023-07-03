using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Client.Extensions;
using Phoenix.Client.Handlers.Base;
using Phoenix.Models.Clients.Commands;
using Phoenix.Shared.Results;
using RestSharp;

namespace Phoenix.Client.Handlers.Clients.Commands
{
   internal sealed class UpdateClientInfoHandler : HandlerBase, IRequestHandler<UpdateClientInfoCommand, Result>
   {
      public UpdateClientInfoHandler(IRestClient client) : base(client)
      {
      }

      public Task<Result> Handle(UpdateClientInfoCommand request, CancellationToken cancellationToken)
      {
         return _client.PostAsync("client/updateClientInfo", request, cancellationToken);
      }
   }
}
