using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Roles.Dto;
using Phoenix.Models.Roles.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Roles.Queries
{
   internal sealed class GetRoleHistoryHandler : QueryHandlerBase, IRequestHandler<GetRoleHistoryQuery, IReadOnlyCollection<RoleHistoryDto>>
   {
      public GetRoleHistoryHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<IReadOnlyCollection<RoleHistoryDto>> Handle(GetRoleHistoryQuery request, CancellationToken cancellationToken)
      {
         return await _uow.RoleHistory
            .AsNoTracking()
            .Include(x => x.CreatedBy)
            .Where(x => x.RoleId == request.RoleId)
            .OrderByDescending(x => x.CreateDate)
            .ProjectTo<RoleHistoryDto>(_mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);
      }
   }
}
