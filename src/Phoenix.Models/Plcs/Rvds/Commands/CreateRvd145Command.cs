using Phoenix.Models.Base.Commands;

namespace Phoenix.Models.Plcs.Rvds.Commands
{
   public sealed class CreateRvd145Command : CreatePlcCommandBase
   {
      public float OutsideTemp { get; init; }
      public float ChHighInletPresure { get; init; }
      public short Alarm { get; init; }

      public float Ch1HighOutletTemp { get; init; }
      public float Ch1LowInletTemp { get; init; }
      public float Ch1LowOutletPresure { get; init; }
      public float Ch1HeatCurveTemp { get; init; }
      public bool Ch1PumpStatus { get; init; }
      public byte Ch1Status { get; init; }

      public float DhwTemp { get; init; }
      public float DhwTempSet { get; init; }
      public float DhwCirculationTemp { get; init; }
      public bool DhwPumpStatus { get; init; }
      public byte DhwStatus { get; init; }
   }
}
