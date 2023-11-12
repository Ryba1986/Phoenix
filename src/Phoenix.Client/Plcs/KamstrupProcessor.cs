using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using NModbus;
using NModbus.Serial;
using NModbus.Utility;
using Phoenix.Client.Plcs.Base;
using Phoenix.Client.Settings;
using Phoenix.Models.Base.Commands;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Plcs.Meters.Commands;

namespace Phoenix.Client.Plcs
{
   internal sealed class KamstrupProcessor : PlcProcessorBase, IPlcProcessor
   {
      public KamstrupProcessor(IModbusFactory factory, PhoenixSettings settings) : base(factory, settings)
      {
      }

      public async Task<CreatePlcCommandBase> GetPlcAsync(DeviceDto device, CancellationToken cancellationToken)
      {
         using SerialPort port = GetSerialPort(device);
         port.Open();

         using IModbusSerialMaster master = _factory.CreateRtuMaster(port);

         IReadOnlyList<ushort> inputRegisters0 = await master.ReadInputRegistersAsync(device.ModbusId, 0, 86);

         float power = ModbusUtility.GetSingle(inputRegisters0[7], inputRegisters0[6]);
         float volume = ModbusUtility.GetSingle(inputRegisters0[3], inputRegisters0[2]);

         return new CreateKamstrupCommand()
         {
            DeviceId = device.Id,
            Date = DateTime.Now,

            InletTemp = ModbusUtility.GetSingle(inputRegisters0[9], inputRegisters0[8]),
            OutletTemp = ModbusUtility.GetSingle(inputRegisters0[11], inputRegisters0[10]),
            Power = inputRegisters0[19] == 2 ? power * 1000f : power,
            Volume = inputRegisters0[18] == 49 ? volume / 1000f : volume,
            VolumeSummary = ModbusUtility.GetSingle(inputRegisters0[5], inputRegisters0[4]),
            EnergySummary = ModbusUtility.GetSingle(inputRegisters0[1], inputRegisters0[0]),

            HourCount = (int)ModbusUtility.GetUInt32(inputRegisters0[84], inputRegisters0[85]),
            SerialNumber = ModbusUtility.GetUInt32(inputRegisters0[76], inputRegisters0[77]).ToString(),
            ErrorCode = (short)inputRegisters0[43],
         };
      }
   }
}
