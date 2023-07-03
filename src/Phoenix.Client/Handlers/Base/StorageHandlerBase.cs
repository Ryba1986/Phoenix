using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LiteDB;
using Phoenix.Client.Extensions;
using Phoenix.Models.Base.Commands;
using Phoenix.Shared.Results;
using RestSharp;

namespace Phoenix.Client.Handlers.Base
{
   internal abstract class StorageHandlerBase : HandlerBase
   {
      protected readonly ILiteRepository _repository;

      public StorageHandlerBase(IRestClient client, ILiteRepository repository) : base(client)
      {
         _repository = repository;
      }

      protected async Task<Result> CreatePlcAsync<T>(string url, T plc, CancellationToken cancellationToken) where T : CreatePlcCommandBase
      {
         Result result = await _client.PostAsync(url, plc, cancellationToken);
         if (result.IsSuccess)
         {
            await RestorePlcAsync<T>(url, cancellationToken);
         }
         else
         {
            _repository.Insert(plc);
         }

         return result;
      }

      private async Task RestorePlcAsync<T>(string url, CancellationToken cancellationToken) where T : CreatePlcCommandBase
      {
         IReadOnlyCollection<T> plcs = _repository
            .Query<T>()
            .Limit(100)
            .ToArray();

         foreach (T plc in plcs)
         {
            Result result = await _client.PostAsync(url, plc, cancellationToken);
            if (!result.IsSuccess)
            {
               continue;
            }

            _repository.DeleteMany<T>(x => x.Id == plc.Id);
         }
      }
   }
}
