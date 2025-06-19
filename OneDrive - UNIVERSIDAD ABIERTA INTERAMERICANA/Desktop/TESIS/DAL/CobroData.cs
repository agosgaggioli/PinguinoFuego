using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class CobroData
    {
        private static string rutaXml = "Cobro.xml";

        public static void GuardarCobro(BeCobro cobro)
        {
            if (!File.Exists(rutaXml))
            {
                new XDocument(new XElement("cobros")).Save(rutaXml);
            }

            XDocument doc = XDocument.Load(rutaXml);

            int ultimoId = doc.Descendants("cobro")
                              .Select(c => (int?)c.Element("IdCobro") ?? 0)
                              .DefaultIfEmpty(0)
                              .Max();

            cobro.IdCobro1 = ultimoId + 1;

            XElement nuevoCobro = new XElement("cobro",
                new XElement("IdCobro", cobro.IdCobro1),
                new XElement("IdFactura", cobro.IdFactura1),
                new XElement("Cobro", cobro.Cobro1),
                new XElement("Metodo", cobro.Metodo1)
            );

            doc.Element("cobros").Add(nuevoCobro);
            doc.Save(rutaXml);
        }
        public static BeCobro ObtenerCobroPorId(int idCobro)
        {
            if (!File.Exists(rutaXml))
                return null;

            XDocument doc = XDocument.Load(rutaXml);

            var elementoCobro = doc.Descendants("cobro")
                .FirstOrDefault(c => (int)c.Element("IdCobro") == idCobro);

            if (elementoCobro == null)
                return null;

            BeCobro cobro = new BeCobro
            {
                IdCobro1 = (int)elementoCobro.Element("IdCobro"),
                IdFactura1 = (int)elementoCobro.Element("IdFactura"),
                Cobro1 = (decimal)elementoCobro.Element("Cobro"),
                Metodo1 = (string)elementoCobro.Element("Metodo")
            };

            return cobro;
        }
    }
}

