using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class BllCompra
        
    {
        BllDetalleCompra BllDetalleCompra=new BllDetalleCompra();
        BllProveedor bllProveedor = new BllProveedor(); 

        public void CrearCompra(BeCompra compra)
        {

            try
            {
                using (TransactionScope trx = new TransactionScope())
                {
                    if (compra.IdProveedor1 <= 0)
                    {
                        throw new Exception("El idProveedor no puede ser menor a 0");
                    }
                    compra.Fecha= DateTime.Now;
                    CompraData.crearCompra(compra);
                    BllDetalleCompra.CrearDetalleCompra(compra);
                    bllProveedor.SumarDeuda(compra.IdProveedor1, compra.Monto1);
                    trx.Complete();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static string obtnerProveedorMasFrecuente()
        {
            try
            {
                return CompraData.ObtenerProveedorMasFrecuente();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
    }
}
