using System.Collections.Generic;
using MediatR;

namespace Phoenix.Models.Reports.Queries
{
   public sealed class GetReportTypeDictionaryQuery : IRequest<IReadOnlyCollection<KeyValuePair<int, string>>>
   {
   }
}
