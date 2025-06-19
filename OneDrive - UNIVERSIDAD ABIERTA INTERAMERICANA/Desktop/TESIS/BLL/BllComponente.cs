using BE;
using CU;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class BllComponente
    {
        public void AsignarPermisoAGrupo(string nombreGrupo, string nombrePermiso)
        {
            try
            {
                ComponenteData.AgregarPermisoAGrupo(nombreGrupo, nombrePermiso);

                Grupo grupoActualizado = ComponenteData.GetGrupoCompletoPorNombre(nombreGrupo);

                BllUsuario usuarioBusiness = new BllUsuario();
                usuarioBusiness.ActualizarGrupoDeUsuarios(grupoActualizado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        public static List<Grupo> getAllGrupos()
        {
            try
            {
                return ComponenteData.getAllGrupos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Permiso> getAllPermisos()
        {
            try
            {
                return ComponenteData.getAllPermisos();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GuardarGrupo(Grupo grupo)
        {
            try
            {

                ComponenteData.GuardarGrupo(grupo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }

        }

        public void GuardarPermiso(Permiso permiso)
        {
            try
            {
                ComponenteData.GuardarPermiso(permiso);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }

        }
        public static Grupo GetGrupoCompletoPorNombre(string nombreGrupo)
        {
            try
            {
                return ComponenteData.GetGrupoCompletoPorNombre(nombreGrupo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        public void DeleteByIdRol(int idRol)
        {
            try
            {
                Grupo rol = ComponenteData.GetByIdRol(idRol);
                if (rol == null)
                    throw new Exception("Rol inexistente");

                
                if (UsuarioData.GrupoEstaAsignadoAAlgunUsuario(rol.Nombre))
                    throw new Exception("No se puede eliminar el rol porque está asignado a uno o más usuarios.");

                
                    ComponenteData.DeleteByIdRol(rol);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el rol: " + ex.Message, ex);
            }
        }

        public void DeleteByIdPermiso(int id)
        {
            try
            {
                Permiso permiso = ComponenteData.GetByIdPermiso(id);
                if (permiso == null)
                    throw new Exception("Permiso inexistente");

                
                if (ComponenteData.PermisoAsociadoAAlgunRol(permiso.Nombre))
                    throw new Exception("No se puede eliminar el permiso porque está asignado a uno o más Roles.");

                
                    ComponenteData.DeleteByIdPermiso(permiso);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el Permiso: " + ex.Message, ex);
            }
        }
        public void DesasignarPermisoDeGrupo(string nombreGrupo, string nombrePermiso)
        {
            try
            {

               
                ComponenteData.QuitarPermisoDeGrupo(nombreGrupo, nombrePermiso);

                
                Grupo grupoActualizado = ComponenteData.GetGrupoCompletoPorNombre(nombreGrupo);

                BllUsuario usuarioBusiness = new BllUsuario();
                usuarioBusiness.ActualizarGrupoDeUsuarios(grupoActualizado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }


        }
    }
}
