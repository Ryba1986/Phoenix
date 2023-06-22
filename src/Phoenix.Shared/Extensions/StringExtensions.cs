using System;
using System.Security.Cryptography;
using System.Text;

namespace Phoenix.Shared.Extensions
{
   public static class StringExtensions
   {
      public static string CreatePassword(this string value)
      {
         ReadOnlySpan<byte> byteArray = Encoding.UTF8.GetBytes(value ?? string.Empty);
         ReadOnlySpan<byte> hash = SHA256.HashData(byteArray);

         return Convert.ToHexString(hash);
      }
   }
}
