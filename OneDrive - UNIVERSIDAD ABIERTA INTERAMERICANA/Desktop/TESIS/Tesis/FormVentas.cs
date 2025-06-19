using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormVentas : Form
    {
        private BeUsuario _us;
        public FormVentas(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Acceso Clientes");
            button2.Enabled = _us.TienePermiso("Acceso Vendedores");
            button5.Enabled = _us.TienePermiso("Acceso Stock Disponible");
            button3.Enabled = _us.TienePermiso("Acceso Cargar Venta");
            button4.Enabled = _us.TienePermiso("Acceso Imputar Cobro");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormClientes formClientes = new FormClientes(_us);

                formClientes.Show();
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
                FormCargarVenta formCargar = new FormCargarVenta(_us);
                formCargar.Show();
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
                ImputarCobro formImputar = new ImputarCobro(_us);
                formImputar.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FormVendedores formVendedores = new FormVendedores();
                formVendedores.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                FormStockDisponible formStockDisponible = new FormStockDisponible();
                formStockDisponible.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {

        }
    }
}
