using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BeProveedor
    {
        private int IdProveedor;
        private string RazonSocial;
        private string Direccion;
        private string Contacto;
        private int deuda;

        public int IdProveedor1 { get => IdProveedor; set => IdProveedor = value; }
        public string RazonSocial1 { get => RazonSocial; set => RazonSocial = value; }
        public string Direccion1 { get => Direccion; set => Direccion = value; }
        public string Contacto1 { get => Contacto; set => Contacto = value; }
        public int Deuda { get => deuda; set => deuda = value; }
        public string ProveedorDisplay
        {
            get => $"{IdProveedor1} - {RazonSocial1}";
        }
    }
}
