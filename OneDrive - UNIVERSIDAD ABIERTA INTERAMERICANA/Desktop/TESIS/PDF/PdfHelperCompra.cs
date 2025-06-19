
using BE;
using iTextSharp.text.pdf;
using System.Reflection.Metadata;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace PDF
{
    public class PdfHelperCompra
    {
    
            public static byte[] GenerarPdfDetalle(BeDetalleCompra detalle)
            {
            using (MemoryStream ms = new MemoryStream())
            {
                var doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 40f, 40f, 40f, 40f);
                PdfWriter.GetInstance(doc, ms);
                doc.Open();

                
                string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo.png"); 
                if (File.Exists(logoPath))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoPath);
                    logo.ScaleToFit(100f, 100f);
                    logo.Alignment = Element.ALIGN_CENTER;
                    doc.Add(logo);
                }

                
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
                Paragraph title = new Paragraph("DETALLE DE COMPRA", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20f
                };
                doc.Add(title);

               
                Font labelFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                Font valueFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SpacingBefore = 10f;

                
                table.AddCell(new Phrase("ID Detalle:", labelFont));
                table.AddCell(new Phrase(detalle.IdDetalle1.ToString(), valueFont));

                table.AddCell(new Phrase("ID Compra:", labelFont));
                table.AddCell(new Phrase(detalle.IdCompra1.ToString(), valueFont));

                table.AddCell(new Phrase("Fecha:", labelFont));
                table.AddCell(new Phrase(detalle.Fecha.ToString("dd/MM/yyyy HH:mm"), valueFont));

                table.AddCell(new Phrase("Descripción:", labelFont));
                table.AddCell(new Phrase(detalle.Descripcion1, valueFont));

                table.AddCell(new Phrase("Monto:", labelFont));
                table.AddCell(new Phrase($"${detalle.Monto1:N0}", valueFont));

                table.AddCell(new Phrase("Proveedor:", labelFont));
                table.AddCell(new Phrase(detalle.RazonSocialProveedor1, valueFont));

                doc.Add(table);

                doc.Close();
                return ms.ToArray();
            }

        }
    }
}
