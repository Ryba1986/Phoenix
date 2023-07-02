using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OfficeOpenXml;
using Phoenix.Models.Devices.Dto;

namespace Phoenix.Services.Reports.Base
{
   internal interface IPlcProcessor
   {
      Task FillDataAsync(ExcelWorksheets sheets, DateOnly date, IReadOnlyCollection<DeviceReportDto> devices, ITypeProcessor typeProcessor, CancellationToken cancellationToken);
   }
}
