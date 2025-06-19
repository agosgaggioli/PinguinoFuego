using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class VendedorData
    {
        private static string rutaXml = "Vendedores.xml"; 
        public List<BeVendedor> getAll()
        {
            XDocument doc = XDocument.Load(rutaXml);

            var vendedor = doc.Descendants("Vendedor")
                .Select(x => new BeVendedor
                {
                    NombreVendedor1 = (string)x.Element("Nombre"),
                    DniVendedor1 = (int)x.Element("DNI"),
                    ApellidoVendedor1 = (string)x.Element("Apellido"),
                    IdVendedor1 = (int)x.Element("IDVendedor")
                })
                .ToList();

            return vendedor;
        }

        public BeVendedor GetById(int idVendedor)
        {
            XDocument doc = XDocument.Load(rutaXml);

            var x = doc.Descendants("Vendedor")
                .FirstOrDefault(x => (int)x.Element("IDVendedor") == idVendedor);

            if (x == null)
                return null;

            return new BeVendedor
            {
                NombreVendedor1 = (string)x.Element("Nombre"),
                DniVendedor1 = (int)x.Element("DNI"),
                ApellidoVendedor1 = (string)x.Element("Apellido"),
                IdVendedor1 = (int)x.Element("IDVendedor")
            };
        }
    }
}
