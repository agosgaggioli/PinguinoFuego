
using BE;
using System.Net;
using System.Xml.Linq;

namespace DAL
{
    public class ClienteData
    {
        private static string rutaXml = "Cliente.xml"; 

        public static void crearCliente(BeCliente cliente)
        {
           
            if (!File.Exists(rutaXml))
            {
                new XDocument(
                    new XElement("clientes")
                ).Save(rutaXml);
            }

            XDocument doc = XDocument.Load(rutaXml);

            
            
            int ultimoId = doc.Descendants("cliente")
                              .Select(c => (int?)c.Element("IdCliente") ?? 0)
                              .DefaultIfEmpty(0)
                              .Max();

            int nuevoId = ultimoId + 1;
           cliente.IdCliente1 = nuevoId;

            
            XElement nuevoCliente = new XElement("cliente",
                new XElement("IdCliente", cliente.IdCliente1),
                new XElement("nombre", cliente.NombreCliente1),
                new XElement("apellido", cliente.ApellidoCliente1),
                new XElement("dni", cliente.DniCliente1),
                new XElement("direccion", cliente.Direccion1),
                new XElement("deuda", cliente.DeudaCliente1)
            );

            
            doc.Element("clientes").Add(nuevoCliente);
            doc.Save(rutaXml);
        }

        
        public static void DeleteById(BeCliente Cliente)
        {

            XDocument doc = XDocument.Load(rutaXml);

            XElement clienteAEliminar = doc.Descendants("cliente")
                .FirstOrDefault(x => (int)x.Element("IdCliente") == Cliente.IdCliente1);

            if (clienteAEliminar == null)
                throw new Exception("Cliente no encontrado para eliminar.");

            clienteAEliminar.Remove(); 

            doc.Save(rutaXml); 
        }

        public static List<BeCliente> getAll()

        {
            
            if (!File.Exists(rutaXml))
            {
                new XDocument(
                    new XElement("clientes")
                ).Save(rutaXml);
            }
            XDocument doc = XDocument.Load(rutaXml);

            var clientes = doc.Descendants("cliente")
                .Select(x => new BeCliente
                {
                    IdCliente1 = (int)x.Element("IdCliente"),
                    NombreCliente1 = (string)x.Element("nombre"),
                    DniCliente1 = (string)x.Element("dni"),
                    ApellidoCliente1=(string)x.Element("apellido"),
                    Direccion1=(string)x.Element("direccion"),
                    DeudaCliente1=(int)x.Element("deuda")
                    
                })
                .ToList();

            return clientes;
        }

        public static BeCliente GetById(int id)
        {
            XDocument doc = XDocument.Load(rutaXml);

            var clienteElement = doc.Descendants("cliente")
                .FirstOrDefault(x => (int)x.Element("IdCliente") == id);

            if (clienteElement == null)
                return null;

            return new BeCliente
            {
                IdCliente1 =(int)clienteElement.Element("IdCliente"),
                NombreCliente1 = (string)clienteElement.Element("nombre"),
                ApellidoCliente1 = (string)clienteElement.Element("apellido"),
                DniCliente1 = (string)clienteElement.Element("dni"),
                Direccion1 = (string)clienteElement.Element("direccion"),
                DeudaCliente1 = (int)clienteElement.Element("deuda")
            };
        }

        public static void RestarDeuda(int idCliente,int cobro)
        {
            XDocument doc = XDocument.Load(rutaXml);

            XElement clienteElement = doc.Descendants("cliente")
                .FirstOrDefault(x => (int)x.Element("IdCliente") == idCliente);

            if (clienteElement == null)
                throw new Exception("Cliente no encontrado para restar deuda.");

            int deudaActual = (int)clienteElement.Element("deuda");
            int nuevaDeuda = deudaActual - cobro;

            if (nuevaDeuda < 0)
                throw new Exception("La deuda no puede ser negativa.");

            clienteElement.Element("deuda").Value = nuevaDeuda.ToString();

            doc.Save(rutaXml);
        }

        public static void SumarDeuda(int idCliente,int monto1)
        {
            XDocument doc = XDocument.Load(rutaXml);

            XElement clienteElement = doc.Descendants("cliente")
                .FirstOrDefault(x => (int)x.Element("IdCliente") == idCliente);

            if (clienteElement == null)
                throw new Exception("Cliente no encontrado para sumar deuda.");

            int deudaActual = (int)clienteElement.Element("deuda");
            int nuevaDeuda = deudaActual + monto1;

            clienteElement.Element("deuda").Value = nuevaDeuda.ToString();

            doc.Save(rutaXml);
        }
    }
}

