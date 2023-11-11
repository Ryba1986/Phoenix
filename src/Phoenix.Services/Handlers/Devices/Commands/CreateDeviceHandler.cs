using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Devices;
using Phoenix.Models.Devices.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Devices.Commands
{
   internal sealed class CreateDeviceHandler : HandlerBase, IRequestHandler<CreateDeviceCommand, Result>
   {
      public CreateDeviceHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
      {
         if (!await IsActiveUserAsync(request.CreatedById, cancellationToken))
         {
            return Result.Error(Translations.User_Active_NotExists);
         }

         bool locationExists = await _uow.Location
            .AsNoTracking()
            .AnyAsync(x => x.Id == request.LocationId, cancellationToken);

         if (!locationExists)
         {
            return Result.Error(Translations.Location_NotExists);
         }

         bool deviceExists = await _uow.Device
            .AsNoTracking()
            .AnyAsync(x =>
               x.LocationId == request.LocationId &&
               (x.Name == request.Name || x.ModbusId == request.ModbusId || x.Sequence == request.Sequence)
            , cancellationToken);

         if (deviceExists)
         {
            return Result.Error(Translations.Device_Exists);
         }

         Device newDevice = new()
         {
            LocationId = request.LocationId,
            Name = request.Name,
            PlcType = request.PlcType,
            ModbusId = request.ModbusId,
            BoundRate = request.BoundRate,
            DataBits = request.DataBits,
            Parity = request.Parity,
            StopBits = request.StopBits,
            Sequence = request.Sequence,
            IncludeReport = request.IncludeReport,
            IsActive = request.IsActive,
         };

         _uow.Device.Add(newDevice);
         _uow.DeviceHistory.Add(new()
         {
            Device = newDevice,
            LocationId = request.LocationId,
            Name = request.Name,
            PlcType = request.PlcType,
            ModbusId = request.ModbusId,
            BoundRate = request.BoundRate,
            DataBits = request.DataBits,
            Parity = request.Parity,
            StopBits = request.StopBits,
            Sequence = request.Sequence,
            IncludeReport = request.IncludeReport,
            IsActive = request.IsActive,
            CreatedById = request.CreatedById,
            CreateDate = GetServerDate(),
         });

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
