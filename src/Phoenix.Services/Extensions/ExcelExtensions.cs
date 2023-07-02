using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using Phoenix.Shared.Enums.Reports;

namespace Phoenix.Services.Extensions
{
   internal static class ExcelExtensions
   {
      public static ExcelPackage GetReportTemplate()
      {
         string templatePath = $"{AppContext.BaseDirectory}Reports{Path.DirectorySeparatorChar}Templates{Path.DirectorySeparatorChar}PlcReport_{CultureInfo.CurrentCulture.Name}.xlsx";

         return new ExcelPackage(new(templatePath), true);
      }

      public static IEnumerable<string> GetSheetNames(this ExcelWorksheets sheets)
      {
         return sheets.Select(x => x.Name);
      }

      public static ExcelWorksheet CloneSheet(this ExcelWorksheets sheets, ReportType type, string newSheetName)
      {
         return sheets.Copy(type.ToString(), newSheetName);
      }

      public static void RemoveSheets(this ExcelWorksheets sheets, IEnumerable<string> sheetNames)
      {
         foreach (string name in sheetNames)
         {
            sheets.Delete(name);
         }
         if (sheets.Count == 0)
         {
            sheets.Add("NO DATA");
         }

         sheets.First().Select();
      }
   }
}
