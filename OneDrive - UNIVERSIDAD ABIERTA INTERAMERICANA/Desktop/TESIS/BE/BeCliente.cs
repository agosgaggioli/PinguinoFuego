namespace BE
{
    public class BeCliente
    {
        private string DniCliente;
        private string ApellidoCliente ;
        private string NombreCliente;
        private int DeudaCliente;
        private string Direccion;
        private int IdCliente;
      
        public string DniCliente1 { get => DniCliente; set => DniCliente = value; }
        public string ApellidoCliente1 { get => ApellidoCliente; set => ApellidoCliente = value; }
        public string NombreCliente1 { get => NombreCliente; set => NombreCliente = value; }
        public int DeudaCliente1 { get => DeudaCliente; set => DeudaCliente = value; }
        public string Direccion1 { get => Direccion; set => Direccion = value; }
        public int IdCliente1 { get => IdCliente; set => IdCliente = value; }
        public string ClienteDisplay
        {
            get => $"{DniCliente1} - {NombreCliente1} {ApellidoCliente1}";
        }

    }
}
