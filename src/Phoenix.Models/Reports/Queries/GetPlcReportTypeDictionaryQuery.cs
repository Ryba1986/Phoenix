using System.Collections.Generic;
using MediatR;

namespace Phoenix.Models.Reports.Queries
{
   public sealed class GetPlcReportTypeDictionaryQuery : IRequest<IReadOnlyCollection<KeyValuePair<int, string>>>
   {
   }
}
