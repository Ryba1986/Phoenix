namespace Phoenix.Services.Reports.Base
{
   internal abstract class TypeProcessorBase
   {
      public ushort DeviceNameRow { get; }
      public ushort LegendRow { get; }
      public ushort StartingRow { get; }

      public TypeProcessorBase()
      {
         DeviceNameRow = 3;
         LegendRow = 3;
         StartingRow = 8;
      }
   }
}
