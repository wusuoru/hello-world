using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NpoiDemo.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpoiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            string path = @"D:\excel.xlsx";

            if (!File.Exists(path))
            {
                return;
            }

            using (FileStream fs = File.OpenRead(path))
            {
                string extension = Path.GetExtension(path);

                var workbook = program.GetWorkbook(fs, extension);

                // workbook.NumberOfSheets - Sheet的总数
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    ISheet sheet = workbook.GetSheetAt(i);

                    program.OperateRows(sheet);
                }
                fs.Close();
            }

        }
        public IWorkbook GetWorkbook(Stream stream, string extension)
        {
            IWorkbook wk = null;
            if (extension.Equals(".xls"))
            {
                //把xls文件中的数据写入wk中
                wk = new HSSFWorkbook(stream);
            }
            else
            {
                //把xlsx文件中的数据写入wk中
                wk = new XSSFWorkbook(stream);
            }
            return wk;
        }

        private void OperateRows(ISheet sheet)
        {
            // sheet.PhysicalNumberOfRows - 有值的横行总数
            int physicalNumOfRows = sheet.PhysicalNumberOfRows;
            // sheet.FirstRowNum - 第一个有值的横行
            bool isSkipFirstRow = false;
            int firstRowNum = isSkipFirstRow ? sheet.FirstRowNum + 1 : sheet.FirstRowNum;
            for (int i = firstRowNum; i < sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row != null)
                {
                    OperateRowCells(row);
                }
            }
        }

        private void OperateRowCells(IRow row)
        {
            if (row == null)
            {
                return;
            }
            for (int i = row.FirstCellNum; i < row.LastCellNum; i++)
            {
                var cell = row.GetCell(i);
                if (cell != null)
                {
                    string cellStrVal = null;
                    if (cell.CellType == CellType.Formula)
                    {
                        cellStrVal = cell.NumericCellValue.ToString();
                    }
                    else
                    {
                        cellStrVal = cell.ToString();
                    }
                    Console.Write(cellStrVal + " | ");
                }
            }
            Console.WriteLine();
        }
    }
}
