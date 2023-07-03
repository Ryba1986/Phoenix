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

namespace Phoenix.Client.Plcs.Meters
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

         IReadOnlyList<ushort> table = await master.ReadInputRegistersAsync(device.ModbusId, 0, 86);

         float power = ModbusUtility.GetSingle(table[7], table[6]);
         float volume = ModbusUtility.GetSingle(table[3], table[2]);

         return new CreateKamstrupCommand()
         {
            DeviceId = device.Id,

            InletTemp = ModbusUtility.GetSingle(table[9], table[8]),
            OutletTemp = ModbusUtility.GetSingle(table[11], table[10]),
            Power = table[19] == 2 ? power * 1000f : power,
            Volume = table[18] == 49 ? volume / 1000f : volume,
            VolumeSummary = ModbusUtility.GetSingle(table[5], table[4]),
            EnergySummary = ModbusUtility.GetSingle(table[1], table[0]),

            HourCount = (int)ModbusUtility.GetUInt32(table[84], table[85]),
            SerialNumber = ModbusUtility.GetUInt32(table[76], table[77]).ToString(),
            ErrorCode = (short)table[43],
         };
      }
   }
}
