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
    public class BllProveedor
    {
        public void AgregarProveedor(BeProveedor beProveedor)
        {

            try
            {
                    if (beProveedor.RazonSocial1.Length <= 0)
                    {
                        throw new Exception("Debe tener Razon Social");
                    }
                    beProveedor.Deuda = 0;
                    ProveedorData.AgregarProveedor(beProveedor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteById(int idProveedor)
        {
            try
            {
                BeProveedor proveedor = ProveedorData.GetById(idProveedor);
                if (proveedor == null) throw new Exception("Proveedor inexistente");
                

                    ProveedorData.DeleteById(proveedor);
                   

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<BeProveedor> getAll()
        {
            try
            {
                return ProveedorData.getAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BeProveedor getById(int idSeleccionado)
        {
            try
            {
                return ProveedorData.GetById(idSeleccionado);
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        internal void SumarDeuda(int idProveedor1, int monto1)
        {
            try
            {
                

                    ProveedorData.SumarDeuda(idProveedor1, monto1);
             
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void RestarDeuda(int id, int Pago1)
        {
            try
            {
                

                    ProveedorData.RestarDeuda(id, Pago1);
                 
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
