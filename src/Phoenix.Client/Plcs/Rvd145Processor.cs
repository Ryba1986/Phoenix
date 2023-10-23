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
using Phoenix.Shared.Enums.Devices;
using Phoenix.Shared.Extensions;

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

         return new CreateRvd145Command()
         {
            Date = DateTime.Now.RoundToSecond(),
            DeviceId = device.Id,

            OutsideTemp = (short)holdingRegisters1[44] / 64f,
            ChHighInletPresure = (short)holdingRegisters1[53] / 50f,
            Alarm = (short)holdingRegisters1[31],

            Ch1HighOutletTemp = device.DeviceType == DeviceType.Heating ? (short)holdingRegisters1[48] / 64f : default,
            Ch1LowInletTemp = device.DeviceType == DeviceType.Heating ? (short)holdingRegisters1[45] / 64f : default,
            Ch1LowOutletPresure = device.DeviceType == DeviceType.Heating ? (short)holdingRegisters1[52] / 50f : default,
            Ch1HeatCurveTemp = device.DeviceType == DeviceType.Heating ? (short)holdingRegisters1[66] / 64f : default,
            Ch1PumpStatus = device.DeviceType == DeviceType.Heating && (short)holdingRegisters1[36] != 0,
            Ch1Status = device.DeviceType == DeviceType.Heating && (short)holdingRegisters2[10] == 1,

            DhwTemp = device.DeviceType == DeviceType.HeatingDomestic ? (short)holdingRegisters1[46] / 64f : default,
            DhwTempSet = device.DeviceType == DeviceType.HeatingDomestic ? (short)holdingRegisters1[58] / 64f : default,
            DhwCirculationTemp = device.DeviceType == DeviceType.HeatingDomestic ? (short)holdingRegisters1[49] / 64f : default,
            DhwPumpStatus = device.DeviceType == DeviceType.HeatingDomestic && (short)holdingRegisters1[40] != 0,
            DhwStatus = device.DeviceType == DeviceType.HeatingDomestic && (short)holdingRegisters2[41] == 1,
         };
      }
   }
}
