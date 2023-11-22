using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Phoenix.Services.Repositories.Converters
{
   internal sealed class DateTimeConverter : ValueConverter<DateTime, DateTime>
   {
      public DateTimeConverter() : base(x => x.ToUniversalTime(), x => x.ToLocalTime())
      {
      }
   }
}
