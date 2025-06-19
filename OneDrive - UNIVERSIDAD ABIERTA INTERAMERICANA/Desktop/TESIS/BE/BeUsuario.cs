using CU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BeUsuario
    {

        public string Nombre { get; set; }
        public int IdUsuario { get; set; }
        public string Contrasenia { get; set; }
        public List<Componente> Permisos { get; set; } = new();
        public BeUsuario(string nombre, string contrasenia = "")
        {
            Nombre = nombre;
            Contrasenia = contrasenia;
        }
        public BeUsuario() { }

        public void AgregarPermiso(Componente permiso) => Permisos.Add(permiso);
        public bool TienePermiso(string permiso)
        {
            return Permisos.Any(p => p.TienePermiso(permiso));
        }
    }
}
