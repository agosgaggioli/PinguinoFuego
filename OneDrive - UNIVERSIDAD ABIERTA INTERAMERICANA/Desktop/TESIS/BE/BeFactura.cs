using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BeFactura
    {
        private int IdFactura;
        private int IdVenta;
        private int IdVehiculo;
        private int IdCliente;
        private string nombreCliente;
        private string dnicliente;
        private string marcaVehiculo;
        private string versionVehiculo;
        private int año;
        private int Monto;
        private DateTime Fecha;

        public int IdVenta1 { get => IdVenta; set => IdVenta = value; }
        public int IdVehiculo1 { get => IdVehiculo; set => IdVehiculo = value; }
        public int IdCliente1 { get => IdCliente; set => IdCliente = value; }
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string Dnicliente { get => dnicliente; set => dnicliente = value; }
        public string MarcaVehiculo { get => marcaVehiculo; set => marcaVehiculo = value; }
        public string VersionVehiculo { get => versionVehiculo; set => versionVehiculo = value; }
        public int Año { get => año; set => año = value; }
        public int Monto1 { get => Monto; set => Monto = value; }
        public DateTime Fecha1 { get => Fecha; set => Fecha = value; }
        public int IdFactura1 { get => IdFactura; set => IdFactura = value; }
    }
}
