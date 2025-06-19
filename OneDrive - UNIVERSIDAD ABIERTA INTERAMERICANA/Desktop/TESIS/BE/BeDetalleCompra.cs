using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BeDetalleCompra
    {
        private int IdCompra;
        private int IdDetalle;
        private int IdProveedor;
        private int Monto;
        
        private string Descripcion;
        private DateTime fecha;
        private string RazonSocialProveedor;
        public string RazonSocialProveedor1 { get => RazonSocialProveedor; set => RazonSocialProveedor = value; }
        public int IdCompra1 { get => IdCompra; set => IdCompra = value; }
        public int Monto1 { get => Monto; set => Monto = value; }
        
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int IdDetalle1 { get => IdDetalle; set => IdDetalle = value; }
        public int IdProveedor1 { get => IdProveedor; set => IdProveedor = value; }
    }
}
