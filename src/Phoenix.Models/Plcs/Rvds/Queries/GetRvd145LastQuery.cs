using MediatR;
using Phoenix.Models.Base.Queries;
using Phoenix.Models.Plcs.Rvds.Dto;

namespace Phoenix.Models.Plcs.Rvds.Queries
{
   public sealed class GetRvd145LastQuery : GetPlcLastQueryBase, IRequest<Rvd145Dto?>
   {
   }
}
