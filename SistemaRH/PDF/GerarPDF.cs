using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

namespace SistemaRH.PDF
{
    public class GerarPDF
    {
        public static byte[] Gerar(DataTable dt)
        {
            var stream = new MemoryStream();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f };
            table.SetWidths(widths);
            table.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase("Funcionário"));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Salário bruto"));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Salário líquido"));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Data de referência"));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Data de pagamento"));
            table.AddCell(cell);

            foreach (DataRow r in dt.Rows)
            {
                table.AddCell(new PdfPCell(new Phrase(r["Funcionário"].ToString())));
                table.AddCell(new PdfPCell(new Phrase(r["Salário bruto"].ToString())));
                table.AddCell(new PdfPCell(new Phrase(r["Salário líquido"].ToString())));
                table.AddCell(new PdfPCell(new Phrase(r["Data de referência"].ToString())));
                table.AddCell(new PdfPCell(new Phrase(r["Data de pagamento"].ToString())));
            }

            document.Add(table);
            document.Close();

            var byteArray = stream.ToArray();

            return byteArray;
        }
    }
}
