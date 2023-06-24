using System.Collections.Generic;
using MediatR;
using Phoenix.Models.Locations.Dto;

namespace Phoenix.Models.Locations.Queries
{
   public sealed class GetLocationHistoryQuery : IRequest<IReadOnlyCollection<LocationHistoryDto>>
   {
      public int LocationId { get; init; }
   }
}
