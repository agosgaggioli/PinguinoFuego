using BE;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF
{
    public class PdfHelperReciboPago
    {
        public static byte[] GenerarPdfPago(BePago pago)
        {
            using (var ms = new MemoryStream())
            {
                var document = new Document(PageSize.A4, 20, 20, 20, 20);
                var writer = PdfWriter.GetInstance(document, ms);
                document.Open();

                var cb = writer.DirectContent;

                
                float cuadroX = (PageSize.A4.Width - 50) / 2;
                float cuadroY = 770;

                cb.SetLineWidth(1f);
                cb.Rectangle(cuadroX, cuadroY, 50, 50);
                cb.Stroke();

                ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER,
                    new Phrase("P", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 36)),
                    cuadroX + 25, cuadroY + 12, 0);

                document.Add(new Paragraph("\n\n\n\n"));

                
                PdfPTable cabecera = new PdfPTable(2);
                cabecera.WidthPercentage = 100;
                cabecera.SetWidths(new float[] { 60, 40 });

                
                PdfPCell celdaIzq = new PdfPCell { Border = Rectangle.NO_BORDER };

                if (File.Exists("logo.png"))
                {
                    Image logo = Image.GetInstance("logo.png");
                    logo.ScaleAbsolute(100, 50);
                    logo.Alignment = Element.ALIGN_LEFT;
                    celdaIzq.AddElement(logo);
                }

                Paragraph datosEmpresa = new Paragraph(
                    "DEGRA AUTOMOTORES\nCUIT: 30-12345678-9\nDirección: Calle 123\nTel: (011) 1234-5678",
                    FontFactory.GetFont(FontFactory.HELVETICA, 9));
                celdaIzq.AddElement(datosEmpresa);

                
                PdfPCell celdaDer = new PdfPCell { Border = Rectangle.NO_BORDER };
                celdaDer.HorizontalAlignment = Element.ALIGN_RIGHT;

                Paragraph titulo = new Paragraph("COMPROBANTE DE PAGO", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                titulo.Alignment = Element.ALIGN_RIGHT;
                celdaDer.AddElement(titulo);

                Paragraph datosPago = new Paragraph(
                    $"N° {pago.IdPago1.ToString("D4")}\n{DateTime.Now:dd/MM/yyyy}",
                    FontFactory.GetFont(FontFactory.HELVETICA, 10));
                datosPago.Alignment = Element.ALIGN_RIGHT;
                celdaDer.AddElement(datosPago);

                cabecera.AddCell(celdaIzq);
                cabecera.AddCell(celdaDer);
                document.Add(cabecera);

                document.Add(new Paragraph(" "));

                
                PdfPTable tabla = new PdfPTable(2);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 30, 70 });
                tabla.SpacingBefore = 20;

                tabla.AddCell(Celda("ID Pago:", true));
                tabla.AddCell(Celda(pago.IdPago1.ToString()));
                tabla.AddCell(Celda("ID Detalle:", true));
                tabla.AddCell(Celda(pago.IdDetalle1.ToString()));
                tabla.AddCell(Celda("Método de Pago:", true));
                tabla.AddCell(Celda(pago.Metodo1));
                tabla.AddCell(Celda("Importe Pagado:", true));
                tabla.AddCell(Celda(pago.Pago1.ToString("C")));
                tabla.AddCell(Celda("Proveedor:", true));
              

                document.Add(tabla);

                document.Add(new Paragraph("\n\n"));

                Paragraph total = new Paragraph("TOTAL PAGADO: " + pago.Pago1.ToString("C"),
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14));
                total.Alignment = Element.ALIGN_RIGHT;
                document.Add(total);

                Paragraph firma = new Paragraph("\n\n.................................................\nFirma y Aclaración",
                    FontFactory.GetFont(FontFactory.HELVETICA, 10));
                firma.Alignment = Element.ALIGN_LEFT;
                document.Add(firma);

                document.Close();
                return ms.ToArray();
            }
        }

        private static PdfPCell Celda(string texto, bool negrita = false)
        {
            var font = FontFactory.GetFont(FontFactory.HELVETICA, 11, negrita ? Font.BOLD : Font.NORMAL);
            PdfPCell celda = new PdfPCell(new Phrase(texto, font));
            celda.Padding = 5;
            return celda;
        }
    }
}
