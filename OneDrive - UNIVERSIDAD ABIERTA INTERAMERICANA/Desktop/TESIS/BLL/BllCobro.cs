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
    public class BllCobro
    {
        public void GuardarCobro(BeFactura facturaSeleccionada, string metodo, int cobro)
        {
            try
            {
                BeCobro nuevoCobro = new BeCobro
                {
                    IdFactura1 = facturaSeleccionada.IdFactura1,
                    Cobro1 = cobro,
                    Metodo1 = metodo
                };

                CobroData.GuardarCobro(nuevoCobro);
                GenerarPDFCobro(nuevoCobro.IdCobro1);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void GenerarPDFCobro(int idCobro)
        {
            try {
                var cobro = CobroData.ObtenerCobroPorId(idCobro);
                if (cobro == null)
                    throw new Exception("No se encontró el cobro con ese ID.");

                byte[] pdfBytes = PdfHelperReciboCobro.GenerarPdfCobro(cobro);

                string rutaPdf = Path.Combine(Path.GetTempPath(), $"Cobro_{idCobro}.pdf");
                File.WriteAllBytes(rutaPdf, pdfBytes);

                Process.Start(new ProcessStartInfo
                {
                    FileName = rutaPdf,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
