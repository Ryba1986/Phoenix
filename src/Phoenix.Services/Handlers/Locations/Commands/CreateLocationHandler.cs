using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Locations;
using Phoenix.Models.Locations.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Helpers;
using Phoenix.Services.Repositories;
using Phoenix.Services.Settings;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Locations.Commands
{
   internal sealed class CreateLocationHandler : HandlerBase, IRequestHandler<CreateLocationCommand, Result>
   {
      private readonly PhoenixSettings _settings;

      public CreateLocationHandler(UnitOfWork uow, PhoenixSettings settings) : base(uow)
      {
         _settings = settings;
      }

      public async Task<Result> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
      {
         if (!await IsActiveUserExistsAsync(request.CreatedById, cancellationToken))
         {
            return Result.Error(Translations.User_Active_NotExists);
         }

         bool locationExists = await _uow.Location
            .AsNoTracking()
            .AnyAsync(x => x.Name == request.Name, cancellationToken);

         if (locationExists)
         {
            return Result.Error(Translations.Location_Exists);
         }
         if (request.IsActive && await LocationHandlerHelper.IsLimitActiveLocationsAsync(_uow, _settings.LocationLimit, cancellationToken))
         {
            return Result.Error(Translations.Location_Active_Limit);
         }

         Location newLocation = new()
         {
            Name = request.Name,
            IncludeReport = request.IncludeReport,
            IsActive = request.IsActive,
         };

         _uow.Location.Add(newLocation);
         _uow.LocationHistory.Add(new()
         {
            Location = newLocation,
            Name = request.Name,
            IncludeReport = request.IncludeReport,
            IsActive = request.IsActive,
            CreatedById = request.CreatedById,
            CreateDate = await GetServerDateAsync(),
         });

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
