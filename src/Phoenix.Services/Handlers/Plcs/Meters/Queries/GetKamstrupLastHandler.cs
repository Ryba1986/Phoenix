using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Plcs.Meters.Dto;
using Phoenix.Models.Plcs.Meters.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Meters.Queries
{
   internal sealed class GetKamstrupLastHandler : QueryHandlerBase, IRequestHandler<GetKamstrupLastQuery, KamstrupDto?>
   {
      public GetKamstrupLastHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<KamstrupDto?> Handle(GetKamstrupLastQuery request, CancellationToken cancellationToken)
      {
         return await _uow.Kamstrup
            .AsNoTracking()
            .Include(x => x.Device)
            .Where(x => x.DeviceId == request.DeviceId)
            .OrderByDescending(x => x.Date)
            .ProjectTo<KamstrupDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
      }
   }
}
