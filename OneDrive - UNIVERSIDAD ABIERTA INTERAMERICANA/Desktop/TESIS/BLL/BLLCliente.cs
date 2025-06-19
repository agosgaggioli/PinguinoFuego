using static System.Net.Mime.MediaTypeNames;
using System.Transactions;
using BE;
using DAL;
using System.Threading;

namespace BLL
{
    public class BLLCliente
    {
        public void cargaraCliente(BeCliente Cliente)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(Cliente.DniCliente1))
                    throw new ArgumentException("El DNI no puede estar vacío.");

                if (string.IsNullOrWhiteSpace(Cliente.NombreCliente1))
                    throw new ArgumentException("El nombre no puede estar vacío.");

                if (string.IsNullOrWhiteSpace(Cliente.ApellidoCliente1))
                    throw new ArgumentException("El apellido no puede estar vacío.");

                if (string.IsNullOrWhiteSpace(Cliente.Direccion1))
                    throw new ArgumentException("La dirección no puede estar vacía.");

                ClienteData.crearCliente(Cliente);
                    
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<BeCliente> getAll()
        {
            try
            {
                return ClienteData.getAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteById(int idCliente)
        {
            try
            {
                if (idCliente <= 0)
                      throw new ArgumentException("Debe ser un numero mayor a 0 el id del cliente eliminar.");
                BeCliente cliente = ClienteData.GetById(idCliente);
                if (cliente == null) throw new Exception("Cliente inexistente");
               
                    ClienteData.DeleteById(cliente);
                   
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BeCliente getById(int idCliente)
        {
            return ClienteData.GetById(idCliente);
        }

        public void RestarDeuda(int id, int cobro1)
        {
            try
            {
                ClienteData.RestarDeuda(id,cobro1);  
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SumarDeuda(int id, int monto1)
        {
            try
            {
              ClienteData.SumarDeuda(id,monto1);    
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
