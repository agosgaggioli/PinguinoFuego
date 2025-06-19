using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL
{
    public class BllVehiculo
    {
        public void cargaraVehiculo(BeVehiculo vehiculo)
        {

            try
            {
           
                if (vehiculo.Precio1 <= 0)
                    throw new Exception("El precio no puede ser 0 o menor.");

                if (string.IsNullOrWhiteSpace(vehiculo.Marca1))
                    throw new Exception("La marca es obligatoria.");

                if (string.IsNullOrWhiteSpace(vehiculo.Version1))
                    throw new Exception("La versión es obligatoria.");

                int añoActual = DateTime.Now.Year;
                if (vehiculo.Año1 < 1950 || vehiculo.Año1 > añoActual)
                    throw new Exception($"El año debe estar entre 1950 y {añoActual}.");

                vehiculo.PrecioContado1 = vehiculo.Precio1 * 1.05m;
                    vehiculo.PrecioConUsado1 = vehiculo.Precio1 * 1.10m;


                    VehiculoData.cargarVehiculo(vehiculo);
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                BeVehiculo vehiculo = VehiculoData.GetById(id);
                if (vehiculo == null) throw new Exception("Vehiculo inexistente");
               
                VehiculoData.DeleteById(vehiculo);
               

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<BeVehiculo> getAll()
        {
            try
            {
                return VehiculoData.getAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BeVehiculo getById(int idVehiculo)
        {
            try
            {
                return VehiculoData.GetById(idVehiculo);
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        public void Update(int Id, int NuevoPrecio)
        {
            try
            {
                BeVehiculo vehiculo = VehiculoData.GetById(Id);
                if (vehiculo == null) throw new Exception("Vehiculo inexistente");
                if (NuevoPrecio < 0) throw new Exception("Precio no puede ser menor a 0");
                vehiculo.Precio1 = NuevoPrecio;
                vehiculo.PrecioContado1 = NuevoPrecio * 1.05m;
                vehiculo.PrecioConUsado1= NuevoPrecio * 1.10m;

                VehiculoData.Update(vehiculo);

            }
            catch (Exception ex) { throw; }
        }
    }
}
