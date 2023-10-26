using System;
using System.Linq.Expressions;
using Phoenix.Entities.Base;
using Phoenix.Models.Plcs;

namespace Phoenix.Services.Reports.Base
{
   internal interface ITypeProcessor
   {
      ushort DeviceNameRow { get; }
      ushort LegendRow { get; }
      ushort RemoveTemplateRowCount { get; }
      ushort StartingRow { get; }

      int GetDatePart(DateTime date);
      string GetFileName(DateOnly date);
      string GetHeader(string locationName, DateOnly date);
      string GetLegend();
      Expression<Func<T, PlcGroupBy>> GetPlcGroup<T>() where T : PlcBase;
      Tuple<DateTime, DateTime> GetRange(DateOnly date);
   }
}
