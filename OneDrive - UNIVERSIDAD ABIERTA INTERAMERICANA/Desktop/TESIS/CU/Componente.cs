namespace CU
{
    public abstract class  Componente
    {
        public string Nombre { get; set; }
        public int Id { get; set; }

        public Componente(string nombre)
        {
            Nombre = nombre;
        }

        public abstract void Agregar(Componente c);
        public abstract void Quitar(Componente c);
        public abstract List<Componente> ObtenerHijos();
        public abstract bool TienePermiso(string permiso);
    }
}
