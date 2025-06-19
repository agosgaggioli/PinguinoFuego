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
    public class PdfHelperFactura
    {
        public static byte[] GenerarPdfFactura(BeFactura factura)
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
                    new Phrase("X", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 36)),
                    cuadroX + 25, cuadroY + 12, 0); 

                
                document.Add(new Paragraph("\n\n\n\n"));

                
                PdfPTable cabecera = new PdfPTable(2);
                cabecera.WidthPercentage = 100;
                cabecera.SetWidths(new float[] { 60, 40 });

                
                PdfPCell celdaIzq = new PdfPCell();
                celdaIzq.Border = Rectangle.NO_BORDER;

                if (File.Exists("logo.png"))
                {
                    Image logo = Image.GetInstance("logo.png");
                    logo.ScaleAbsolute(100, 50);
                    logo.Alignment = Element.ALIGN_LEFT;
                    celdaIzq.AddElement(logo);
                }

                Paragraph datosEmpresa = new Paragraph(
                    "DEGRA AUTOMOTORES\nCUIT: 27-37.521.884-5\nDirección: Maipu 595\nTel: (3463) 646409",
                    FontFactory.GetFont(FontFactory.HELVETICA, 9));
                celdaIzq.AddElement(datosEmpresa);

                
                PdfPCell celdaDer = new PdfPCell();
                celdaDer.Border = Rectangle.NO_BORDER;
                celdaDer.HorizontalAlignment = Element.ALIGN_RIGHT;

                Paragraph tituloFactura = new Paragraph("FACTURA", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18));
                tituloFactura.Alignment = Element.ALIGN_RIGHT;
                celdaDer.AddElement(tituloFactura);

                Paragraph datosFactura = new Paragraph(
                    $"N° {factura.IdFactura1.ToString("D4")}-{factura.Fecha1.Year}\n{factura.Fecha1:dd/MM/yyyy}",
                    FontFactory.GetFont(FontFactory.HELVETICA, 10));
                datosFactura.Alignment = Element.ALIGN_RIGHT;
                celdaDer.AddElement(datosFactura);

                cabecera.AddCell(celdaIzq);
                cabecera.AddCell(celdaDer);
                document.Add(cabecera);

                
                document.Add(new Paragraph(" "));

                
                PdfPTable clienteTable = new PdfPTable(2);
                clienteTable.SetWidths(new float[] { 20, 80 });
                clienteTable.WidthPercentage = 100;
                clienteTable.SpacingBefore = 10;

                clienteTable.AddCell(Celda("Cliente:", true));
                clienteTable.AddCell(Celda(factura.NombreCliente));
                clienteTable.AddCell(Celda("DNI:", true));
                clienteTable.AddCell(Celda(factura.Dnicliente));
                clienteTable.AddCell(Celda("Condiciones:", true));
                clienteTable.AddCell(Celda("Contado")); 

                document.Add(clienteTable);

               
                document.Add(new Paragraph(" "));

               
                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 10, 60, 15, 15 });

                
                tabla.AddCell(Celda("Cant", true));
                tabla.AddCell(Celda("Detalle", true));
                tabla.AddCell(Celda("P. Unit.", true));
                tabla.AddCell(Celda("Total", true));

                
                tabla.AddCell(Celda("1"));
                tabla.AddCell(Celda($"{factura.MarcaVehiculo} {factura.VersionVehiculo} - Año {factura.Año}"));
                tabla.AddCell(Celda(factura.Monto1.ToString("C")));
                tabla.AddCell(Celda(factura.Monto1.ToString("C")));

                document.Add(tabla);

                
                document.Add(new Paragraph(" "));
                

                
                Paragraph total = new Paragraph("TOTAL: " + factura.Monto1.ToString("C"),
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
