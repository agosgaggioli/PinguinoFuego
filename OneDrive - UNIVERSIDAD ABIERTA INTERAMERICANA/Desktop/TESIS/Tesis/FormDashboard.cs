using BE;
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI
{
    public partial class FormDashboard : Form
    {
        BllVenta bllVenta = new BllVenta();
        BllVehiculo bllVehiculo = new BllVehiculo();
        BllCompra BllCompra = new BllCompra();
        private int cantidad;
        private BeUsuario _us;
        public FormDashboard(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {
            
            button2.Enabled = _us.TienePermiso("Un mes Filtro dh");
            button3.Enabled = _us.TienePermiso("Un año Filtro dh");
            button4.Enabled = _us.TienePermiso("Todas Filtro dh");
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            cantidad = 0;
            CargarVentasPorVendedorEnChart(cantidad);
            actualizardatagridStock();
            actualizardatagridVentasTodas(cantidad);
            llenarMontoFacturacion(cantidad);
            llenarMontoVentas(cantidad);
            CargarVentasPorMarcaEnChart(cantidad);
            CargarVentasPorAñoEnChart();
            llenarProveedor();
        }
        private void CargarVentasPorVendedorEnChart(int cantidadd)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();

            chart1.Titles.Add("Ventas por Vendedor");


            Dictionary<int, int> ventasPorVendedor = bllVenta.ObtenerCantidadVentasPorVendedor(cantidadd);

            if (ventasPorVendedor == null || ventasPorVendedor.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar.");
                return;
            }

            Series serie = new Series("Ventas por Vendedor");
            serie.ChartType = SeriesChartType.Pie;   
            serie.IsValueShownAsLabel = true;        

            foreach (var kvp in ventasPorVendedor)
            {
                string nombre = $"ID {kvp.Key}";
                int cantidad = kvp.Value;

                serie.Points.AddXY(nombre, cantidad);
            }

            chart1.Series.Add(serie);
        }
        private void CargarVentasPorMarcaEnChart(int cantidadd)
        {
            chart2.Series.Clear();
            chart2.Titles.Clear();

            chart2.Titles.Add("Ventas por Marca");

            Dictionary<string, int> ventasPorMarca = BllVenta.ObtenerCantidadVentasPorMarca(cantidadd);

            if (ventasPorMarca == null || ventasPorMarca.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar.");
                return;
            }

            Series serie = new Series("Ventas por Marca");
            serie.ChartType = SeriesChartType.Pie;
            serie.IsValueShownAsLabel = true;

            foreach (var kvp in ventasPorMarca)
            {
                string marca = kvp.Key;
                int cantidad = kvp.Value;

                serie.Points.AddXY(marca, cantidad);
            }

            chart2.Series.Add(serie);
        }
        private void CargarVentasPorAñoEnChart()
        {
            chart3.Series.Clear();
            chart3.Titles.Clear();

            chart1.Titles.Add("Ventas por Año");

            Dictionary<int, int> ventasPorAño = BllVenta.ObtenerCantidadVentasPorAño();

            if (ventasPorAño == null || ventasPorAño.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar.");
                return;
            }

            Series serie = new Series("Ventas por Año");
            serie.ChartType = SeriesChartType.Column;
            serie.IsValueShownAsLabel = true;

            foreach (var kvp in ventasPorAño.OrderBy(x => x.Key))
            {
                int año = kvp.Key;
                int cantidad = kvp.Value;

                serie.Points.AddXY(año, cantidad);
            }

            chart3.Series.Add(serie);
        }
        private void actualizardatagridStock()
        {
            var listaReducida = bllVehiculo.getAll()
            .Select(v => new
            {
                Marca = v.Marca1,
                Version = v.Version1,
                Año = v.Año1,
                Patente = v.Patente1,
            })
                .ToList();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = listaReducida;
        }
        private void actualizardatagridVentasTodas(int cantidad)
        {
            var listaReducida = bllVenta.getAll(cantidad)
            .Select(v => new
            {
                IdVenta = v.IdVenta1,
                IdVendedor = v.IdVendedor1,
                DniCliente = v.Dnicliente,
                VehiculoMarca = v.MarcaVehiculo,
                VehiculoVersion = v.VersionVehiculo,
                Monto = v.Monto1,
                Fecha = v.Fecha1
            })
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaReducida;
        }
        private void llenarMontoFacturacion(int cantidad)
        {
            decimal total = bllVenta.ObtnerMontoTotalFacturacion(cantidad);
            textBox1.Text = total.ToString("C");

        }
        private void llenarProveedor()
        {
            string Proveedor = BllCompra.obtnerProveedorMasFrecuente();
            textBox3.Text = Proveedor;

        }
        private void llenarMontoVentas(int cantidad)
        {
            decimal total = bllVenta.ObtenerCantidadTotalVentas(cantidad);
            textBox2.Text = total.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cantidad = 30;
                CargarVentasPorVendedorEnChart(cantidad);
                actualizardatagridVentasTodas(cantidad);
                llenarMontoFacturacion(cantidad);
                llenarMontoVentas(cantidad);
                CargarVentasPorMarcaEnChart(cantidad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cantidad = 365;
                CargarVentasPorVendedorEnChart(cantidad);
                actualizardatagridVentasTodas(cantidad);
                llenarMontoFacturacion(cantidad);
                llenarMontoVentas(cantidad);
                CargarVentasPorMarcaEnChart(cantidad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cantidad = 0;
                CargarVentasPorVendedorEnChart(cantidad);
                actualizardatagridVentasTodas(cantidad);
                llenarMontoFacturacion(cantidad);
                llenarMontoVentas(cantidad);
                CargarVentasPorMarcaEnChart(cantidad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
