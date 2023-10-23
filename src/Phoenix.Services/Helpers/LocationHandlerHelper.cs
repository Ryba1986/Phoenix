using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Helpers
{
   internal static class LocationHandlerHelper
   {
      public static async Task<bool> IsLimitActiveLocationsAsync(UnitOfWork uow, ushort locationLimitCount, CancellationToken cancellationToken)
      {
         int result = await uow.Location
            .AsNoTracking()
            .CountAsync(x => x.IsActive, cancellationToken);

         return result >= locationLimitCount;
      }
   }
}
