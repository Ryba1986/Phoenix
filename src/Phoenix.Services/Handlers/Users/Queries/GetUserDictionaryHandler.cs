using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Users.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Users.Queries
{
   internal sealed class GetUserDictionaryHandler : HandlerBase, IRequestHandler<GetUserDictionaryQuery, IReadOnlyCollection<KeyValuePair<int, string>>>
   {
      public GetUserDictionaryHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<KeyValuePair<int, string>>> Handle(GetUserDictionaryQuery request, CancellationToken cancellationToken)
      {
         return await _uow.User
            .AsNoTracking()
            .Select(x => new KeyValuePair<int, string>(x.Id, x.Name))
            .ToArrayAsync(cancellationToken);
      }
   }
}
