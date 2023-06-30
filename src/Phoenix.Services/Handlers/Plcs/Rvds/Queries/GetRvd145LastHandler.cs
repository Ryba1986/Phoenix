using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Plcs.Rvds.Dto;
using Phoenix.Models.Plcs.Rvds.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Rvds.Queries
{
   internal sealed class GetRvd145LastHandler : QueryHandlerBase, IRequestHandler<GetRvd145LastQuery, Rvd145Dto?>
   {
      public GetRvd145LastHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<Rvd145Dto?> Handle(GetRvd145LastQuery request, CancellationToken cancellationToken)
      {
         return await _uow.Rvd145
            .AsNoTracking()
            .Include(x => x.Device)
            .Where(x => x.DeviceId == request.DeviceId)
            .OrderByDescending(x => x.Date)
            .ProjectTo<Rvd145Dto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
      }
   }
}
