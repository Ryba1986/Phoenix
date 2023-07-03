using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using NModbus;
using NModbus.Serial;
using Phoenix.Client.Plcs.Base;
using Phoenix.Client.Settings;
using Phoenix.Models.Base.Commands;
using Phoenix.Models.Devices.Dto;
using Phoenix.Models.Plcs.Rvds.Commands;
using Phoenix.Shared.Enums.Devices;

namespace Phoenix.Client.Plcs.Rvds
{
   internal sealed class Rvd145Processor : PlcProcessorBase, IPlcProcessor
   {
      public Rvd145Processor(IModbusFactory factory, PhoenixSettings settings) : base(factory, settings)
      {
      }

      public async Task<CreatePlcCommandBase> GetPlcAsync(DeviceDto device, CancellationToken cancellationToken)
      {
         using SerialPort port = GetSerialPort(device);
         port.Open();

         using IModbusSerialMaster master = _factory.CreateRtuMaster(port);

         IReadOnlyList<ushort> table1 = await master.ReadHoldingRegistersAsync(device.ModbusId, 1000, 70);
         IReadOnlyList<ushort> table2 = await master.ReadHoldingRegistersAsync(device.ModbusId, 200, 45);

         return new CreateRvd145Command()
         {
            DeviceId = device.Id,

            OutsideTemp = (short)table1[44] / 64f,
            ChHighInletPresure = (short)table1[53] / 50f,
            Alarm = (short)table1[31],

            Ch1HighOutletTemp = device.DeviceType == DeviceType.Heating ? (short)table1[48] / 64f : default,
            Ch1LowInletTemp = device.DeviceType == DeviceType.Heating ? (short)table1[45] / 64f : default,
            Ch1LowOutletPresure = device.DeviceType == DeviceType.Heating ? (short)table1[52] / 50f : default,
            Ch1HeatCurveTemp = device.DeviceType == DeviceType.Heating ? (short)table1[66] / 64f : default,
            Ch1PumpStatus = device.DeviceType == DeviceType.Heating && (short)table1[36] != 0,
            Ch1Status = device.DeviceType == DeviceType.Heating && (short)table2[10] == 1,

            DhwTemp = device.DeviceType == DeviceType.HeatingDomestic ? (short)table1[46] / 64f : default,
            DhwTempSet = device.DeviceType == DeviceType.HeatingDomestic ? (short)table1[58] / 64f : default,
            DhwCirculationTemp = device.DeviceType == DeviceType.HeatingDomestic ? (short)table1[49] / 64f : default,
            DhwPumpStatus = device.DeviceType == DeviceType.HeatingDomestic && (short)table1[40] != 0,
            DhwStatus = device.DeviceType == DeviceType.HeatingDomestic && (short)table2[41] == 1,
         };
      }
   }
}
