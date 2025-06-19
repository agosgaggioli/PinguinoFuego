using BE;
using CU;
using DAL;
using Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace BLL
{
    public class BllUsuario
    {
        private List<BeUsuario> usuarios;
        UsuarioData UsuarioData = new UsuarioData();
        public void CargarUs(BeUsuario beUsuario)
        {
            try
            {
              
                    beUsuario.Contrasenia = Encriptacion.EncriptarPassword(beUsuario.Contrasenia);

                    UsuarioData.crearUsuario(beUsuario);
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<BeUsuario> getAllUs()
        {
            try
            {
                return UsuarioData.getALL();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void AgregarRolAUsuario(string nombreUsuario, Grupo grupo)
        {
            try
            {
                if (string.IsNullOrEmpty(nombreUsuario))
                    throw new ArgumentException("El nombre del usuario no puede estar vacío.");

                if (grupo == null)
                    throw new ArgumentNullException(nameof(grupo));


                UsuarioData.AgregarRolAUsuario(nombreUsuario, grupo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
        public BeUsuario ObtenerUsuarioConPermisos(string nombreUsuario)
        {
            XElement usuarioElem = UsuarioData.ObtenerUsuarioPorNombre(nombreUsuario);
            if (usuarioElem == null) return null;

            BeUsuario usuario = new BeUsuario(nombreUsuario);

            var permisosElem = usuarioElem.Element("Permisos");
            if (permisosElem != null)
            {
                foreach (var grupoElem in permisosElem.Elements("Grupo"))
                {
                    string nombreGrupo = (string)grupoElem.Attribute("Nombre");
                    Grupo grupo = new Grupo(nombreGrupo);

                    foreach (var permisoElem in grupoElem.Elements("Permiso"))
                    {
                        string nombrePermiso = permisoElem.Value;
                        Permiso permiso = new Permiso(nombrePermiso);
                        grupo.Agregar(permiso);
                    }

                    usuario.AgregarPermiso(grupo);
                }
            }

            return usuario;
        }

        public void DeleteById(int IdUs)
        {
            try
            {
                BeUsuario us = UsuarioData.GetById(IdUs);
                if (us == null) throw new Exception("Usuario inexistente");
                

                    UsuarioData.DeleteById(us);


            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void ActualizarGrupoDeUsuarios(Grupo grupoActualizado)
        {
            try
            {
                List<BeUsuario> usuarios = UsuarioData.getALL();

                foreach (var usuario in usuarios)
                {
                    bool requiereActualizar = usuario.Permisos
                        .OfType<Grupo>()
                        .Any(g => g.Nombre == grupoActualizado.Nombre);

                    if (requiereActualizar)
                    {
                        UsuarioData.ActualizarGrupoDeUsuario(usuario.Nombre, grupoActualizado);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
        public static void QuitarRolDeUsuario(string nombreUsuario, string nombreRol)
        {
            try
            {
                UsuarioData.QuitarRolDeUsuario(nombreUsuario, nombreRol);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        public BeUsuario ObtenerUsuarioConPermisoss(string nombreUsuario)
        {
            try
            {
                return UsuarioData.ObtenerUsuarioConPermisos(nombreUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
    }
}

