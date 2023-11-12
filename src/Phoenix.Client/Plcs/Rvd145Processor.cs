using System;
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

namespace Phoenix.Client.Plcs
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

         IReadOnlyList<ushort> holdingRegisters1 = await master.ReadHoldingRegistersAsync(device.ModbusId, 1000, 70);
         IReadOnlyList<ushort> holdingRegisters2 = await master.ReadHoldingRegistersAsync(device.ModbusId, 200, 45);

         bool ch1Status = holdingRegisters2[10] == 1;
         bool dhwStatus = holdingRegisters2[41] == 1;

         return new CreateRvd145Command()
         {
            DeviceId = device.Id,
            Date = DateTime.Now,

            OutsideTemp = (short)holdingRegisters1[44] / 64f,
            ChHighInletPresure = (short)holdingRegisters1[53] / 50f,
            Alarm = (short)holdingRegisters1[31],

            Ch1HighOutletTemp = ch1Status ? (short)holdingRegisters1[48] / 64f : default,
            Ch1LowInletTemp = ch1Status ? (short)holdingRegisters1[45] / 64f : default,
            Ch1LowOutletPresure = ch1Status ? (short)holdingRegisters1[52] / 50f : default,
            Ch1HeatCurveTemp = ch1Status ? (short)holdingRegisters1[66] / 64f : default,
            Ch1PumpStatus = ch1Status && (short)holdingRegisters1[36] != 0,
            Ch1Status = Convert.ToByte(ch1Status),

            DhwTemp = dhwStatus ? (short)holdingRegisters1[46] / 64f : default,
            DhwTempSet = dhwStatus ? (short)holdingRegisters1[58] / 64f : default,
            DhwCirculationTemp = dhwStatus ? (short)holdingRegisters1[49] / 64f : default,
            DhwPumpStatus = dhwStatus && (short)holdingRegisters1[40] != 0,
            DhwStatus = Convert.ToByte(dhwStatus),
         };
      }
   }
}
