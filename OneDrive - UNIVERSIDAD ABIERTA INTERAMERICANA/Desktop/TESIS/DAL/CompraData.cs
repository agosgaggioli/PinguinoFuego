using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class CompraData
    {
        private static string rutaXml = "Compra.xml"; 
        public static void crearCompra(BeCompra compra)
        {
           
            if (!File.Exists(rutaXml))
            {
                new XDocument(
                    new XElement("compras")
                ).Save(rutaXml);
            }

            XDocument doc = XDocument.Load(rutaXml);

        
            
            int ultimoId = doc.Descendants("compra")
                              .Select(c => (int?)c.Element("IdCompra") ?? 0)
                              .DefaultIfEmpty(0)
                              .Max();

            int nuevoId = ultimoId + 1;
            compra.IdCompra1
                = nuevoId; 


            
            XElement nuevaCompra = new XElement("compra",
                new XElement("IdCompra", compra.IdCompra1),
                new XElement("Monto", compra.Monto1),
                new XElement("Descripcion", compra.Descripcion1),
                new XElement("Fecha", compra.Fecha),
                new XElement("IdProveedor", compra.IdProveedor1),
                new XElement("RazonSocial", compra.RazonSocialProvedor1)
            );

          
            doc.Element("compras").Add(nuevaCompra);
            doc.Save(rutaXml);
        }
        public static string ObtenerProveedorMasFrecuente()
        {
            if (!File.Exists(rutaXml))
                return "Sin datos";

            XDocument doc = XDocument.Load(rutaXml);

            var proveedores = doc.Descendants("compra")
                .GroupBy(c => (string)c.Element("RazonSocial"))
                .Select(g => new
                {
                    RazonSocial = g.Key,
                    Cantidad = g.Count()
                })
                .OrderByDescending(p => p.Cantidad)
                .FirstOrDefault();

            return proveedores != null ? proveedores.RazonSocial : "Sin datos";
        }
    }
}
