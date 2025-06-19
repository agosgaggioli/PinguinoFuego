using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class VentaData
    {
        private static string rutaXml = "Venta.xml"; 

        public static void crearVenta(BeVenta venta)
        {
            
            if (!File.Exists(rutaXml))
            {
                new XDocument(
                    new XElement("ventas")
                ).Save(rutaXml);
            }

            XDocument doc = XDocument.Load(rutaXml);

            
            int ultimoId = doc.Descendants("venta")
                              .Select(v => (int?)v.Element("IdVenta") ?? 0)
                              .DefaultIfEmpty(0)
                              .Max();

            int nuevoId = ultimoId + 1;
            venta.IdVenta1 = nuevoId; 

            
            XElement nuevaVenta = new XElement("venta",
                new XElement("IdVenta", venta.IdVenta1),
                new XElement("IdVendedor", venta.IdVendedor1),
                new XElement("IdVehiculo", venta.IdVehiculo1),
                new XElement("IdCliente", venta.IdCliente1),
                new XElement("NombreCliente", venta.NombreCliente),
                new XElement("DniCliente", venta.Dnicliente),
                new XElement("MarcaVehiculo", venta.MarcaVehiculo),
                new XElement("VersionVehiculo", venta.VersionVehiculo),
                new XElement("Año", venta.Año),
                new XElement("Monto", venta.Monto1),
                new XElement("Fecha", venta.Fecha1.ToString("yyyy-MM-dd HH:mm:ss"))
            );

            
            doc.Element("ventas").Add(nuevaVenta);
            doc.Save(rutaXml);
        }

        public static List<BeVenta> getAll()
        {
            List<BeVenta> ventas = new List<BeVenta>();

            if (!File.Exists(rutaXml))
                return ventas; 

            XDocument doc = XDocument.Load(rutaXml);

            foreach (XElement ventaElem in doc.Descendants("venta"))
            {
                BeVenta venta = new BeVenta
                {
                    IdVenta1 = (int)ventaElem.Element("IdVenta"),
                    IdVendedor1 = (int)ventaElem.Element("IdVendedor"),
                    IdVehiculo1 = (int)ventaElem.Element("IdVehiculo"),
                    IdCliente1 = (int)ventaElem.Element("IdCliente"),
                    NombreCliente = (string)ventaElem.Element("NombreCliente"),
                    Dnicliente = (string)ventaElem.Element("DniCliente"),
                    MarcaVehiculo = (string)ventaElem.Element("MarcaVehiculo"),
                    VersionVehiculo = (string)ventaElem.Element("VersionVehiculo"),
                    Año = (int)ventaElem.Element("Año"),
                    Monto1 = (int)ventaElem.Element("Monto"),
                    Fecha1 = DateTime.Parse((string)ventaElem.Element("Fecha"))
                };

                ventas.Add(venta);
            }
            return ventas;
        }

        public static List<BeVenta> ObtenerVentas()
        {
            List<BeVenta> ventas = new List<BeVenta>();

            if (!File.Exists(rutaXml))
                return ventas;

            XDocument doc = XDocument.Load(rutaXml);

            ventas = doc.Descendants("venta")
                .Select(v => new BeVenta
                {
                    IdVenta1 = (int)v.Element("IdVenta"),
                    IdVendedor1 = (int)v.Element("IdVendedor"),
                    IdVehiculo1 = (int)v.Element("IdVehiculo"),
                    IdCliente1 = (int)v.Element("IdCliente"),
                    NombreCliente = (string)v.Element("NombreCliente"),
                    Dnicliente = (string)v.Element("DniCliente"),
                    MarcaVehiculo = (string)v.Element("MarcaVehiculo"),
                    VersionVehiculo = (string)v.Element("VersionVehiculo"),
                    Año = (int)v.Element("Año"),
                    Monto1 = (int)v.Element("Monto"),
                    Fecha1 = DateTime.Parse((string)v.Element("Fecha"))
                })
                .ToList();

            return ventas;
        }
    }
}
