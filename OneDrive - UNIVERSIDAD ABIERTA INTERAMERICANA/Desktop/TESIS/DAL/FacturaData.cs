using BE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class FacturaData
    {
        private static string rutaXml = "Factura.xml";

        public static List<BeFactura> getAll()
        {
            if (!File.Exists(rutaXml))
            {
                new XDocument(
                    new XElement("facturas")
                ).Save(rutaXml);
            }

            XDocument doc = XDocument.Load(rutaXml);

            var facturas = doc.Descendants("factura")
                .Select(x => new BeFactura
                {
                    IdFactura1 = (int)x.Element("IdFactura"),
                    IdVenta1 = (int)x.Element("IdVenta"),
                    IdVehiculo1 = (int)x.Element("IdVehiculo"),
                    IdCliente1 = (int)x.Element("IdCliente"),
                    NombreCliente = (string)x.Element("NombreCliente"),
                    Dnicliente = (string)x.Element("DniCliente"),
                    MarcaVehiculo = (string)x.Element("MarcaVehiculo"),
                    VersionVehiculo = (string)x.Element("VersionVehiculo"),
                    Año = (int)x.Element("Año"),
                    Monto1 = (int)x.Element("Monto"),
                    Fecha1 = DateTime.ParseExact((string)x.Element("Fecha"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                })
                .ToList();

            return facturas;
        }

        public static List<BeFactura> getByIdCliente(BeCliente clienteSeleccionado)
        {
            List<BeFactura> lista = new List<BeFactura>();

            if (!File.Exists(rutaXml))
                return lista;

            XDocument doc = XDocument.Load(rutaXml);

            lista = doc.Descendants("factura")
                .Where(x => (int)x.Element("IdCliente") == clienteSeleccionado.IdCliente1)
                .Select(x => new BeFactura
                {
                    IdFactura1 = (int)x.Element("IdFactura"),
                    IdVenta1 = (int)x.Element("IdVenta"),
                    IdVehiculo1 = (int)x.Element("IdVehiculo"),
                    IdCliente1 = (int)x.Element("IdCliente"),
                    NombreCliente = (string)x.Element("NombreCliente"),
                    Dnicliente = (string)x.Element("DniCliente"),
                    MarcaVehiculo = (string)x.Element("MarcaVehiculo"),
                    VersionVehiculo = (string)x.Element("VersionVehiculo"),
                    Año = (int)x.Element("Año"),
                    Monto1 = (int)x.Element("Monto"),
                    Fecha1 = DateTime.Parse((string)x.Element("Fecha"))
                }).ToList();

            return lista;
        }

        public static void GuardarFactura(BeFactura factura)
        {
            
            if (!File.Exists(rutaXml))
            {
                new XDocument(
                    new XElement("facturas")
                ).Save(rutaXml);
            }

            XDocument doc = XDocument.Load(rutaXml);

            
            int ultimoId = doc.Descendants("factura")
                              .Select(f => (int?)f.Element("IdFactura") ?? 0)
                              .DefaultIfEmpty(0)
                              .Max();

            int nuevoId = ultimoId + 1;
            factura.IdFactura1 = nuevoId;

            XElement nuevaFactura = new XElement("factura",
                new XElement("IdFactura", factura.IdFactura1),
                new XElement("IdVenta", factura.IdVenta1),
                new XElement("IdVehiculo", factura.IdVehiculo1),
                new XElement("IdCliente", factura.IdCliente1),
                new XElement("NombreCliente", factura.NombreCliente),
                new XElement("DniCliente", factura.Dnicliente),
                new XElement("MarcaVehiculo", factura.MarcaVehiculo),
                new XElement("VersionVehiculo", factura.VersionVehiculo),
                new XElement("Año", factura.Año),
                new XElement("Monto", factura.Monto1),
                new XElement("Fecha", factura.Fecha1.ToString("yyyy-MM-dd HH:mm:ss"))
            );

            doc.Element("facturas").Add(nuevaFactura);
            doc.Save(rutaXml);
        }

        public static void ImputarCobro(BeFactura facturaSeleccionada, int cobro)
        {
            if (!File.Exists(rutaXml))
                throw new Exception("El archivo de facturas no existe.");

            XDocument doc = XDocument.Load(rutaXml);

            XElement nodoFactura = doc.Descendants("factura")
                .FirstOrDefault(f => (int)f.Element("IdFactura") == facturaSeleccionada.IdFactura1);

            if (nodoFactura == null)
                throw new Exception("Factura no encontrada.");

            int montoActual = (int)nodoFactura.Element("Monto");
            int nuevoMonto = montoActual - cobro;

            if (nuevoMonto <= 0)
            {
                
                nodoFactura.Remove();
            }
            else
            {
               
                nodoFactura.Element("Monto").Value = nuevoMonto.ToString();
            }

            doc.Save(rutaXml);
        }

        public static BeFactura ObtenerFacturaPorId(int idFactura)
        {
            string rutaXml = "Factura.xml"; 

            if (!File.Exists(rutaXml))
                throw new Exception("El archivo de facturas no existe.");

            XDocument doc = XDocument.Load(rutaXml);

            XElement nodoFactura = doc.Descendants("factura")
                .FirstOrDefault(f => (int)f.Element("IdFactura") == idFactura);

            if (nodoFactura == null) return null;

            BeFactura factura = new BeFactura
            {
                IdFactura1 = (int)nodoFactura.Element("IdFactura"),
                IdVenta1 = (int)nodoFactura.Element("IdVenta"),
                IdVehiculo1 = (int)nodoFactura.Element("IdVehiculo"),
                IdCliente1 = (int)nodoFactura.Element("IdCliente"),
                NombreCliente = (string)nodoFactura.Element("NombreCliente"),
                Dnicliente = (string)nodoFactura.Element("DniCliente"),
                MarcaVehiculo = (string)nodoFactura.Element("MarcaVehiculo"),
                VersionVehiculo = (string)nodoFactura.Element("VersionVehiculo"),
                Año = (int)nodoFactura.Element("Año"),
                Monto1 = (int)nodoFactura.Element("Monto"),
                Fecha1 = DateTime.Parse((string)nodoFactura.Element("Fecha"))
            };

            return factura;
        }
    }
}
