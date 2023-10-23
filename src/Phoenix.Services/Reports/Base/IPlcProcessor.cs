using System;
using System.Threading;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Phoenix.Services.Reports.Base
{
   internal interface IPlcProcessor
   {
      string TemplateSheetName { get; }

      Task FillDataAsync(ExcelWorksheets sheets, DateOnly date, ITypeProcessor typeProcessor, CancellationToken cancellationToken);
   }
}
