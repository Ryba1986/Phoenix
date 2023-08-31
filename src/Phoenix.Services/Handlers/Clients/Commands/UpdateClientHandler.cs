using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Clients;
using Phoenix.Models.Clients.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Helpers;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Clients.Commands
{
   internal sealed class UpdateClientHandler : HandlerBase, IRequestHandler<UpdateClientCommand, Result>
   {
      public UpdateClientHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
      {
         if (!await IsActiveUserExistsAsync(request.ModifiedById, cancellationToken))
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

         bool otherExists = await _uow.Client
            .AsNoTracking()
            .AnyAsync(x =>
               x.MacAddress == request.MacAddress &&
               x.Id != request.Id
            , cancellationToken);

         if (otherExists)
         {
            return Result.Error(Translations.Client_Exists);
         }

         bool clientLocationExists = await _uow.Client
            .AsNoTracking()
            .AnyAsync(x =>
               x.LocationId == request.LocationId &&
               x.Id != request.Id
            , cancellationToken);

         if (clientLocationExists)
         {
            return Result.Error(Translations.Client_Exists);
         }

         Client? client = await _uow.Client.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
         if (client is null)
         {
            return Result.Error(Translations.Client_NotExists);
         }
         if (client.Version != request.Version)
         {
            return Result.Error(Translations.Validator_Version_Invalid);
         }
         if (client.LocationId == request.LocationId && client.MacAddress == request.MacAddress && client.IsActive == request.IsActive)
         {
            return Result.Success();
         }

         _uow.ClientHistory.Add(new()
         {
            ClientId = request.Id,
            LocationId = client.LocationId != request.LocationId ? request.LocationId : null,
            MacAddress = client.MacAddress != request.MacAddress ? request.MacAddress : string.Empty,
            IsActive = request.IsActive,
            CreatedById = request.ModifiedById,
            CreateDate = await GetServerDateAsync(),
         });

         client.LocationId = request.LocationId;
         client.MacAddress = request.MacAddress;
         client.IsActive = request.IsActive;
         client.Version = RandomHelper.NewShort();

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
