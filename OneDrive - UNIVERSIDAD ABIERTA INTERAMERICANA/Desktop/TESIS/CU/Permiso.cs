using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU
{
    public class Permiso : Componente
    {
        public Permiso(string nombre) : base(nombre) { }
        public Permiso() : base("")  
        {
        }

        public override void Agregar(Componente c)
        {
            throw new NotImplementedException("No se pueden agregar permisos a un permiso simple.");
        }

        public override void Quitar(Componente c)
        {
            throw new NotImplementedException("No se pueden quitar permisos de un permiso simple.");
        }

        public override List<Componente> ObtenerHijos()
        {
            return new List<Componente>(); 
        }

        public override bool TienePermiso(string permiso)
        {
            return Nombre.Equals(permiso, StringComparison.OrdinalIgnoreCase);
        }
    }
}
