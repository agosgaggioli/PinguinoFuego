using BE;
using CU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class ComponenteData
    {
        private static string rutaXml = "permisos.xml";

        private static string rutaGrupos = "grupos.xml";

        public static void AgregarPermisoAGrupo(string nombreGrupo, string nombrePermiso)
        {
          

            if (!File.Exists(rutaGrupos))
                throw new Exception("El archivo de grupos no existe.");

            XDocument doc = XDocument.Load(rutaGrupos);

            var grupoXml = doc.Descendants("Grupo")
                              .FirstOrDefault(g => g.Attribute("Nombre")?.Value == nombreGrupo);

            if (grupoXml == null)
                throw new Exception("Grupo no encontrado.");

          
            bool yaExiste = grupoXml.Elements("Permiso")
                                    .Any(p => p.Attribute("Nombre")?.Value == nombrePermiso);

            if (yaExiste)
                throw new Exception("Este permiso ya está asignado al grupo.");

           
            XElement nuevoPermiso = new XElement("Permiso", new XAttribute("Nombre", nombrePermiso));
            grupoXml.Add(nuevoPermiso);

            doc.Save(rutaGrupos);
        }

        public static List<Grupo> getAllGrupos()
        {
            List<Grupo> grupos = new List<Grupo>();
            string rutaGrupos = "grupos.xml";

            if (!File.Exists(rutaGrupos))
                return grupos;

            XDocument doc = XDocument.Load(rutaGrupos);

            foreach (var grupoXml in doc.Descendants("Grupo"))
            {
                string nombre = grupoXml.Attribute("Nombre")?.Value;
                if (!string.IsNullOrEmpty(nombre))
                {
                    grupos.Add(new Grupo(nombre));
                }
            }

            return grupos;

        }

        public static List<Permiso> getAllPermisos()
        {
            List<Permiso> permisos = new List<Permiso>();
            string rutaPermisos = "permisos.xml";

            if (!File.Exists(rutaPermisos))
                return permisos;

            XDocument doc = XDocument.Load(rutaPermisos);

            foreach (var permisoXml in doc.Descendants("Permiso"))
            {
                string nombre = permisoXml.Attribute("Nombre")?.Value;
                if (!string.IsNullOrEmpty(nombre))
                {
                    permisos.Add(new Permiso(nombre));
                }
            }

            return permisos;
        }

        public static void GuardarGrupo(Grupo grupo)
        {
            if (!File.Exists(rutaGrupos))
            {
                XDocument nuevoDoc = new XDocument(new XElement("Grupos"));
                nuevoDoc.Save(rutaGrupos);
            }

            XDocument doc = XDocument.Load(rutaGrupos);

            
            bool existe = doc.Descendants("Grupo")
                             .Any(g => g.Attribute("Nombre")?.Value == grupo.Nombre);

            if (existe)
                throw new Exception("Ya existe un grupo con ese nombre.");

            int ultimoId = doc.Descendants("Grupo")
                              .Select(c => (int?)c.Attribute("IdGrupo") ?? 0)
                              .DefaultIfEmpty(0)
                              .Max();

            int nuevoId = ultimoId + 1;
            grupo.Id = nuevoId;

           
            XElement nuevoGrupo = new XElement("Grupo",
                                     new XAttribute("IdGrupo", grupo.Id),
                                     new XAttribute("Nombre", grupo.Nombre)
                                   );

            doc.Element("Grupos").Add(nuevoGrupo);
            doc.Save(rutaGrupos);
        }

        public static void GuardarPermiso(Permiso permiso)
        {
            // Si el archivo no existe, lo creamos con una raíz
            if (!File.Exists(rutaXml))
            {
                XDocument docNuevo = new XDocument(new XElement("Permisos"));
                docNuevo.Save(rutaXml);
            }

            // Cargar el documento existente
            XDocument doc = XDocument.Load(rutaXml);

            // Verificar si ya existe un permiso con ese nombre
            bool existe = doc.Descendants("Permiso")
                             .Any(p => p.Attribute("Nombre")?.Value == permiso.Nombre);

            if (existe)
                throw new Exception("Ya existe un permiso con ese nombre.");

            // Crear el nuevo elemento
            XElement nuevoPermiso = new XElement("Permiso",
                                     new XAttribute("IdPermiso", permiso.Id),
                                      new XAttribute("Nombre", permiso.Nombre));

            // Agregarlo a la raíz
            doc.Element("Permisos").Add(nuevoPermiso);



            // Guardar el documento
            doc.Save(rutaXml);
        }
        public static List<Componente> CargarJerarquiaDesdeXML()
        {
            List<Componente> componentes = new List<Componente>();

            if (!File.Exists("grupos.xml"))
                return componentes;

            XDocument doc = XDocument.Load("grupos.xml");

            foreach (var grupoXml in doc.Descendants("Grupo"))
            {
                string nombreGrupo = grupoXml.Attribute("Nombre")?.Value;
                if (string.IsNullOrEmpty(nombreGrupo))
                    continue;

                Grupo grupo = new Grupo(nombreGrupo);

                // Recorrer los permisos hijos de ese grupo
                foreach (var permisoXml in grupoXml.Elements("Permiso"))
                {
                    string nombrePermiso = permisoXml.Attribute("Nombre")?.Value;
                    if (!string.IsNullOrEmpty(nombrePermiso))
                    {
                        Permiso permiso = new Permiso(nombrePermiso);
                        grupo.Agregar(permiso); // Acá se forma la relación
                    }
                }

                componentes.Add(grupo); // Agregamos el grupo con sus permisos
            }

            return componentes;
        }
        
        public static Grupo GetGrupoCompletoPorNombre(string nombreGrupo)
        {
            if (!File.Exists(rutaGrupos))
                return null;

            XDocument doc = XDocument.Load(rutaGrupos);

            var grupoXml = doc.Descendants("Grupo")
                              .FirstOrDefault(x => (string)x.Attribute("Nombre") == nombreGrupo);

            if (grupoXml == null)
                return null;

            Grupo grupo = new Grupo(nombreGrupo);

            foreach (var permisoXml in grupoXml.Elements("Permiso"))
            {
                string nombrePermiso = permisoXml.Attribute("Nombre")?.Value;
                if (!string.IsNullOrEmpty(nombrePermiso))
                {
                    grupo.Agregar(new Permiso(nombrePermiso));
                }
            }

            return grupo;
        }

        public static Grupo GetByIdRol(int idRol)
        {
            XDocument doc = XDocument.Load(rutaGrupos);

            XElement RolElement = doc.Root.Elements("Grupo")
                .FirstOrDefault(x => (int?)x.Attribute("IdGrupo") == idRol);

            if (RolElement == null)
                return null;

            Grupo grupo = new Grupo
            {
                Nombre = (string)RolElement.Attribute("Nombre"),
                Id = (int)RolElement.Attribute("IdGrupo")
            };

            return grupo;
        }

        public static void DeleteByIdRol(Grupo rol)
        {
            XDocument doc = XDocument.Load(rutaGrupos);

            XElement RolAEliminar = doc.Descendants("Grupo")
                .FirstOrDefault(x => (int?)x.Attribute("IdGrupo") == rol.Id);

            if (RolAEliminar == null)
                throw new Exception("Rol no encontrado para eliminar.");

            // Eliminar permisos relacionados si están fuera del nodo Grupo
            XElement permisosRoot = doc.Element("Permisos");
            if (permisosRoot != null)
            {
                var permisosAEliminar = permisosRoot.Elements("Permiso")
                    .Where(p => (int?)p.Attribute("IdGrupo") == rol.Id)
                    .ToList(); // Importante: materializar antes de eliminar

                foreach (var permiso in permisosAEliminar)
                    permiso.Remove();
            }

            RolAEliminar.Remove();
            doc.Save(rutaGrupos);
        }
        public static Permiso GetByIdPermiso(int id)
        {
            if (!File.Exists(rutaXml))
                return null;

            XDocument doc = XDocument.Load(rutaXml);

            var permisoXml = doc.Descendants("Permiso")
                                .FirstOrDefault(p => (int?)p.Attribute("IdPermiso") == id);

            if (permisoXml == null)
                return null;

            string nombre = permisoXml.Attribute("Nombre")?.Value;
            return new Permiso
            {
                Id = id,
                Nombre = nombre
            };
        }
        public static void DeleteByIdPermiso(Permiso permiso)
        {
            if (!File.Exists(rutaXml))
                throw new Exception("El archivo de permisos no existe.");

            XDocument doc = XDocument.Load(rutaXml);

            var permisoXml = doc.Descendants("Permiso")
                                .FirstOrDefault(p => (int?)p.Attribute("IdPermiso") == permiso.Id);

            if (permisoXml == null)
                throw new Exception("Permiso no encontrado.");

            permisoXml.Remove();
            doc.Save(rutaXml);
        }
        public static bool PermisoAsociadoAAlgunRol(string nombrePermiso)
        {
            if (!File.Exists(rutaGrupos))
                return false;

            XDocument doc = XDocument.Load(rutaGrupos);

            return doc.Descendants("Grupo")
                      .Elements("Permiso")
                      .Any(p => (string)p.Attribute("Nombre") == nombrePermiso);
        }
        public static void QuitarPermisoDeGrupo(string nombreGrupo, string nombrePermiso)
        {
            if (!File.Exists(rutaGrupos))
                throw new Exception("El archivo de grupos no existe.");

            XDocument doc = XDocument.Load(rutaGrupos);

            var grupoXml = doc.Descendants("Grupo")
                              .FirstOrDefault(g => g.Attribute("Nombre")?.Value == nombreGrupo);

            if (grupoXml == null)
                throw new Exception("Grupo no encontrado.");

            var permisoXml = grupoXml.Elements("Permiso")
                                     .FirstOrDefault(p => p.Attribute("Nombre")?.Value == nombrePermiso);

            if (permisoXml == null)
                throw new Exception("El permiso no está asociado al grupo.");

            permisoXml.Remove();
            doc.Save(rutaGrupos);
        }
    }

    

}
