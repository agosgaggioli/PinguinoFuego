using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class PagoData
    {
        private static string rutaXml = "Pago.xml";

        public static void GuardarPago(BePago pago)
        {
            if (!File.Exists(rutaXml))
            {
                new XDocument(new XElement("pagos")).Save(rutaXml);
            }

            XDocument doc = XDocument.Load(rutaXml);

            int ultimoId = doc.Descendants("pago")
                              .Select(p => (int?)p.Element("IdPago") ?? 0)
                              .DefaultIfEmpty(0)
                              .Max();

            pago.IdPago1 = ultimoId + 1;

            XElement nuevoPago = new XElement("pago",
                new XElement("IdPago", pago.IdPago1),
                new XElement("Pago", pago.Pago1),
                new XElement("IdDetalle", pago.IdDetalle1),
                new XElement("Metodo", pago.Metodo1)
            );

            doc.Element("pagos").Add(nuevoPago);
            doc.Save(rutaXml);
        }

        public static BePago ObtenerPagoPorId(int idPago)
        {
            if (!File.Exists(rutaXml))
                return null;

            XDocument doc = XDocument.Load(rutaXml);

            var elementoPago = doc.Descendants("pago")
                .FirstOrDefault(p => (int)p.Element("IdPago") == idPago);

            if (elementoPago == null)
                return null;

            BePago pago = new BePago
            {
                IdPago1 = (int)elementoPago.Element("IdPago"),
                Pago1 = (decimal)elementoPago.Element("Pago"),
                IdDetalle1 = (int)elementoPago.Element("IdDetalle"),
                Metodo1 = (string)elementoPago.Element("Metodo")
            };

            return pago;
        }
    }
}
