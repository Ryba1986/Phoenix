using System.Security.Cryptography;

namespace Phoenix.Shared.Helpers
{
   public static class RandomHelper
   {
      public static short NewShort()
      {
         return (short)RandomNumberGenerator.GetInt32(short.MinValue, short.MaxValue);
      }
   }
}
