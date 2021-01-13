using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using ToDoList.Business.Interfaces;

namespace ToDoList.Business.Concrete
{
    public class FileManager : IFileService
    {
        public byte[] ExportExcel<T>(List<T> list) where T : class, new()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var excelPackage = new ExcelPackage();
            var excelBlank = excelPackage.Workbook.Worksheets.Add("Sheet1");

            excelBlank.Cells["A1"].LoadFromCollection(list, true, OfficeOpenXml.Table.TableStyles.Light15);

            return excelPackage.GetAsByteArray();
        }

        public string ExportPdf<T>(List<T> list) where T : class, new()
        {
            DataTable dt = new DataTable();
            dt.Load(ObjectReader.Create(list));
            var fileName = Guid.NewGuid() + ".pdf";
            var returnPath = "/documents/" + fileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/" + fileName);

            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(dt.Columns.Count);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                pdfPTable.AddCell(dt.Columns[i].ColumnName);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    pdfPTable.AddCell(dt.Rows[i][j].ToString());
                }
            }
            document.Add(pdfPTable);
            document.Close();

            return returnPath;
        }
    }
}
