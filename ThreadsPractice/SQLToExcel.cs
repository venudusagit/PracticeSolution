using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace ThreadsPractice
{
    public class SQLToExcel
    {
        private static Workbook mWorkBook;
        private static Sheets mWorkSheets;
        private static Worksheet SQLtoExcelSheet;
        private static Application oXL;

        public void ReadExistingExcel()
        {
            string path = @"D:\VENU DATA\Tutorials\Files\Venugopal.D_Tax_Sheet.xls";
            oXL = new Application();
            oXL.Visible = true;
            oXL.DisplayAlerts = false;
            mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Get all the sheets in the workbook
            mWorkSheets = mWorkBook.Worksheets;
            //Get the allready exists sheet
            SQLtoExcelSheet = (Worksheet)mWorkSheets.get_Item("SQLtoExcel");
            Range range = SQLtoExcelSheet.UsedRange;
            int colCount = range.Columns.Count;
            int rowCount = range.Rows.Count;
            for (int index = 1; index < 15; index++)
            {
                SQLtoExcelSheet.Cells[rowCount + index, 1] = rowCount + index;
                SQLtoExcelSheet.Cells[rowCount + index, 2] = "New Item" + index;
            }
            mWorkBook.SaveAs(path, XlFileFormat.xlWorkbookNormal,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value, XlSaveAsAccessMode.xlExclusive,
            Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value);
            mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
            SQLtoExcelSheet = null;
            mWorkBook = null;
            oXL.Quit();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
