using System;

namespace Phoenix.Shared.Extensions
{
   public static class FloatExtensions
   {
      public static float Round(this float value, byte digits = 1)
      {
         return MathF.Round(value, digits);
      }
   }
}
