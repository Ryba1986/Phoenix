namespace Phoenix.Client.Settings
{
   internal sealed class PhoenixSettings
   {
      public string ApiUrlBase { get; init; }
      public string TorHostPath { get; init; }
      public ushort PlcRefreshInterval { get; init; }
      public string SerialPortName { get; init; }
      public ushort SerialPortTimeout { get; init; }

      public PhoenixSettings()
      {
         ApiUrlBase = string.Empty;
         TorHostPath = string.Empty;
         SerialPortName = string.Empty;
      }
   }
}
