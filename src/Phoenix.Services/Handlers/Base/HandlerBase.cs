using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Base;
using Phoenix.Models.Base.Commands;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Extensions;

namespace Phoenix.Services.Handlers.Base
{
   internal abstract class HandlerBase
   {
      protected readonly UnitOfWork _uow;

      public HandlerBase(UnitOfWork uow)
      {
         _uow = uow;
      }

      protected static Task<bool> IsPlcExistAsync<T>(DbSet<T> plcs, CreatePlcCommandBase request, CancellationToken cancellationToken) where T : PlcBase
      {
         return plcs
            .AsNoTracking()
            .AnyAsync(x =>
               x.Date == request.Date.RoundToSecond() &&
               x.DeviceId == request.DeviceId
            , cancellationToken);
      }

      protected Task<bool> IsActiveUserExistsAsync(int userId, CancellationToken cancellationToken)
      {
         return _uow.User
            .AsNoTracking()
            .AnyAsync(x =>
               x.Id == userId &&
               x.IsActive
            , cancellationToken);
      }
   }
}
