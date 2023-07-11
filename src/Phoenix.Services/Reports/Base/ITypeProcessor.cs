using System;
using System.Linq.Expressions;
using Phoenix.Entities.Base;
using Phoenix.Models.Utilities;
using Phoenix.Shared.Enums.Reports;

namespace Phoenix.Services.Reports.Base
{
   internal interface ITypeProcessor
   {
      ushort DeviceNameRow { get; }
      ushort RemoveTemplateRowCount { get; }
      ushort StartingRow { get; }
      ReportType Type { get; }

      int GetDatePart(DateTime date);
      string GetFileName(DateOnly date);
      string GetHeader(string locationName, DateOnly date);
      string GetLegend();
      Expression<Func<T, PlcGroupBy>> GetPlcGroup<T>() where T : PlcBase;
      DateRange GetRange(DateOnly date);
   }
}
