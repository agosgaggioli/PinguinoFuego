using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BeBitacora
    {
        private int IdBitacora;
        private DateTime fecha;
        private int IdUsuario;
        private string detalle;

        public int IdBitacora1 { get => IdBitacora; set => IdBitacora = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int IdUsuario1 { get => IdUsuario; set => IdUsuario = value; }
        public string Detalle { get => detalle; set => detalle = value; }
    }
}
