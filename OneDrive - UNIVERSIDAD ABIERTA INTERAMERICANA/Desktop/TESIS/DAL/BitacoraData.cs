using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class BitacoraData
    {

        private static string rutaXml = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bitacora.xml");

        public static void Guardar(BeBitacora bitacora)
        {
            
            if (!File.Exists(rutaXml))
            {
                new XDocument(
                    new XElement("bitacoras")
                ).Save(rutaXml);
            }

            XDocument doc = XDocument.Load(rutaXml);

            
            int ultimoId = doc.Descendants("bitacora")
                              .Select(x => (int?)x.Element("IdBitacora") ?? 0)
                              .DefaultIfEmpty(0)
                              .Max();

            int nuevoId = ultimoId + 1;
            bitacora.IdBitacora1 = nuevoId;

            
            XElement nuevaBitacora = new XElement("bitacora",
                new XElement("IdBitacora", bitacora.IdBitacora1),
                new XElement("Fecha", bitacora.Fecha.ToString("yyyy-MM-dd HH:mm:ss")),
                new XElement("IdUsuario", bitacora.IdUsuario1),
                new XElement("Detalle", bitacora.Detalle)
            );

            
            doc.Element("bitacoras").Add(nuevaBitacora);
            doc.Save(rutaXml);
        }

        public static List<BeBitacora> ObtnerBitacora()
        {
            List<BeBitacora> lista = new List<BeBitacora>();

            if (!File.Exists(rutaXml))
            {
                return lista; 
            }

            XDocument doc = XDocument.Load(rutaXml);

            foreach (XElement elem in doc.Descendants("bitacora"))
            {
                BeBitacora bitacora = new BeBitacora();

                bitacora.IdBitacora1 = (int)elem.Element("IdBitacora");
                bitacora.Fecha = DateTime.ParseExact(
                    (string)elem.Element("Fecha"),
                    "yyyy-MM-dd HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture);
                 bitacora.IdUsuario1 = (int)elem.Element("IdUsuario"); 
                bitacora.Detalle = (string)elem.Element("Detalle");

                lista.Add(bitacora);
            }

            return lista;
        }

        public static List<BeBitacora> ObtnerBitacoraBackUp()
        {
            List<BeBitacora> lista = new List<BeBitacora>();

            if (!File.Exists(rutaXml))
            {
                return lista; 
            }

            XDocument doc = XDocument.Load(rutaXml);

            
            var backupElements = doc.Descendants("bitacora")
                                    .Where(b => (string)b.Element("Detalle") == "Back Up");

            foreach (XElement bitacoraElem in backupElements)
            {
                BeBitacora bitacora = new BeBitacora();

                bitacora.IdBitacora1 = (int)bitacoraElem.Element("IdBitacora");
                bitacora.Fecha = DateTime.ParseExact(
                    (string)bitacoraElem.Element("Fecha"),
                    "yyyy-MM-dd HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture);
                 bitacora.IdUsuario1 = (int)bitacoraElem.Element("IdUsuario"); 
                bitacora.Detalle = (string)bitacoraElem.Element("Detalle");

                lista.Add(bitacora);
            }

            return lista;
        }

        public static List<BeBitacora> ObtnerBitacoraRestore()
        {
            List<BeBitacora> lista = new List<BeBitacora>();

            if (!File.Exists(rutaXml))
            {
                return lista; 
            }

            XDocument doc = XDocument.Load(rutaXml);

            
            var backupElements = doc.Descendants("bitacora")
                                    .Where(b => (string)b.Element("Detalle") == "Restore");

            foreach (XElement bitacoraElem in backupElements)
            {
                BeBitacora bitacora = new BeBitacora();

                bitacora.IdBitacora1 = (int)bitacoraElem.Element("IdBitacora");
                bitacora.Fecha = DateTime.ParseExact(
                    (string)bitacoraElem.Element("Fecha"),
                    "yyyy-MM-dd HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture);
                 bitacora.IdUsuario1 = (int)bitacoraElem.Element("IdUsuario"); 
                bitacora.Detalle = (string)bitacoraElem.Element("Detalle");

                lista.Add(bitacora);
            }

            return lista;
        }
    }
}
