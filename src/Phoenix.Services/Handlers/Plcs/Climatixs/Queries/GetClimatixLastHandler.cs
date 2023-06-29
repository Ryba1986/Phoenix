using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Models.Plcs.Climatixs.Dto;
using Phoenix.Models.Plcs.Climatixs.Queries;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Handlers.Plcs.Climatixs.Queries
{
   internal sealed class GetClimatixLastHandler : QueryHandlerBase, IRequestHandler<GetClimatixLastQuery, ClimatixDto?>
   {
      public GetClimatixLastHandler(UnitOfWork uow, IMapper mapper) : base(uow, mapper)
      {
      }

      public async Task<ClimatixDto?> Handle(GetClimatixLastQuery request, CancellationToken cancellationToken)
      {
         return await _uow.Climatix
            .AsNoTracking()
            .Include(x => x.Device)
            .Where(x => x.DeviceId == request.DeviceId)
            .OrderByDescending(x => x.Date)
            .ProjectTo<ClimatixDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
      }
   }
}
