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
    
    public class BllFactura
       
    {
        BllCobro bllCobro = new BllCobro(); 
       
        BLLCliente bLLCliente = new BLLCliente();
        public void CrearFactura(BeVenta venta)
        {
            try
            {
                BeFactura factura = new BeFactura();
                factura.IdVenta1 = venta.IdVenta1;
                factura.IdVehiculo1 = venta.IdVehiculo1;
                factura.IdCliente1 = venta.IdCliente1;
                factura.NombreCliente = venta.NombreCliente;
                factura.Dnicliente = venta.Dnicliente;
                factura.MarcaVehiculo = venta.MarcaVehiculo;
                factura.VersionVehiculo = venta.VersionVehiculo;
                factura.Año = venta.Año;
                factura.Monto1 = venta.Monto1;
                factura.Fecha1 = venta.Fecha1;

               
                if (factura.Monto1 <= 0)
                    throw new Exception("El monto de la factura debe ser mayor a cero.");

                FacturaData.GuardarFactura(factura);
                GenerarPDFFactura(factura.IdFactura1);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void GenerarPDFFactura(int idFactura)
        {
            try
            {
                var factura = FacturaData.ObtenerFacturaPorId(idFactura);
                if (factura == null)
                    throw new Exception("No se encontró la factura con ese ID.");

                byte[] pdfBytes = PdfHelperFactura.GenerarPdfFactura(factura);

               
                string rutaPdf = Path.Combine(Path.GetTempPath(), $"Factura_{idFactura}.pdf");
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

        public  List<BeFactura> getAll()
        {
            try
            {
                return FacturaData.getAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<BeFactura> GetByIdCliente(BeCliente clienteSeleccionado)
        {
            try
            {
                return FacturaData.getByIdCliente(clienteSeleccionado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ImputarCobro(BeFactura facturaSeleccionada, int cobro, string metodo)
        {
            try
            {
                FacturaData.ImputarCobro(facturaSeleccionada, cobro);
                bllCobro.GuardarCobro(facturaSeleccionada, metodo,cobro);
                bLLCliente.RestarDeuda(facturaSeleccionada.IdCliente1,cobro);

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public object obtenerFactura(int idFactura)
        {
            try
            {
                return FacturaData.ObtenerFacturaPorId(idFactura);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public decimal ObtenerMontoTotalFacturas()
        {
            try
            {
                var facturas = FacturaData.getAll();
                return facturas.Sum(f => f.Monto1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
        public decimal ObtenerMontoTotalFacturasCliente(BeCliente clienteSeleccionado)
        {
            try
            {
                var facturas = FacturaData.getByIdCliente(clienteSeleccionado);
                return facturas.Sum(f => f.Monto1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
        
    }
}
