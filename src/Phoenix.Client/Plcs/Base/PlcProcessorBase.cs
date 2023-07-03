using System.IO.Ports;
using NModbus;
using Phoenix.Client.Settings;
using Phoenix.Models.Devices.Dto;

namespace Phoenix.Client.Plcs.Base
{
   internal abstract class PlcProcessorBase
   {
      protected readonly IModbusFactory _factory;
      private readonly PhoenixSettings _settings;

      protected PlcProcessorBase(IModbusFactory factory, PhoenixSettings settings)
      {
         _factory = factory;
         _settings = settings;
      }

      protected SerialPort GetSerialPort(DeviceDto device)
      {
         return new()
         {
            PortName = _settings.SerialPortName,
            BaudRate = (int)device.BoundRate,
            Parity = (Parity)device.Parity,
            DataBits = (int)device.DataBits,
            StopBits = (StopBits)device.StopBits,

            ReadTimeout = _settings.SerialPortTimeout,
            WriteTimeout = _settings.SerialPortTimeout
         };
      }
   }
}
