using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BllVendedor
    {
        VendedorData VendedorData = new VendedorData();
        public List<BeVendedor> getAll()
        {
            try
            {
                return VendedorData.getAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BeVendedor getById(int idVendedor)
        {
            try
            {
                return VendedorData.GetById(idVendedor);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
    }
}
