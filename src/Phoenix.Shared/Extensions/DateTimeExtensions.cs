using System;

namespace Phoenix.Shared.Extensions
{
   public static class DateTimeExtensions
   {
      public static DateTime RoundToSecond(this DateTime date)
      {
         return new(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind);
      }
   }
}
