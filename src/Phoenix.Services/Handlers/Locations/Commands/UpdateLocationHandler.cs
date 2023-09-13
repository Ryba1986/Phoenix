using System.Linq;
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
   internal sealed class UpdateLocationHandler : HandlerBase, IRequestHandler<UpdateLocationCommand, Result>
   {
      private readonly PhoenixSettings _settings;

      public UpdateLocationHandler(UnitOfWork uow, PhoenixSettings settings) : base(uow)
      {
         _settings = settings;
      }

      public async Task<Result> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
      {
         if (!await IsActiveUserExistsAsync(request.ModifiedById, cancellationToken))
         {
            return Result.Error(Translations.User_Active_NotExists);
         }

         bool otherExists = await _uow.Location
            .AsNoTracking()
            .AnyAsync(x =>
               x.Name == request.Name &&
               x.Id != request.Id
            , cancellationToken);

         if (otherExists)
         {
            return Result.Error(Translations.Location_Exists);
         }

         Location? location = await _uow.Location.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
         if (location is null)
         {
            return Result.Error(Translations.Location_NotExists);
         }
         if (!location.IsActive && request.IsActive && await LocationHandlerHelper.IsLimitActiveLocationsAsync(_uow, _settings.LocationLimit, cancellationToken))
         {
            return Result.Error(Translations.Location_Active_Limit);
         }
         if (!location.Version.SequenceEqual(request.Version))
         {
            return Result.Error(Translations.Validator_Version_Invalid);
         }

         if (location.Name == request.Name && location.IncludeReport == request.IncludeReport && location.IsActive == request.IsActive)
         {
            return Result.Success();
         }

         _uow.LocationHistory.Add(new()
         {
            LocationId = request.Id,
            Name = location.Name != request.Name ? request.Name : string.Empty,
            IncludeReport = request.IncludeReport,
            IsActive = request.IsActive,
            CreatedById = request.ModifiedById,
            CreateDate = await GetServerDateAsync(),
         });

         location.Name = request.Name;
         location.IncludeReport = request.IncludeReport;
         location.IsActive = request.IsActive;

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
