using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU
{
    public class Grupo : Componente
    {
        private List<Componente> _hijos = new List<Componente>();


        public Grupo(string nombre) : base(nombre)
        {
        }

        public Grupo() : base("")  
        {
        }

        public override void Agregar(Componente c)
        {
            _hijos.Add(c);
        }

        public override void Quitar(Componente c)
        {
            _hijos.Remove(c);
        }

        public override List<Componente> ObtenerHijos()
        {
            return _hijos;
        }

        public override bool TienePermiso(string permiso)
        {
            foreach (var hijo in _hijos)
            {
                if (hijo.TienePermiso(permiso))
                    return true;
            }
            return false;
        }
    }
}
