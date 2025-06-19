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
    public class VehiculoData
    {
        private static string rutaXml = "Vehiculo.xml"; 
        public static void cargarVehiculo(BeVehiculo vehiculo)
        {
            
            if (!File.Exists(rutaXml))
            {
                new XDocument(
                    new XElement("vehiculos")
                ).Save(rutaXml);
            }

            XDocument doc = XDocument.Load(rutaXml);

            
            
            int ultimoId = doc.Descendants("vehiculo")
                              .Select(c => (int?)c.Element("IdVehiculo") ?? 0)
                              .DefaultIfEmpty(0)
                              .Max();

            int nuevoId = ultimoId + 1;
            vehiculo.IdVehiculo1 = nuevoId;


           
            XElement nuevoVehiculo = new XElement("vehiculo",
                new XElement("IdVehiculo", vehiculo.IdVehiculo1),
                new XElement("Marca", vehiculo.Marca1),
                new XElement("Version", vehiculo.Version1),
                new XElement("Año", vehiculo.Año1),
                new XElement("Kilometros", vehiculo.Kilometros1),
                new XElement("Patente", vehiculo.Patente1),
                new XElement("Precio",vehiculo.Precio1),
                new XElement("PrecioContado", vehiculo.PrecioContado1),
                new XElement("PrecioUsado", vehiculo.PrecioConUsado1)
            );

            
            doc.Element("vehiculos").Add(nuevoVehiculo);
            doc.Save(rutaXml);
        }

        public static void DeleteById(BeVehiculo vehiculo)
        {
            XDocument doc = XDocument.Load(rutaXml);

            XElement VehiculoAEliminar = doc.Descendants("vehiculo")
                .FirstOrDefault(x => (int)x.Element("IdVehiculo") == vehiculo.IdVehiculo1);

            if (VehiculoAEliminar == null)
                throw new Exception("Vehiculo no encontrado para eliminar.");

            VehiculoAEliminar.Remove(); 

            doc.Save(rutaXml); 
        }

        public static List<BeVehiculo> getAll()
        {
            
            if (!File.Exists(rutaXml))
            {
                new XDocument(
                    new XElement("vehiculos")
                ).Save(rutaXml);
            }
            XDocument doc = XDocument.Load(rutaXml);

            var vehiculos = doc.Descendants("vehiculo")
                .Select(x => new BeVehiculo
                {
                    IdVehiculo1= (int)x.Element("IdVehiculo"),
                    Marca1 = (string)x.Element("Marca"),
                    Version1= (string)x.Element("Version"),
                    Año1 = (int)x.Element("Año"),
                    Kilometros1 = (string)x.Element("Kilometros"),
                    Patente1 = (string)x.Element("Patente"),
                    Precio1= (int)x.Element("Precio"),
                    PrecioContado1 = decimal.Parse((string)x.Element("PrecioContado"), CultureInfo.InvariantCulture),
                    PrecioConUsado1 = decimal.Parse((string)x.Element("PrecioUsado"), CultureInfo.InvariantCulture)

                })
                .ToList();

            return vehiculos;
        }

        public static BeVehiculo GetById(int id)
        {
            XDocument doc = XDocument.Load(rutaXml);

            XElement vehiculoElement = doc.Root.Elements("vehiculo")
                .FirstOrDefault(x => (int)x.Element("IdVehiculo") == id);

            if (vehiculoElement == null)
                return null;

            BeVehiculo vehiculo = new BeVehiculo
            {
                IdVehiculo1 = (int)vehiculoElement.Element("IdVehiculo"),
                Marca1 = (string)vehiculoElement.Element("Marca"),
                Version1 = (string)vehiculoElement.Element("Version"),
                Año1 = (int)vehiculoElement.Element("Año"),
                Kilometros1 = (string)vehiculoElement.Element("Kilometros"),
                Patente1 = (string)vehiculoElement.Element("Patente"),
                Precio1 = (int)vehiculoElement.Element("Precio"),
                PrecioContado1 = decimal.Parse((string)vehiculoElement.Element("PrecioContado"), System.Globalization.CultureInfo.InvariantCulture),
                PrecioConUsado1 = decimal.Parse((string)vehiculoElement.Element("PrecioUsado"), System.Globalization.CultureInfo.InvariantCulture)
            };

            return vehiculo;
        }

        public static void Update(BeVehiculo vehiculo)
        {
            

            XDocument doc = XDocument.Load(rutaXml);

            XElement vehiculoElement = doc.Root.Elements("vehiculo")
                .FirstOrDefault(x => (int)x.Element("IdVehiculo") == vehiculo.IdVehiculo1);

            if (vehiculoElement == null)
                throw new Exception("Vehículo no encontrado en el XML");

            
            vehiculoElement.Element("Precio").Value = vehiculo.Precio1.ToString();
            vehiculoElement.Element("PrecioContado").Value = vehiculo.PrecioContado1.ToString("G" , System.Globalization.CultureInfo.InvariantCulture);
            vehiculoElement.Element("PrecioUsado").Value = vehiculo.PrecioConUsado1.ToString("G", System.Globalization.CultureInfo.InvariantCulture);

            doc.Save(rutaXml);
        }
    }
}
