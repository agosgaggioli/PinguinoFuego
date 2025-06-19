using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BllBitacora
    {
        public void Guardar(BeBitacora beBitacora)
        {
            BitacoraData.Guardar(beBitacora);
        }
        public List<BeBitacora> ObtenerBitacora()
        {
            return BitacoraData.ObtnerBitacora();
        }

        public List<BeBitacora> ObtenerBitacoraBackUp()
        {
            return BitacoraData.ObtnerBitacoraBackUp();
        }

        public List<BeBitacora> ObtenerBitacoraRestore()
        {
            return BitacoraData.ObtnerBitacoraRestore();
        }
    }
}
