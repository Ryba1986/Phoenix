using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using Phoenix.Shared.Enums.Reports;

namespace Phoenix.Services.Extensions
{
   internal static class ExcelExtensions
   {
      public static IXLWorkbook GetReportTemplate()
      {
         string templatePath = $"{AppContext.BaseDirectory}Reports{Path.DirectorySeparatorChar}Templates{Path.DirectorySeparatorChar}PlcReport_{CultureInfo.CurrentCulture.Name}.xlsx";

         return new XLWorkbook(templatePath)
         {
            Author = nameof(Phoenix),
            CalculationOnSave = true,
         };
      }

      public static IEnumerable<string> GetSheetNames(this IXLWorksheets sheets)
      {
         return sheets.Select(x => x.Name);
      }

      public static IXLWorksheet CloneSheet(this IXLWorksheets sheets, ReportType type, string newSheetName)
      {
         return sheets
            .First(x => x.Name == type.ToString())
            .CopyTo(newSheetName);
      }

      public static void RemoveSheets(this IXLWorksheets sheets, IEnumerable<string> sheetNames)
      {
         foreach (string name in sheetNames)
         {
            sheets.Delete(name);
         }
         if (sheets.Count == 0)
         {
            sheets.Add("NO DATA");
         }
      }
   }
}
