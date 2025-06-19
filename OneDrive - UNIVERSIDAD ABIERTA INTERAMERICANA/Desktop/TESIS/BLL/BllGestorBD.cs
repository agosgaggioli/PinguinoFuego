using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BllGestorBD
    {
        public void CrearBackUP()
        {
            try
            {
                GestorBDData.CrearBackup();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        public List<BeBackUp> ObtenerBackups()
        {
            try
            {
                return GestorBDData.ObtenerBackups();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
        public void CrearRestore(string nombreCarpetaBackup)
        {
            try
            {
                GestorBDData.CrearRestore(nombreCarpetaBackup);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
    }
}
