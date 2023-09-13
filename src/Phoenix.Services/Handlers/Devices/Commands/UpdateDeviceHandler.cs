using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Phoenix.Entities.Devices;
using Phoenix.Models.Devices.Commands;
using Phoenix.Services.Handlers.Base;
using Phoenix.Services.Repositories;
using Phoenix.Shared.Enums.Devices;
using Phoenix.Shared.Languages;
using Phoenix.Shared.Results;

namespace Phoenix.Services.Handlers.Devices.Commands
{
   internal sealed class UpdateDeviceHandler : HandlerBase, IRequestHandler<UpdateDeviceCommand, Result>
   {
      public UpdateDeviceHandler(UnitOfWork uow) : base(uow)
      {
      }

      public async Task<Result> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
      {
         if (request.DeviceType == DeviceType.Meter && request.PlcType != PlcType.Kamstrup)
         {
            return Result.Error(Translations.Device_DeviceType_Invalid);
         }
         if (request.DeviceType != DeviceType.Meter && request.PlcType == PlcType.Kamstrup)
         {
            return Result.Error(Translations.Device_DeviceType_Invalid);
         }

         if (!await IsActiveUserExistsAsync(request.ModifiedById, cancellationToken))
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

         bool otherExists = await _uow.Device
            .AsNoTracking()
            .AnyAsync(x =>
               x.LocationId == request.LocationId &&
               (x.Name == request.Name || x.ModbusId == request.ModbusId) &&
               x.Id != request.Id
            , cancellationToken);

         if (otherExists)
         {
            return Result.Error(Translations.Device_Exists);
         }

         Device? device = await _uow.Device.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
         if (device is null)
         {
            return Result.Error(Translations.Device_NotExists);
         }
         if (!device.Version.SequenceEqual(request.Version))
         {
            return Result.Error(Translations.Validator_Version_Invalid);
         }
         if (device.LocationId == request.LocationId && device.Name == request.Name && device.DeviceType == request.DeviceType && device.PlcType == request.PlcType && device.ModbusId == request.ModbusId && device.BoundRate == request.BoundRate && device.DataBits == request.DataBits && device.Parity == request.Parity && device.StopBits == request.StopBits && device.IncludeReport == request.IncludeReport && device.ReportSequence == request.ReportSequence && device.IsActive == request.IsActive)
         {
            return Result.Success();
         }

         _uow.DeviceHistory.Add(new()
         {
            DeviceId = request.Id,
            LocationId = device.LocationId != request.LocationId ? request.LocationId : null,
            Name = device.Name != request.Name ? request.Name : string.Empty,
            DeviceType = device.DeviceType != request.DeviceType ? request.DeviceType : null,
            PlcType = device.PlcType != request.PlcType ? request.PlcType : null,
            ModbusId = device.ModbusId != request.ModbusId ? request.ModbusId : null,
            BoundRate = device.BoundRate != request.BoundRate ? request.BoundRate : null,
            DataBits = device.DataBits != request.DataBits ? request.DataBits : null,
            Parity = device.Parity != request.Parity ? request.Parity : null,
            StopBits = device.StopBits != request.StopBits ? request.StopBits : null,
            IncludeReport = request.IncludeReport,
            ReportSequence = device.ReportSequence != request.ReportSequence ? request.ReportSequence : null,
            IsActive = request.IsActive,
            CreatedById = request.ModifiedById,
            CreateDate = await GetServerDateAsync(),
         });

         device.LocationId = request.LocationId;
         device.Name = request.Name;
         device.DeviceType = request.DeviceType;
         device.PlcType = request.PlcType;
         device.ModbusId = request.ModbusId;
         device.BoundRate = request.BoundRate;
         device.DataBits = request.DataBits;
         device.Parity = request.Parity;
         device.StopBits = request.StopBits;
         device.IncludeReport = request.IncludeReport;
         device.ReportSequence = request.ReportSequence;
         device.IsActive = request.IsActive;

         await _uow.SaveChangesAsync(cancellationToken);
         return Result.Success();
      }
   }
}
