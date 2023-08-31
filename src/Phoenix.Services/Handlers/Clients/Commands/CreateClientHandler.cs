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
   internal sealed class CreateClientHandler : HandlerBase, IRequestHandler<CreateClientCommand, Result>
   {
      public CreateClientHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(CreateClientCommand request, CancellationToken cancellationToken)
      {
         if (!await IsActiveUserExistsAsync(request.CreatedById, cancellationToken))
         {
            return Result.Error(Translations.User_Active_NotExists);
         }

         bool locationExists = await _uow.Location
            .AsNoTracking()
            .AnyAsync(x => x.Id == request.LocationId, cancellationToken);

         if (!locationExists)
         {
            return Result.Error(Translations.Location_NotExists);
         }

         bool clientExists = await _uow.Client
            .AsNoTracking()
            .AnyAsync(x => x.MacAddress == request.MacAddress, cancellationToken);

         if (clientExists)
         {
            return Result.Error(Translations.Client_Exists);
         }

         bool clientLocationExists = await _uow.Client
            .AsNoTracking()
            .AnyAsync(x => x.LocationId == request.LocationId, cancellationToken);

         if (clientLocationExists)
         {
            return Result.Error(Translations.Client_Exists);
         }

         Client newClient = new()
         {
            LocationId = request.LocationId,
            MacAddress = request.MacAddress,
            IsActive = request.IsActive,
         };

         _uow.Client.Add(newClient);
         _uow.ClientHistory.Add(new()
         {
            Client = newClient,
            LocationId = request.LocationId,
            MacAddress = request.MacAddress,
            IsActive = request.IsActive,
            CreatedById = request.CreatedById,
            CreateDate = await GetServerDateAsync(),
         });

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
