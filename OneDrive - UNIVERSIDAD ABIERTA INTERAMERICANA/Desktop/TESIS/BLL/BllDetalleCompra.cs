using BE;
using DAL;
using PDF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BllDetalleCompra
    {
        private DetalleCompraData detalleData = new DetalleCompraData();
        BllProveedor BllProveedor = new BllProveedor();
        BllPago BllPago = new BllPago();

        public void CrearDetalleCompra(BeCompra compra)
        {
            try
            {
                BeDetalleCompra detalle = new BeDetalleCompra();
                detalle.Descripcion1 = compra.Descripcion1;
                detalle.IdCompra1 = compra.IdCompra1;
                detalle.RazonSocialProveedor1 = compra.RazonSocialProvedor1;
                detalle.Monto1 = compra.Monto1;
                detalle.IdProveedor1 = compra.IdProveedor1;

              
                if (detalle.Monto1 <= 0) throw new Exception("El monto del detalle debe ser mayor a cero.");
                detalleData.GuardarDetalle(detalle);
                GenerarPDFDetalle(compra.IdCompra1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        public void GenerarPDFDetalle(int idCompra)
        {
            try
            {
                var detalle = detalleData.ObtenerDetallePorCompra(idCompra);
                if (detalle == null)
                    throw new Exception("No se encontró detalle para esa compra.");

                byte[] pdfBytes = PdfHelperCompra.GenerarPdfDetalle(detalle);

                
                string rutaPdf = Path.Combine(Path.GetTempPath(), $"DetalleCompra_{idCompra}.pdf");
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

        public List<BeDetalleCompra> getAll()
        {
            try
            {
                return DetalleCompraData.getAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<BeDetalleCompra> GetByIdProveedor(BeProveedor proveedorSeleccionado)
        {
            try
            {
                return DetalleCompraData.getByIdProveedor(proveedorSeleccionado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ImputarPago(BeDetalleCompra detalleSeleccionado, int monto, string metodo)
        {
            try
            {
                DetalleCompraData.ImputarPago(detalleSeleccionado, monto);
                BllPago.GuardarPago(detalleSeleccionado, metodo, monto);
                BllProveedor.RestarDeuda(detalleSeleccionado.IdProveedor1,monto);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BeDetalleCompra ObtenerDetalle(int idDetalle)
        {
            try
            {
                return DetalleCompraData.ObtnerDetallePorId(idDetalle);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public decimal ObtenerMontoTotalDetalle(BeProveedor proveedorSeleccionado)
        {
            try
            {
                var detalle = DetalleCompraData.getByIdProveedor(proveedorSeleccionado); 
                return detalle.Sum(f => f.Monto1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        public decimal ObtenerMontoTotalDetalles()
        {
            try
            {
                var detalles = DetalleCompraData.getAll(); 
                return detalles.Sum(f => f.Monto1);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
    }
}
