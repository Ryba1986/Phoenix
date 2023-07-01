using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Phoenix.Models.Reports.Queries;
using Phoenix.Shared.Enums.Reports;
using Phoenix.Shared.Extensions;

namespace Phoenix.Services.Handlers.Reports.Queries
{
   internal sealed class GetReportTypeDictionaryHandler : IRequestHandler<GetReportTypeDictionaryQuery, IReadOnlyCollection<KeyValuePair<int, string>>>
   {
      public async Task<IReadOnlyCollection<KeyValuePair<int, string>>> Handle(GetReportTypeDictionaryQuery request, CancellationToken cancellationToken)
      {
         return await Task.FromResult(EnumExtensions.GetValues<ReportType>().ToArray());
      }
   }
}
