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
         string templatePath = Path.Combine(AppContext.BaseDirectory, "Reports", "Templates", $"PlcReport_{CultureInfo.CurrentCulture.Name}.xlsx");
         return new ExcelPackage(new(templatePath), true);
      }

      public static void RemoveSheets(this ExcelWorksheets sheets, IReadOnlyCollection<string> sheetNames)
      {
         if (sheets.Count == sheetNames.Count)
         {
            sheets.Add("NO DATA");
         }
         foreach (string name in sheetNames)
         {
            sheets.Delete(name);
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
            int rows = sheet.Dimension.Rows;
            if (rowCount >= rows)
            {
               continue;
            }

            sheet.DeleteRow(rows - rowCount, rowCount);
         }
      }
   }
}
