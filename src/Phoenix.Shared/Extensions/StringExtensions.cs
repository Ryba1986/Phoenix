using System;
using System.Security.Cryptography;
using System.Text;

namespace Phoenix.Shared.Extensions
{
   public static class StringExtensions
   {
      public static string CreatePassword(this string value)
      {
         return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value ?? string.Empty)));
      }
   }
}
