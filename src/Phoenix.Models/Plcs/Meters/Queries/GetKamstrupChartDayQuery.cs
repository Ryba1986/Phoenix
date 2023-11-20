using System.Collections.Generic;
using MediatR;
using Phoenix.Models.Base.Queries;
using Phoenix.Models.Plcs.Meters.Dto;

namespace Phoenix.Models.Plcs.Meters.Queries
{
   public sealed class GetKamstrupChartDayQuery : GetPlcChartQueryBase, IRequest<IReadOnlyCollection<KamstrupChartDto>>
   {
   }
}
