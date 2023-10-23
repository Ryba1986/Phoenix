using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Roles.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Roles.Queries
{
   internal sealed class GetRoleDictionaryHandler : HandlerBase, IRequestHandler<GetRoleDictionaryQuery, IReadOnlyCollection<KeyValuePair<int, string>>>
   {
      public GetRoleDictionaryHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<KeyValuePair<int, string>>> Handle(GetRoleDictionaryQuery request, CancellationToken cancellationToken)
      {
         return await _uow.Role
            .AsNoTracking()
            .Select(x => new KeyValuePair<int, string>(x.Id, x.Name))
            .ToArrayAsync(cancellationToken);
      }
   }
}
