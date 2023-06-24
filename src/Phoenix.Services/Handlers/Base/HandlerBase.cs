using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Base
{
   internal abstract class HandlerBase
   {
      protected readonly UnitOfWork _uow;

      public HandlerBase(UnitOfWork uow)
      {
         _uow = uow;
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
