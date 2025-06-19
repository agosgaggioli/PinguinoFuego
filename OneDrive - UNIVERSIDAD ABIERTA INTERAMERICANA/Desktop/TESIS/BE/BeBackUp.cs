using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BeBackUp
    {
        private int idBackUP;
        private DateTime fecha;
        private string detalle;

        public int IdBackUP { get => idBackUP; set => idBackUP = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Detalle { get => detalle; set => detalle = value; }
    }
}
