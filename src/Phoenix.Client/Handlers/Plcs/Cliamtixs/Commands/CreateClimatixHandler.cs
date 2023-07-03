using System.Threading;
using System.Threading.Tasks;
using LiteDB;
using MediatR;
using Phoenix.Client.Handlers.Base;
using Phoenix.Models.Plcs.Climatixs.Commands;
using Phoenix.Shared.Results;
using RestSharp;

namespace Phoenix.Client.Handlers.Plcs.Cliamtixs.Commands
{
   internal sealed class CreateClimatixHandler : StorageHandlerBase, IRequestHandler<CreateClimatixCommand, Result>
   {
      public CreateClimatixHandler(IRestClient client, ILiteRepository repository) : base(client, repository)
      {
      }

      public Task<Result> Handle(CreateClimatixCommand request, CancellationToken cancellationToken)
      {
         return CreatePlcAsync("climatix/createClimatix", request, cancellationToken);
      }
   }
}
