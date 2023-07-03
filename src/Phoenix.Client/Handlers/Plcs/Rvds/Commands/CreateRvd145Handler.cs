using System.Threading;
using System.Threading.Tasks;
using LiteDB;
using MediatR;
using Phoenix.Client.Handlers.Base;
using Phoenix.Models.Plcs.Rvds.Commands;
using Phoenix.Shared.Results;
using RestSharp;

namespace Phoenix.Client.Handlers.Plcs.Rvds.Commands
{
   internal sealed class CreateRvd145Handler : StorageHandlerBase, IRequestHandler<CreateRvd145Command, Result>
   {
      public CreateRvd145Handler(IRestClient client, ILiteRepository repository) : base(client, repository)
      {
      }

      public Task<Result> Handle(CreateRvd145Command request, CancellationToken cancellationToken)
      {
         return CreatePlcAsync("rvd145/createRvd145", request, cancellationToken);
      }
   }
}
