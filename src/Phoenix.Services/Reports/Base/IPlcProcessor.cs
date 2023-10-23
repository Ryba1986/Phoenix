using System;
using System.Threading;
using System.Threading.Tasks;
using OfficeOpenXml;
using Phoenix.Services.Repositories;

namespace Phoenix.Services.Reports.Base
{
   internal interface IPlcProcessor
   {
      string TemplateSheetName { get; }

      Task FillDataAsync(UnitOfWork uow, ExcelWorksheets sheets, DateOnly date, ITypeProcessor typeProcessor, CancellationToken cancellationToken);
   }
}
