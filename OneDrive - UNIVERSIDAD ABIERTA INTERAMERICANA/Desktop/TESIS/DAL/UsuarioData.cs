using BE;
using CU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class UsuarioData
    {
        private static readonly string archivoUsuarios = "usuarios.xml";
        
        public static void crearUsuario(BeUsuario usuario)
        {
            XDocument doc;

            if (File.Exists(archivoUsuarios))
                doc = XDocument.Load(archivoUsuarios);
            else
                doc = new XDocument(new XElement("Usuarios"));
            int ultimoId = doc.Descendants("Usuario")
                             .Select(c => (int?)c.Element("IdUsuario") ?? 0)
                             .DefaultIfEmpty(0)
                             .Max();

            int nuevoId = ultimoId + 1;
            usuario.IdUsuario = nuevoId; 


            XElement usuarioElem = new XElement("Usuario",
                new XElement("Nombre", usuario.Nombre),
                new XElement("IdUsuario", usuario.IdUsuario),
                new XElement("Contrasenia", usuario.Contrasenia),
                new XElement("Permisos",
                    usuario.Permisos.Select(p => ComponenteToXElement(p))
                )
            );

            doc.Root.Add(usuarioElem);

            doc.Save(archivoUsuarios);
        }

        public static List<BeUsuario> getALL()
        {
            List<BeUsuario> usuarios = new List<BeUsuario>();

            if (!File.Exists(archivoUsuarios))
                return usuarios;

            XDocument doc = XDocument.Load(archivoUsuarios);

            foreach (var usuarioElem in doc.Descendants("Usuario"))
            {
                string nombre = usuarioElem.Element("Nombre")?.Value ?? string.Empty;
                string contrasenia = usuarioElem.Element("Contrasenia")?.Value ?? string.Empty;

                BeUsuario usuario = new BeUsuario(nombre);
                usuario.Contrasenia = contrasenia; 

                var permisosElem = usuarioElem.Element("Permisos");
                if (permisosElem != null)
                {
                    foreach (var compElem in permisosElem.Elements())
                    {
                        usuario.AgregarPermiso(XElementToComponente(compElem));
                    }
                }

                usuarios.Add(usuario);
            }

            return usuarios;
        }


        private static XElement ComponenteToXElement(Componente componente)
        {
            if (componente is Permiso)
            {
                return new XElement("Permiso", componente.Nombre);
            }
            else if (componente is Grupo grupo)
            {
                return new XElement("Grupo",
                    new XAttribute("Nombre", grupo.Nombre),
                    grupo.ObtenerHijos().Select(hijo => ComponenteToXElement(hijo))
                );
            }
            else
            {
                throw new InvalidDataException("Componente desconocido");
            }
        }

        
        private static Componente XElementToComponente(XElement elem)
        {
            if (elem.Name == "Permiso")
            {
                return new Permiso(elem.Value);
            }
            else if (elem.Name == "Grupo")
            {
                string nombre = elem.Attribute("Nombre")?.Value ?? "GrupoSinNombre";
                Grupo grupo = new Grupo(nombre);

                foreach (var hijoElem in elem.Elements())
                {
                    grupo.Agregar(XElementToComponente(hijoElem));
                }

                return grupo;
            }
            else
            {
                throw new InvalidDataException($"Elemento XML desconocido: {elem.Name}");
            }
        }
        public static void AgregarRolAUsuario(string nombreUsuario, Grupo rol)
        {
            if (!File.Exists(archivoUsuarios))
                throw new Exception("El archivo de usuarios no existe.");

            XDocument doc = XDocument.Load(archivoUsuarios);

          
            var usuarioElem = doc.Descendants("Usuario")
                                 .FirstOrDefault(u => (string)u.Element("Nombre") == nombreUsuario);

            if (usuarioElem == null)
                throw new Exception("Usuario no encontrado.");

            var permisosElem = usuarioElem.Element("Permisos");
            if (permisosElem == null)
            {
                permisosElem = new XElement("Permisos");
                usuarioElem.Add(permisosElem);
            }

           
            bool yaTieneRol = permisosElem.Elements("Grupo")
                                .Any(g => (string)g.Attribute("Nombre") == rol.Nombre);

            if (yaTieneRol)
                throw new Exception("El usuario ya tiene asignado ese rol.");

           
            XElement rolXml = ComponenteToXElement(rol);

           
            permisosElem.Add(rolXml);

            
            doc.Save(archivoUsuarios);
        }
        public XElement ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            XDocument doc = XDocument.Load("usuarios.xml");

            var usuarioElem = doc.Descendants("Usuario")
                                 .FirstOrDefault(u => (string)u.Element("Nombre") == nombreUsuario);

            return usuarioElem;
        }

        public void DeleteById(BeUsuario us)
        {
            XDocument doc = XDocument.Load(archivoUsuarios);

            XElement UsuarioAEliminar = doc.Descendants("Usuario")
                .FirstOrDefault(x => (int)x.Element("IdUsuario") == us.IdUsuario);

            if (UsuarioAEliminar == null)
                throw new Exception("Usuario no encontrado para eliminar.");

            UsuarioAEliminar.Remove(); 

            doc.Save(archivoUsuarios); 
        }

        public BeUsuario GetById(int idUs)
        {
            XDocument doc = XDocument.Load(archivoUsuarios);

            XElement usuarioElement = doc.Root.Elements("Usuario")
                .FirstOrDefault(x => (int)x.Element("IdUsuario") == idUs);

            if (usuarioElement == null)
                return null;

            BeUsuario us = new BeUsuario
            {
                IdUsuario = (int)usuarioElement.Element("IdUsuario"),
                Nombre = (string)usuarioElement.Element("Nombre"),
                Contrasenia = (string)usuarioElement.Element("Contrasenia")
            };

            return us;
        }
        public static bool GrupoEstaAsignadoAAlgunUsuario(string nombreGrupo)
        {
            if (!File.Exists(archivoUsuarios))
                return false;

            XDocument doc = XDocument.Load(archivoUsuarios);

            return doc.Descendants("Usuario")
                      .Elements("Permisos")
                      .Elements("Grupo")
                      .Any(g => g.Attribute("Nombre")?.Value == nombreGrupo);
        }
        public static void ActualizarGrupoDeUsuario(string nombreUsuario, Grupo grupoActualizado)
        {
            XDocument doc = XDocument.Load(archivoUsuarios);

            var usuarioElem = doc.Descendants("Usuario")
                                 .FirstOrDefault(u => (string)u.Element("Nombre") == nombreUsuario);

            if (usuarioElem == null)
                throw new Exception("Usuario no encontrado");

            var permisosElem = usuarioElem.Element("Permisos");
            if (permisosElem == null)
                permisosElem = new XElement("Permisos");

            
            var grupoXml = permisosElem.Elements("Grupo")
                                       .FirstOrDefault(g => (string)g.Attribute("Nombre") == grupoActualizado.Nombre);

            if (grupoXml != null)
            {
                grupoXml.ReplaceWith(UsuarioData.ComponenteToXElement(grupoActualizado)); 
            }

            doc.Save(archivoUsuarios);
        }
        public static void QuitarRolDeUsuario(string nombreUsuario, string nombreRol)
        {
            if (!File.Exists(archivoUsuarios))
                throw new Exception("El archivo de usuarios no existe.");

            XDocument doc = XDocument.Load(archivoUsuarios);

            var usuarioElem = doc.Descendants("Usuario")
                                 .FirstOrDefault(u => (string)u.Element("Nombre") == nombreUsuario);

            if (usuarioElem == null)
                throw new Exception("Usuario no encontrado.");

            var permisosElem = usuarioElem.Element("Permisos");

            if (permisosElem == null)
                throw new Exception("El usuario no tiene permisos asignados.");

            var grupoElem = permisosElem.Elements("Grupo")
                                       .FirstOrDefault(g => (string)g.Attribute("Nombre") == nombreRol);

            if (grupoElem == null)
                throw new Exception("El rol no está asignado al usuario.");

            grupoElem.Remove();

            doc.Save(archivoUsuarios);
        }
        public static BeUsuario ObtenerUsuarioConPermisos(string nombreUsuario)
        {
            if (!File.Exists(archivoUsuarios))
                return null;

            XDocument doc = XDocument.Load(archivoUsuarios);

            var usuarioElem = doc.Descendants("Usuario")
                                 .FirstOrDefault(u => (string)u.Element("Nombre") == nombreUsuario);

            if (usuarioElem == null)
                return null;

            BeUsuario usuario = new BeUsuario(nombreUsuario)
            {
                IdUsuario = (int)usuarioElem.Element("IdUsuario"),
                Contrasenia = (string)usuarioElem.Element("Contrasenia")
            };

            var permisosElem = usuarioElem.Element("Permisos");
            if (permisosElem != null)
            {
                foreach (var compElem in permisosElem.Elements())
                {
                    usuario.AgregarPermiso(XElementToComponente(compElem));
                }
            }

            return usuario;
        }
    }

}
