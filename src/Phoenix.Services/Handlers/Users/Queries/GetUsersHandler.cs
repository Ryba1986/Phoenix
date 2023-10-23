using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Users.Dto;
using Phoenix.Models.Users.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Mappings;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Users.Queries
{
   internal sealed class GetUsersHandler : HandlerBase, IRequestHandler<GetUsersQuery, IReadOnlyCollection<UserDto>>
   {
      public GetUsersHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<IReadOnlyCollection<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
      {
         return await _uow.User
            .AsNoTracking()
            .Select(x => x.ToUserDto())
            .ToArrayAsync(cancellationToken);
      }
   }
}
