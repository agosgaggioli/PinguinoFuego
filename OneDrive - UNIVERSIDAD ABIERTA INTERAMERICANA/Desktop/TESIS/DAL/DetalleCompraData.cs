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
    public class DetalleCompraData
    {
        private static string rutaXmlDetalle = "DetalleCompra.xml";

        public static List<BeDetalleCompra> getAll()
        {
            if (!File.Exists(rutaXmlDetalle))
            {
                new XDocument(
                    new XElement("detalles")
                ).Save(rutaXmlDetalle);
            }

            XDocument doc = XDocument.Load(rutaXmlDetalle);
            var detalles = doc.Descendants("detalle")
            .Select(x => new BeDetalleCompra
            {
                IdDetalle1 = (int)x.Element("IdDetalle"),
                IdCompra1 = (int)x.Element("IdCompra"),
                IdProveedor1 = (int?)x.Element("IdProveedor") ?? 0,
                Fecha = DateTime.TryParse((string)x.Element("Fecha"), out var fecha) ? fecha : DateTime.MinValue,
                Descripcion1 = (string?)x.Element("Descripcion") ?? "",
                Monto1 = (int?)x.Element("Monto") ?? 0,
                RazonSocialProveedor1 = (string?)x.Element("RazonSocialProveedor") ?? ""
            })
            .ToList();

            return detalles;
        }

        public static List<BeDetalleCompra> getByIdProveedor(BeProveedor proveedorSeleccionado)
        {
            List<BeDetalleCompra> lista = new List<BeDetalleCompra>();

            if (!File.Exists(rutaXmlDetalle))
                return lista;

            XDocument doc = XDocument.Load(rutaXmlDetalle);

            lista = doc.Descendants("detalle")
                .Where(x => (int)x.Element("IdProveedor") == proveedorSeleccionado.IdProveedor1)
                .Select(x => new BeDetalleCompra
                {
                    IdDetalle1 = (int)x.Element("IdDetalle"),
                    IdCompra1 = (int)x.Element("IdCompra"),
                    Fecha = DateTime.ParseExact((string)x.Element("Fecha"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    Descripcion1 = (string)x.Element("Descripcion"),
                    Monto1 = (int)x.Element("Monto"),
                    RazonSocialProveedor1 = (string)x.Element("RazonSocialProveedor")
                })
                .ToList();

            return lista;
        }

        public static void ImputarPago(BeDetalleCompra detalleSeleccionado, int monto)
        {
            if (!File.Exists(rutaXmlDetalle))
                throw new Exception("El archivo de detalles no existe.");

            XDocument doc = XDocument.Load(rutaXmlDetalle);

            XElement nodoDetalle = doc.Descendants("detalle")
                .FirstOrDefault(d => (int)d.Element("IdDetalle") == detalleSeleccionado.IdDetalle1);

            if (nodoDetalle == null)
                throw new Exception("Detalle no encontrado.");

            int montoActual = (int)nodoDetalle.Element("Monto");
            int nuevoMonto = montoActual - monto;

            if (nuevoMonto <= 0)
            {
                
                nodoDetalle.Remove();
            }
            else
            {
               
                nodoDetalle.Element("Monto").Value = nuevoMonto.ToString();
            }

            doc.Save(rutaXmlDetalle);
        }

        public static BeDetalleCompra ObtnerDetallePorId(int idDetalle)
        {
            if (!File.Exists(rutaXmlDetalle))
                throw new Exception("El archivo de detalles no existe.");

            XDocument doc = XDocument.Load(rutaXmlDetalle);

            XElement nodoDetalle = doc.Descendants("detalle")
                .FirstOrDefault(d => (int)d.Element("IdDetalle") == idDetalle);

            if (nodoDetalle == null)
                return null;

            BeDetalleCompra detalle = new BeDetalleCompra
            {
                IdDetalle1 = (int)nodoDetalle.Element("IdDetalle"),
                IdCompra1 = (int)nodoDetalle.Element("IdCompra"),
                IdProveedor1 = (int)nodoDetalle.Element("IdProveedor"),
                Fecha = DateTime.Parse((string)nodoDetalle.Element("Fecha")),
                Descripcion1 = (string)nodoDetalle.Element("Descripcion"),
                Monto1 = (int)nodoDetalle.Element("Monto"),
                RazonSocialProveedor1 = (string)nodoDetalle.Element("RazonSocialProveedor")
            };

            return detalle;
        }

        public void GuardarDetalle(BeDetalleCompra detalle)
        {
            XDocument doc;

            if (!File.Exists(rutaXmlDetalle))
            {
                doc = new XDocument(new XElement("detalles"));
            }
            else
            {
                doc = XDocument.Load(rutaXmlDetalle);
            }

            int ultimoId = doc.Descendants("detalle")
                .Select(x => (int?)x.Element("IdDetalle") ?? 0)
                .DefaultIfEmpty(0)
                .Max();

            int nuevoId = ultimoId + 1;
            detalle.IdDetalle1 = nuevoId;

            XElement nuevoDetalle = new XElement("detalle",
                new XElement("IdDetalle", detalle.IdDetalle1),
                new XElement("IdCompra", detalle.IdCompra1),
                new XElement("IdProveedor", detalle.IdProveedor1), 
                new XElement("Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new XElement("Descripcion", detalle.Descripcion1),
                new XElement("Monto", detalle.Monto1),
                new XElement("RazonSocialProveedor", detalle.RazonSocialProveedor1)
            );

            doc.Element("detalles").Add(nuevoDetalle);
            doc.Save(rutaXmlDetalle);
        }

        public BeDetalleCompra ObtenerDetallePorCompra(int idCompra)
        {
            if (!File.Exists(rutaXmlDetalle))
                return null;

            XDocument doc = XDocument.Load(rutaXmlDetalle);

            var detalleElem = doc.Descendants("detalle")
                .FirstOrDefault(d => (int)d.Element("IdCompra") == idCompra);

            if (detalleElem == null) return null;

            return new BeDetalleCompra
            {
                IdDetalle1 = (int)detalleElem.Element("IdDetalle"),
                IdCompra1 = idCompra,
                Fecha = (DateTime)detalleElem.Element("Fecha"),
                Descripcion1 = (string)detalleElem.Element("Descripcion"),
                Monto1 = (int)detalleElem.Element("Monto"),
                RazonSocialProveedor1 = (string)detalleElem.Element("RazonSocialProveedor")
            };
        }
    }
}
