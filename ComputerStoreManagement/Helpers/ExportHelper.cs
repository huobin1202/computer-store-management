using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace ComputerStoreManagement.Helpers
{
    public static class ExportHelper
    {
        public static void ExportToExcel<T>(IEnumerable<T> data, string filePath, string sheetName = "Sheet1")
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(sheetName);

            // Get properties
            var properties = typeof(T).GetProperties();

            // Add headers
            for (int i = 0; i < properties.Length; i++)
            {
                worksheet.Cell(1, i + 1).Value = properties[i].Name;
                worksheet.Cell(1, i + 1).Style.Font.Bold = true;
            }

            // Add data
            var dataList = data.ToList();
            for (int row = 0; row < dataList.Count; row++)
            {
                for (int col = 0; col < properties.Length; col++)
                {
                    var value = properties[col].GetValue(dataList[row]);
                    worksheet.Cell(row + 2, col + 1).Value = value?.ToString() ?? "";
                }
            }

            // Auto-fit columns
            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(filePath);
        }

        public static void ExportToPdf(string filePath, string title, string content)
        {
            using var writer = new PdfWriter(filePath);
            using var pdf = new PdfDocument(writer);
            using var document = new Document(pdf);

            // Add title
            var titleParagraph = new Paragraph(title)
                .SetFontSize(20)
                .SetBold()
                .SetTextAlignment(TextAlignment.CENTER);
            document.Add(titleParagraph);

            // Add content
            var contentParagraph = new Paragraph(content)
                .SetFontSize(12);
            document.Add(contentParagraph);
        }
    }
}
