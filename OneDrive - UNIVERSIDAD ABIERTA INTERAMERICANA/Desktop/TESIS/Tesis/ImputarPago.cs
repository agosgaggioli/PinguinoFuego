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
    public partial class ImputarPago : Form
    {
        BllDetalleCompra BllDetalleCompra = new BllDetalleCompra();
        BllProveedor BllProveedor = new BllProveedor();
        private bool comboCargado = false;
        private BeUsuario _us;
        public ImputarPago(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();


        }
        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Imputar Pago");
            button2.Enabled = _us.TienePermiso("Ver Todas Detalles");
            

        }

        private void ImputarPago_Load(object sender, EventArgs e)
        {
            actualizardatagrid();
            llenarMonto();
            CargarComboProveedor();

            comboCargado = true;



        }
        private void llenarMonto()
        {
            decimal total = BllDetalleCompra.ObtenerMontoTotalDetalles();
            txtMonto.Text = total.ToString("C");

        }
        private void CargarComboProveedor()
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = BllProveedor.getAll();
            comboBox1.ValueMember = "IdProveedor1"; 
            comboBox1.DisplayMember = "ProveedorDisplay";
        }

        private void actualizardatagrid()
        {
            var lista = BllDetalleCompra.getAll();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("IdDetalle1", "ID Detalle");
            dataGridView1.Columns["IdDetalle1"].DataPropertyName = "IdDetalle1";

            dataGridView1.Columns.Add("IdCompra1", "ID Compra");
            dataGridView1.Columns["IdCompra1"].DataPropertyName = "IdCompra1";

            dataGridView1.Columns.Add("IdProveedor1", "ID Proveedor");
            dataGridView1.Columns["IdProveedor1"].DataPropertyName = "IdProveedor1";

            dataGridView1.Columns.Add("Fecha", "Fecha");
            dataGridView1.Columns["Fecha"].DataPropertyName = "Fecha";

            dataGridView1.Columns.Add("Descripcion1", "Descripción");
            dataGridView1.Columns["Descripcion1"].DataPropertyName = "Descripcion1";

            dataGridView1.Columns.Add("Monto1", "Monto");
            dataGridView1.Columns["Monto1"].DataPropertyName = "Monto1";

            dataGridView1.Columns.Add("RazonSocialProveedor1", "Proveedor");
            dataGridView1.Columns["RazonSocialProveedor1"].DataPropertyName = "RazonSocialProveedor1";

            dataGridView1.DataSource = lista;
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!comboCargado) return;

            if (comboBox1.SelectedValue != null)
            {
                int idProveedor = (int)comboBox1.SelectedValue;

                var proveedor = BllProveedor.getById(idProveedor);
                var detalles = BllDetalleCompra.GetByIdProveedor(proveedor);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = detalles;

                decimal total = BllDetalleCompra.ObtenerMontoTotalDetalle(proveedor);
                
                txtMonto.Text = total.ToString("C");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                int idDetalle = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdDetalle1"].Value);


                BeDetalleCompra detalleSeleccionado = BllDetalleCompra.ObtenerDetalle(idDetalle) as BeDetalleCompra;

                if (detalleSeleccionado == null)
                {
                    MessageBox.Show("No se encontró el detalle seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (!int.TryParse(textBox2.Text, out int monto) || monto <= 0)
                {
                    MessageBox.Show("Ingrese un monto válido para imputar al detalle.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               
                string metodo = textBox3.Text.Trim();

                if (string.IsNullOrWhiteSpace(metodo))
                {
                    MessageBox.Show("Ingrese el método de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BllDetalleCompra.ImputarPago(detalleSeleccionado, monto, metodo);

                MessageBox.Show("Pago imputado correctamente al detalle.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

             
                actualizardatagrid();
                llenarMonto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al imputar el pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                actualizardatagrid();
                llenarMonto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al imputar el pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
