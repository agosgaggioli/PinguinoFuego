using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BeVehiculo
    {
        private int IdVehiculo;
        
        private string Patente;
        private string Kilometros;
        private int Precio;
        private string Version;
        private int Año;
        private string Marca;
        private decimal PrecioContado;
        private decimal PrecioConUsado;

        public int IdVehiculo1 { get => IdVehiculo; set => IdVehiculo = value; }
      
        public string Patente1 { get => Patente; set => Patente = value; }
        
        public int Precio1 { get => Precio; set => Precio = value; }
        public string Version1 { get => Version; set => Version = value; }
        public int Año1 { get => Año; set => Año = value; }
        public string Marca1 { get => Marca; set => Marca = value; }
        public decimal PrecioContado1 { get => PrecioContado; set => PrecioContado = value; }
        public decimal PrecioConUsado1 { get => PrecioConUsado; set => PrecioConUsado = value; }
        public string Kilometros1 { get => Kilometros; set => Kilometros = value; }
    }
}
