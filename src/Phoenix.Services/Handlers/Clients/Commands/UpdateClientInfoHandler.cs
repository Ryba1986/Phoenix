using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Clients;
using Phoenix.Models.Clients.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Clients.Commands
{
   internal sealed class UpdateClientInfoHandler : HandlerBase, IRequestHandler<UpdateClientInfoCommand, Result>
   {
      public UpdateClientInfoHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(UpdateClientInfoCommand request, CancellationToken cancellationToken)
      {
         Client? client = await _uow.Client.FirstOrDefaultAsync(x =>
            x.Id == request.Id &&
            x.IsActive
         , cancellationToken);

         if (client is null)
         {
            return Result.Error(Translations.Client_NotExists);
         }
         if (client.Hostname == request.Hostname && client.ClientVersion == request.ClientVersion)
         {
            return Result.Success();
         }

         client.Hostname = request.Hostname;
         client.ClientVersion = request.ClientVersion;

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
