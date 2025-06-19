using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BeCompra
    {
        private int IdCompra;
        private int Monto;
        private int IdProveedor;
        private string RazonSocialProvedor;
        private string Descripcion;
        private DateTime fecha;

        public int IdCompra1 { get => IdCompra; set => IdCompra = value; }
        public int Monto1 { get => Monto; set => Monto = value; }
        public int IdProveedor1 { get => IdProveedor; set => IdProveedor = value; }
        public string RazonSocialProvedor1 { get => RazonSocialProvedor; set => RazonSocialProvedor = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
