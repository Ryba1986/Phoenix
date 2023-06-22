using System.Security.Cryptography;

namespace Phoenix.Shared.Helpers
{
   public static class RandomHelper
   {
      public static int NewInt()
      {
         return RandomNumberGenerator.GetInt32(default, int.MaxValue);
      }

      public static short NewShort()
      {
         return (short)RandomNumberGenerator.GetInt32(default, short.MaxValue);
      }
   }
}
