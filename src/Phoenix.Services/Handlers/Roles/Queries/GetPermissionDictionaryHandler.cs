using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Models.Roles.Queries;
using Phoenix.Shared.Enums.Roles;
using Phoenix.Shared.Extensions;

namespace Phoenix.Services.Handlers.Roles.Queries
{
   internal sealed class GetPermissionDictionaryHandler : IRequestHandler<GetPermissionDictionaryQuery, IReadOnlyCollection<KeyValuePair<int, string>>>
   {
      public async Task<IReadOnlyCollection<KeyValuePair<int, string>>> Handle(GetPermissionDictionaryQuery request, CancellationToken cancellationToken)
      {
         return await Task.FromResult(EnumExtensions.GetValues<Permission>().ToArray());
      }
   }
}
