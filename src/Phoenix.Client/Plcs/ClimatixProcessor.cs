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
using Phoenix.Models.Plcs.Climatixs.Commands;
using Phoenix.Shared.Extensions;

namespace Phoenix.Client.Plcs
{
   internal sealed class ClimatixProcessor : PlcProcessorBase, IPlcProcessor
   {
      public ClimatixProcessor(IModbusFactory factory, PhoenixSettings settings) : base(factory, settings)
      {
      }

      public async Task<CreatePlcCommandBase> GetPlcAsync(DeviceDto device, CancellationToken cancellationToken)
      {
         using SerialPort port = GetSerialPort(device);
         port.Open();

         using IModbusSerialMaster master = _factory.CreateRtuMaster(port);

         IReadOnlyList<bool> inputStates = await master.ReadInputsAsync(device.ModbusId, 0, 900);

         IReadOnlyList<ushort> inputRegisters0 = await master.ReadInputRegistersAsync(device.ModbusId, 0, 80);
         IReadOnlyList<ushort> inputRegisters4 = await master.ReadInputRegistersAsync(device.ModbusId, 400, 90);
         IReadOnlyList<ushort> inputRegisters5 = await master.ReadInputRegistersAsync(device.ModbusId, 500, 90);
         IReadOnlyList<ushort> inputRegisters8 = await master.ReadInputRegistersAsync(device.ModbusId, 800, 90);

         IReadOnlyList<ushort> holdingRegisters = await master.ReadHoldingRegistersAsync(device.ModbusId, 800, 20);

         bool ch1Status = inputRegisters4[1 - 1] != 0;
         bool ch2Status = inputRegisters5[1 - 1] != 0;
         bool dhwStatus = inputRegisters8[1 - 1] != 0;

         return new CreateClimatixCommand()
         {
            Date = DateTime.Now.RoundToSecond(),
            DeviceId = device.Id,

            OutsideTemp = inputRegisters0[50 - 1] / 10f,
            ChHighInletPresure = inputRegisters0[77 - 1] / 100f,
            ChHighOutletPresure = inputRegisters0[76 - 1] / 100f,
            Alarm = inputStates[2 - 1] || inputStates[1 - 1],

            Ch1LowInletTemp = ch1Status ? inputRegisters4[50 - 1] / 10f : default,
            Ch1LowOutletTemp = ch1Status ? inputRegisters4[52 - 1] / 10f : default,
            Ch1LowOutletPresure = ch1Status ? inputRegisters4[74 - 1] / 100f : default,
            Ch1HeatCurveTemp = ch1Status ? inputRegisters4[20 - 1] / 10f : default,
            Ch1PumpAlarm = ch1Status && inputStates[430 - 1],
            Ch1PumpStatus = ch1Status && inputStates[492 - 1],
            Ch1ValvePosition = ch1Status ? (byte)inputRegisters4[90 - 1] : default,
            Ch1Status = Convert.ToByte(ch1Status),

            Ch2LowInletTemp = ch2Status ? inputRegisters5[50 - 1] / 10f : default,
            Ch2LowOutletTemp = ch2Status ? inputRegisters5[52 - 1] / 10f : default,
            Ch2LowOutletPresure = ch2Status ? inputRegisters5[74 - 1] / 100f : default,
            Ch2HeatCurveTemp = ch2Status ? inputRegisters5[20 - 1] / 10f : default,
            Ch2PumpAlarm = ch2Status && inputStates[530 - 1],
            Ch2PumpStatus = ch2Status && inputStates[592 - 1],
            Ch2ValvePosition = ch2Status ? (byte)inputRegisters5[90 - 1] : default,
            Ch2Status = Convert.ToByte(ch2Status),

            DhwTemp = dhwStatus ? inputRegisters8[50 - 1] / 10f : default,
            DhwTempSet = dhwStatus ? holdingRegisters[20 - 1] / 10f : default,
            DhwPumpAlarm = dhwStatus && inputStates[830 - 1],
            DhwPumpStatus = dhwStatus && inputStates[891 - 1],
            DhwValvePosition = dhwStatus ? (byte)inputRegisters8[90 - 1] : default,
            DhwStatus = Convert.ToByte(dhwStatus),
         };
      }
   }
}
