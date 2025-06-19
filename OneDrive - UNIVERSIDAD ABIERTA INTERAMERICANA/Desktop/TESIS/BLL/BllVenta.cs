using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class BllVenta
    {

        BllFactura bllFactura= new BllFactura();
        BLLCliente bLLCliente= new BLLCliente();
        BllVehiculo bllvehiculo= new BllVehiculo();
        public void CrearVenta(BeVenta venta)
        {

            try
            {
                
                    if (venta.IdVendedor1 <= 0)
                    {
                        throw new Exception("El id vendedor no puede ser menor a 0");
                    }
                    if (venta.IdCliente1 <= 0)
                    {
                        throw new Exception("El id cliente no puede ser menor a 0");
                    }
                    if (venta.IdVehiculo1 <= 0)
                    {
                        throw new Exception("El id vehiculo no puede ser menor a 0");
                    }
                    venta.Fecha1 = DateTime.Now;
                    VentaData.crearVenta(venta);
                    bLLCliente.SumarDeuda(venta.IdCliente1, venta.Monto1);
                    bllvehiculo.DeleteById(venta.IdVehiculo1);
                    bllFactura.CrearFactura( venta);
                    
             
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public List<BeVenta> getAll(int cantidad)
        {
            try
            {
                var todasVentas = VentaData.getAll();

                if (cantidad == 0)
                {
                    return todasVentas;  
                }
                else
                {
                    DateTime fechaLimite = DateTime.Now.AddDays(-cantidad);

                    
                    var ventasFiltradas = todasVentas.Where(v => v.Fecha1 >= fechaLimite).ToList();

                    return ventasFiltradas;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public Dictionary<int, int> ObtenerCantidadVentasPorVendedor(int cantidad)
        {
            try {
                List<BeVenta> ventas;

                if (cantidad == 0)
                {
                    ventas = getAll(0); 
                }
                else
                {
                    DateTime fechaInicio;

                    if (cantidad == 30)
                    {
                        fechaInicio = DateTime.Now.AddMonths(-1);
                    }
                    else if (cantidad == 365)
                    {
                        fechaInicio = DateTime.Now.AddYears(-1);
                    }
                    else
                    {
                        fechaInicio = DateTime.Now.AddDays(-cantidad);
                    }

                    ventas = getAll(0) 
                        .Where(v => v.Fecha1 >= fechaInicio)
                        .ToList();
                }

               
                var resultado = ventas
                    .GroupBy(v => v.IdVendedor1)
                    .ToDictionary(g => g.Key, g => g.Count());

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public decimal ObtnerMontoTotalFacturacion(int cantidad)
        {
            try
            {
                List<BeVenta> ventas;

                if (cantidad == 0)
                {
                    ventas = VentaData.getAll(); 
                }
                else
                {
                    DateTime fechaInicio;

                    if (cantidad == 30)
                    {
                        fechaInicio = DateTime.Now.AddMonths(-1);
                    }
                    else if (cantidad == 365)
                    {
                        fechaInicio = DateTime.Now.AddYears(-1);
                    }
                    else
                    {
                        fechaInicio = DateTime.Now.AddDays(-cantidad);
                    }

                    ventas = VentaData.getAll()
                        .Where(v => v.Fecha1 >= fechaInicio)
                        .ToList();
                }

                return ventas.Sum(v => v.Monto1);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int ObtenerCantidadTotalVentas(int cantidad)
        {
            try
            {
                List<BeVenta> ventas;

                if (cantidad == 0)
                {
                    ventas = VentaData.getAll(); 
                }
                else
                {
                    DateTime fechaInicio;

                    if (cantidad == 30)
                        fechaInicio = DateTime.Now.AddMonths(-1);
                    else if (cantidad == 365)
                        fechaInicio = DateTime.Now.AddYears(-1);
                    else
                        fechaInicio = DateTime.Now.AddDays(-cantidad);

                    ventas = VentaData.getAll()
                        .Where(v => v.Fecha1 >= fechaInicio)
                        .ToList();
                }

                return ventas.Count();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static Dictionary<string, int> ObtenerCantidadVentasPorMarca(int cantidad)
        {
            try {
                List<BeVenta> ventas;

                if (cantidad == 0)
                {
                    ventas = VentaData.getAll(); 
                }
                else
                {
                    DateTime fechaInicio;

                    if (cantidad == 30)
                        fechaInicio = DateTime.Now.AddMonths(-1);
                    else if (cantidad == 365)
                        fechaInicio = DateTime.Now.AddYears(-1);
                    else
                        fechaInicio = DateTime.Now.AddDays(-cantidad);

                    ventas = VentaData.getAll()
                        .Where(v => v.Fecha1 >= fechaInicio)
                        .ToList();
                }

                
                return ventas
                    .GroupBy(v => v.MarcaVehiculo)
                    .ToDictionary(g => g.Key, g => g.Count());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static Dictionary<int, int> ObtenerCantidadVentasPorAño()
        {
            try
            {
                List<BeVenta> ventas = VentaData.getAll();

                Dictionary<int, int> ventasPorAño = ventas
                    .GroupBy(v => v.Fecha1.Year)
                    .ToDictionary(g => g.Key, g => g.Count());

                return ventasPorAño;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
