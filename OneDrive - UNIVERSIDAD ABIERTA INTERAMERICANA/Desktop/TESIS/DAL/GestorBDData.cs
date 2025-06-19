using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class GestorBDData
    {
        private static string carpetaBackup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Backups");
        private static string rutaXml = Path.Combine(carpetaBackup, "backup.xml");

        public static void CrearBackup()
        {

            Directory.CreateDirectory(carpetaBackup);

           
            if (!File.Exists(rutaXml))
            {
                new XDocument(new XElement("backups")).Save(rutaXml);
            }

            
            string carpetaActual = AppDomain.CurrentDomain.BaseDirectory;
            var archivosXml = Directory.GetFiles(carpetaActual, "*.xml")
                                       .Where(f => Path.GetFileName(f).ToLower() != "backup.xml")
                                       .ToList();

            
            string nombreCarpeta = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}";
            string rutaCarpeta = Path.Combine(carpetaBackup, nombreCarpeta);
            Directory.CreateDirectory(rutaCarpeta);

            
            foreach (var archivo in archivosXml)
            {
                string destino = Path.Combine(rutaCarpeta, Path.GetFileName(archivo));
                File.Copy(archivo, destino, true);
            }

           
            XDocument doc = XDocument.Load(rutaXml);
            int ultimoId = doc.Descendants("backup")
                              .Select(b => (int?)b.Element("IdBackup") ?? 0)
                              .DefaultIfEmpty(0)
                              .Max();

            int nuevoId = ultimoId + 1;

            XElement nuevoBackup = new XElement("backup",
                new XElement("IdBackup", nuevoId),
                new XElement("Fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                new XElement("Carpeta", nombreCarpeta),
                new XElement("Archivos", string.Join(", ", archivosXml.Select(Path.GetFileName)))
            );



            doc.Element("backups").Add(nuevoBackup);
            doc.Save(rutaXml);
        }
        public static List<BeBackUp> ObtenerBackups()
        {
            List<BeBackUp> backups = new List<BeBackUp>();

            if (!File.Exists(rutaXml))
                return backups;

            XDocument doc = XDocument.Load(rutaXml);

            foreach (XElement backup in doc.Descendants("backup"))
            {
                BeBackUp b = new BeBackUp
                {
                    IdBackUP = int.Parse(backup.Element("IdBackup").Value),
                    Fecha = DateTime.Parse(backup.Element("Fecha").Value),
                    Detalle = backup.Element("Carpeta").Value
                };

                backups.Add(b);
            }

            return backups;
        }
        public static void CrearRestore(string nombreCarpetaBackup)
        {
            string rutaCarpetaBackup = Path.Combine(carpetaBackup, nombreCarpetaBackup);

            if (!Directory.Exists(rutaCarpetaBackup))
                throw new Exception("La carpeta de backup no existe.");

           
            var archivosBackup = Directory.GetFiles(rutaCarpetaBackup, "*.xml");

            foreach (var archivo in archivosBackup)
            {
                string nombreArchivo = Path.GetFileName(archivo);

                
                if (nombreArchivo.Equals("bitacora.xml", StringComparison.OrdinalIgnoreCase))
                    continue;

                string destino = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nombreArchivo);

                
                File.Copy(archivo, destino, true);
            }
        }

    }
}
