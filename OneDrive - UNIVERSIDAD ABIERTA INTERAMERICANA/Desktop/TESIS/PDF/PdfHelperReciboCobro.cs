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
    public class PdfHelperReciboCobro
    {
        public static byte[] GenerarPdfCobro(BeCobro cobro)
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
                    new Phrase("R", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 36)),
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

                Paragraph titulo = new Paragraph("RECIBO", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
                titulo.Alignment = Element.ALIGN_RIGHT;
                celdaDer.AddElement(titulo);

                Paragraph datosCobro = new Paragraph(
                    $"N° {cobro.IdCobro1.ToString("D4")}\n{DateTime.Now:dd/MM/yyyy}",
                    FontFactory.GetFont(FontFactory.HELVETICA, 10));
                datosCobro.Alignment = Element.ALIGN_RIGHT;
                celdaDer.AddElement(datosCobro);

                cabecera.AddCell(celdaIzq);
                cabecera.AddCell(celdaDer);
                document.Add(cabecera);

                document.Add(new Paragraph(" "));

                
                PdfPTable tabla = new PdfPTable(2);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 30, 70 });
                tabla.SpacingBefore = 20;

                tabla.AddCell(Celda("ID Cobro:", true));
                tabla.AddCell(Celda(cobro.IdCobro1.ToString()));
                tabla.AddCell(Celda("ID Factura:", true));
                tabla.AddCell(Celda(cobro.IdFactura1.ToString()));
                tabla.AddCell(Celda("Método de Pago:", true));
                tabla.AddCell(Celda(cobro.Metodo1));
                tabla.AddCell(Celda("Importe Cobrado:", true));
                tabla.AddCell(Celda(cobro.Cobro1.ToString("C")));

                document.Add(tabla);

                
                document.Add(new Paragraph("\n\n"));

                
                Paragraph total = new Paragraph("TOTAL RECIBIDO: " + cobro.Cobro1.ToString("C"),
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
