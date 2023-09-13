using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LiteDB;
using MediatR;
using Phoenix.Client.Extensions;
using Phoenix.Client.Handlers.Base;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Devices.Queries;
using RestSharp;

namespace Phoenix.Client.Handlers.Devices.Queries
{
   internal sealed class GetDevicesByClientHandler : StorageHandlerBase, IRequestHandler<GetDevicesByClientQuery, IReadOnlyCollection<DeviceDto>>
   {
      public GetDevicesByClientHandler(IRestClient client, ILiteRepository repository) : base(client, repository)
      {
      }

      public async Task<IReadOnlyCollection<DeviceDto>> Handle(GetDevicesByClientQuery request, CancellationToken cancellationToken)
      {
         IReadOnlyCollection<DeviceDto>? result = await _client.GetAsync("device/getDevicesByClient", request, cancellationToken);
         if (result is null)
         {
            return _repository
               .Query<DeviceDto>()
               .ToArray();
         }

         UpdateLocalDatabase(result);
         return result;
      }

      private void UpdateLocalDatabase(IReadOnlyCollection<DeviceDto> devices)
      {
         IReadOnlyCollection<string> deviceVersions = devices
            .OrderBy(x => x.Id)
            .Select(x => Convert.ToHexString(x.Version))
            .ToArray();

         IReadOnlyCollection<string> storageVersions = _repository
            .Query<DeviceDto>()
            .OrderBy(x => x.Id)
            .Select(x => x.Version)
            .ToArray()
            .Select(Convert.ToHexString)
            .ToArray();

         if (deviceVersions.SequenceEqual(storageVersions))
         {
            return;
         }

         _repository.DeleteMany<DeviceDto>(x => true);
         _repository.Insert<DeviceDto>(devices);
      }
   }
}
