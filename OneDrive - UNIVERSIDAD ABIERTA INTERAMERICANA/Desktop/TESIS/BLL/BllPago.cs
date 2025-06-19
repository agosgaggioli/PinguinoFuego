using BE;
using DAL;
using PDF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BllPago
    {
        public void GuardarPago(BeDetalleCompra detalleSeleccionado, string metodo, int monto)
        {
            try
            {
                BePago nuevoPago = new BePago
                {
                    IdDetalle1 = detalleSeleccionado.IdDetalle1,
                    Pago1 = monto,
                    Metodo1 = metodo
                };

                PagoData.GuardarPago(nuevoPago);
                GenerarPDFPago(nuevoPago.IdPago1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
    
    public void GenerarPDFPago(int idPago)
        {
            try
            {
                var pago = PagoData.ObtenerPagoPorId(idPago);
                if (pago == null)
                    throw new Exception("No se encontró el pago con ese ID.");

                byte[] pdfBytes = PdfHelperReciboPago.GenerarPdfPago(pago);

                string rutaPdf = Path.Combine(Path.GetTempPath(), $"Pago_{idPago}.pdf");
                File.WriteAllBytes(rutaPdf, pdfBytes);

                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaPdf,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        } 
    }
   
}
