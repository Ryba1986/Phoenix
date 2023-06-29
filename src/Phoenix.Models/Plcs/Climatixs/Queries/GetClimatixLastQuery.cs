using MediatR;
using Phoenix.Models.Base.Queries;
using Phoenix.Models.Plcs.Climatixs.Dto;

namespace Phoenix.Models.Plcs.Climatixs.Queries
{
   public sealed class GetClimatixLastQuery : GetPlcLastQueryBase, IRequest<ClimatixDto?>
   {
   }
}
