using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class ProveedorData
    {
        private static string rutaXml = "Proveedor.xml";
        public static void AgregarProveedor(BeProveedor beProveedor)
        {
           
            if (!File.Exists(rutaXml))
            {
                new XDocument(
                    new XElement("provedores")
                ).Save(rutaXml);
            }

            XDocument doc = XDocument.Load(rutaXml);

            bool existe = doc.Descendants("proveedor")
                             .Any(c => (string)c.Element("Razonsocial") == beProveedor.RazonSocial1);

            if (existe)
            {
                throw new Exception("Ya existe un proveedor con esa Razon Social");
            }
           
            int ultimoId = doc.Descendants("proveedor")
                              .Select(c => (int?)c.Element("IdProveedor") ?? 0)
                              .DefaultIfEmpty(0)
                              .Max();

            int nuevoId = ultimoId + 1;
            beProveedor.IdProveedor1 = nuevoId; 

            
            XElement nuevoProveedor = new XElement("proveedor",
                new XElement("Razonsocial", beProveedor.RazonSocial1),
                new XElement("Contacto", beProveedor.Contacto1),
                new XElement("Direccion", beProveedor.Direccion1),
                new XElement("Deuda", beProveedor.Deuda),
                new XElement("IdProveedor", beProveedor.IdProveedor1)
            );

            
            doc.Element("provedores").Add(nuevoProveedor);
            doc.Save(rutaXml);
        }

        public static void DeleteById(BeProveedor proveedor)
        {
            XDocument doc = XDocument.Load(rutaXml);

            XElement ProveedorAEliminar = doc.Descendants("proveedor")
                .FirstOrDefault(x => (int)x.Element("IdProveedor") == proveedor.IdProveedor1);

            if (ProveedorAEliminar == null)
                throw new Exception("Proveedor no encontrado para eliminar.");

            ProveedorAEliminar.Remove();

            doc.Save(rutaXml); 
        }

        public static List<BeProveedor> getAll()
        {
            if (!File.Exists(rutaXml))
            {
                
                XDocument nuevoDoc = new XDocument(new XElement("provedores"));
                nuevoDoc.Save(rutaXml);
                return new List<BeProveedor>();
            }
            XDocument doc = XDocument.Load(rutaXml);

            var Provedores = doc.Descendants("proveedor")
                .Select(x => new BeProveedor
                {
                    IdProveedor1 = (int)x.Element("IdProveedor"),
                    Contacto1 = (string)x.Element("Contacto"),
                    Deuda = (int)x.Element("Deuda"),
                    RazonSocial1 = (string)x.Element("Razonsocial"),
                    Direccion1 = (string)x.Element("Direccion")
                })
                .ToList();

            return Provedores;
        }

        public static BeProveedor GetById(int idproveedor)
        {
            XDocument doc = XDocument.Load(rutaXml);

            var ProveedorElement = doc.Descendants("proveedor")
                .FirstOrDefault(x => (int)x.Element("IdProveedor") == idproveedor);

            if (ProveedorElement == null)
                return null;

            return new BeProveedor
            {
                RazonSocial1 = (string)ProveedorElement.Element("Razonsocial"),
                Direccion1 = (string)ProveedorElement.Element("Direccion"),
                IdProveedor1 = (int)ProveedorElement.Element("IdProveedor"),
                Deuda = (int)ProveedorElement.Element("Deuda"),
                Contacto1 = (string)ProveedorElement.Element("Contacto")
            };
        }

        public static void SumarDeuda(int idProveedor1, int monto1)
        {
            XDocument doc = XDocument.Load(rutaXml);

            XElement proveedorElement = doc.Descendants("proveedor")
                .FirstOrDefault(x => (int)x.Element("IdProveedor") == idProveedor1);

            if (proveedorElement == null)
                throw new Exception("Proveedor no encontrado para sumar deuda.");

            int deudaActual = (int)proveedorElement.Element("Deuda");
            int nuevaDeuda = deudaActual + monto1;

            proveedorElement.Element("Deuda").Value = nuevaDeuda.ToString();

            doc.Save(rutaXml);
        }
        public static void RestarDeuda(int idProveedor, int pago)
        {
            XDocument doc = XDocument.Load(rutaXml);

            XElement proveedorElement = doc.Descendants("proveedor")
                .FirstOrDefault(x => (int)x.Element("IdProveedor") == idProveedor);

            if (proveedorElement == null)
                throw new Exception("Proveedor no encontrado para restar deuda.");

            int deudaActual = (int)proveedorElement.Element("Deuda");
            int nuevaDeuda = deudaActual - pago;

            if (nuevaDeuda < 0)
                throw new Exception("La deuda no puede ser negativa.");

            proveedorElement.Element("Deuda").Value = nuevaDeuda.ToString();

            doc.Save(rutaXml);
        }
    }

}
