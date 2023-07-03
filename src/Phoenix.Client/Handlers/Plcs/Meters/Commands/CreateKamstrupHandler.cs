using System.Threading;
using System.Threading.Tasks;
using LiteDB;
using MediatR;
using Phoenix.Client.Handlers.Base;
using Phoenix.Models.Plcs.Meters.Commands;
using Phoenix.Shared.Results;
using RestSharp;

namespace Phoenix.Client.Handlers.Plcs.Meters.Commands
{
   internal sealed class CreateKamstrupHandler : StorageHandlerBase, IRequestHandler<CreateKamstrupCommand, Result>
   {
      public CreateKamstrupHandler(IRestClient client, ILiteRepository repository) : base(client, repository)
      {
      }

      public Task<Result> Handle(CreateKamstrupCommand request, CancellationToken cancellationToken)
      {
         return CreatePlcAsync("kamstrup/createKamstrup", request, cancellationToken);
      }
   }
}
