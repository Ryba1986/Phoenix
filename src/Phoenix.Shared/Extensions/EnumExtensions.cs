using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Phoenix.Shared.Extensions
{
   public static class EnumExtensions
   {
      public static string GetDescription(this Enum value)
      {
         return value
            .GetType()
            .GetField(value.ToString())?
            .GetCustomAttributes<DescriptionAttribute>(false)
            .FirstOrDefault()?
            .Description ?? string.Empty;
      }

      public static int GetKey(this Enum value)
      {
         return Convert.ToInt32(value);
      }

      public static IEnumerable<KeyValuePair<int, string>> GetValues<T>(bool skipDefault = false) where T : struct, Enum
      {
         IEnumerable<KeyValuePair<int, string>> query = Enum
            .GetValues<T>()
            .Select(x => new KeyValuePair<int, string>(Convert.ToInt32(x), x.GetDescription()));

         if (skipDefault)
         {
            query = query.Where(x => x.Key != default);
         }

         return query;
      }
   }
}
