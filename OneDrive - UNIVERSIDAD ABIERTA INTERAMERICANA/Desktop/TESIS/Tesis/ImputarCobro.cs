using BE;
using BLL;
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
    public partial class ImputarCobro : Form
    {
        BllFactura BllFactura = new BllFactura();
        BLLCliente BLLCliente = new BLLCliente();
        private BeUsuario _us;
        public ImputarCobro(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Imputar Cobro");
            button2.Enabled = _us.TienePermiso("Ver Todas Facturas");

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ImputarCobro_Load(object sender, EventArgs e)
        {
            actualizardatagrid();
            llenarMonto();
            CargarComboClientes();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void llenarMonto()
        {
            decimal total = BllFactura.ObtenerMontoTotalFacturas();
            txtMonto.Text = total.ToString("C");

        }
        private void CargarComboClientes()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = BLLCliente.getAll();
            comboBox1.ValueMember = "IdCliente1"; // Este campo debe estar en la entidad BeCliente
            comboBox1.DisplayMember = "ClienteDisplay";
        }

        private void actualizardatagrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BllFactura.getAll();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is BeCliente ClienteSeleccionado)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = BllFactura.GetByIdCliente(ClienteSeleccionado);
                decimal total = BllFactura.ObtenerMontoTotalFacturasCliente(ClienteSeleccionado);
                txtMonto.Text = total.ToString("C");
            }

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    
                    int idFactura = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdFactura1"].Value);

                    BeFactura facturaSeleccionada = BllFactura.obtenerFactura(idFactura) as BeFactura;

                    if (facturaSeleccionada == null)
                    {
                        MessageBox.Show("No se encontró la factura seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!int.TryParse(textBox2.Text, out int cobro) || cobro <= 0)
                    {
                        MessageBox.Show("Ingrese un monto de cobro válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    
                    string metodo = textBox3.Text.Trim();

                    if (string.IsNullOrWhiteSpace(metodo))
                    {
                        MessageBox.Show("Ingrese el método de cobro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    BllFactura.ImputarCobro(facturaSeleccionada, cobro, metodo);

                    MessageBox.Show("Cobro imputado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    actualizardatagrid();
                    llenarMonto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al imputar el cobro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una factura de la grilla.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            actualizardatagrid();
            llenarMonto();
        }
    }
}

