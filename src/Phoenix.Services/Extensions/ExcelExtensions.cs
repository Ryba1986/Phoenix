using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace Phoenix.Services.Extensions
{
   internal static class ExcelExtensions
   {
      public static ExcelPackage GetReportTemplate()
      {
         string templatePath = $"{AppContext.BaseDirectory}Reports{Path.DirectorySeparatorChar}Templates{Path.DirectorySeparatorChar}PlcReport_{CultureInfo.CurrentCulture.Name}.xlsx";

         return new ExcelPackage(new(templatePath), true);
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

      public static void RemoveTemplateRows(this ExcelWorksheets sheets, ushort rowCount)
      {
         if (rowCount == 0)
         {
            return;
         }

         foreach (ExcelWorksheet sheet in sheets)
         {
            sheet.DeleteRow(sheet.Dimension.Rows - rowCount, rowCount);
         }
      }
   }
}
