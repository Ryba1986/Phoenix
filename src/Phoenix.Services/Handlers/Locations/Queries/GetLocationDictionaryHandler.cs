using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Locations.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Locations.Queries
{
   internal sealed class GetLocationDictionaryHandler : HandlerBase, IRequestHandler<GetLocationDictionaryQuery, IReadOnlyCollection<KeyValuePair<int, string>>>
   {
      public GetLocationDictionaryHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<KeyValuePair<int, string>>> Handle(GetLocationDictionaryQuery request, CancellationToken cancellationToken)
      {
         return await _uow.Location
            .AsNoTracking()
            .Select(x => new KeyValuePair<int, string>(x.Id, x.Name))
            .ToArrayAsync(cancellationToken);
      }
   }
}
