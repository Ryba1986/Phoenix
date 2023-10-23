using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

      protected static DateTime GetServerDate()
      {
         return DateTime.Now.RoundToSecond();
      }

      protected Task<bool> IsActiveUserAsync(int userId, CancellationToken cancellationToken)
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
