using System;
using System.Security.Cryptography;

namespace Phoenix.Shared.Helpers
{
   public static class RandomHelper
   {
      public static short GetShort()
      {
         return Convert.ToInt16(RandomNumberGenerator.GetInt32(0, short.MaxValue));
      }
   }
}
