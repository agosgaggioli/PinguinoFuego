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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace UI
{
    public partial class FormCargarVenta : Form
    {
        BllVendedor bllVendedor = new BllVendedor();
        BLLCliente bllcliente = new BLLCliente();
        BllVehiculo bllVehiculo = new BllVehiculo();
        BllVenta Bllventa = new BllVenta();
        private BeUsuario _us;
        public FormCargarVenta(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();

        }
        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Cargar Venta");
           
        }

        private void FormCargarVenta_Load(object sender, EventArgs e)
        {
            CargarComboVendedores();
            CargarComboClientes();
            CargarGridVehiculos();
        }

        private void CargarComboVendedores()
        {
            cmbVendedor.DataSource = null;
            cmbVendedor.DataSource = bllVendedor.getAll();
            cmbVendedor.ValueMember = "IdVendedor1";
            cmbVendedor.DisplayMember = "NombreVendedor1";
        }
        private void CargarComboClientes()
        {
            cmbCliente.DataSource = null;
            cmbCliente.DataSource = bllcliente.getAll();
            cmbCliente.ValueMember = "IdCliente1"; 
            cmbCliente.DisplayMember = "ClienteDisplay";
        }
        private void CargarGridVehiculos()
        {
           
            var lista = bllVehiculo.getAll()
                .OrderBy(v => v.Marca1)
                .ToList();

            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = lista;

            
            foreach (DataGridViewColumn col in dgvVehiculos.Columns)
            {
                col.Visible = false;
            }

            
            dgvVehiculos.Columns["IdVehiculo1"].Visible = true;
            dgvVehiculos.Columns["Patente1"].Visible = true;
            dgvVehiculos.Columns["Marca1"].Visible = true;
            dgvVehiculos.Columns["Version1"].Visible = true;

           
            dgvVehiculos.Columns["IdVehiculo1"].HeaderText = "ID";
            dgvVehiculos.Columns["Patente1"].HeaderText = "Patente";
            dgvVehiculos.Columns["Marca1"].HeaderText = "Marca";
            dgvVehiculos.Columns["Version1"].HeaderText = "Versión";

           
            foreach (DataGridViewRow row in dgvVehiculos.Rows)
            {
                if (row.DataBoundItem is BeVehiculo vehiculo)
                {
                    string marca = vehiculo.Marca1?.ToLower();

                    switch (marca)
                    {
                        case "ford":
                            row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                            break;
                        case "jeep":
                            row.DefaultCellStyle.BackColor = Color.PaleTurquoise;
                            break;
                        case "nissan":
                            row.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                            break;
                        case "toyota":
                            row.DefaultCellStyle.BackColor = Color.PowderBlue;
                            break;
                        case "volkswagen":
                            row.DefaultCellStyle.BackColor = Color.Gainsboro;
                            break;
                        case "renault":
                            row.DefaultCellStyle.BackColor = Color.Silver;
                            break;
                        case "honda":
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            break;
                        case "peugeot":
                            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E5E4E2");
                            break;
                        case "fiat":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230);
                            break;
                        default:
                            row.DefaultCellStyle.BackColor = Color.White;
                            break;
                    }
                }
            }

           
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BeVenta Venta = Obtnerdatosform();
                if (Venta != null)
                {
                    Bllventa.CrearVenta(Venta);
                }
                else { MessageBox.Show("complete bien los campos"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private BeVenta Obtnerdatosform()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Debe Ingresar el monto de la venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (cmbCliente.SelectedValue == null || cmbVendedor.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un Cliente y un Vendedor de las listas", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (dgvVehiculos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un Vehiculo de la grilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            BeVenta venta = new BeVenta();

            venta.Monto1 = Convert.ToInt32(textBox1.Text);

            int idCliente = (int)cmbCliente.SelectedValue;
            BeCliente cliente = bllcliente.getById(idCliente);
            venta.IdCliente1 = cliente.IdCliente1;
            venta.NombreCliente = cliente.NombreCliente1;
            venta.Dnicliente = cliente.DniCliente1;

            if (dgvVehiculos.SelectedRows.Count > 0)
            {
                BeVehiculo vehiculo = (BeVehiculo)dgvVehiculos.SelectedRows[0].DataBoundItem;
                venta.IdVehiculo1 = vehiculo.IdVehiculo1;
                venta.Año = vehiculo.Año1;
                venta.VersionVehiculo = vehiculo.Version1;
                venta.MarcaVehiculo = vehiculo.Marca1;
            }
            else
            {
                throw new Exception("Debe seleccionar un vehículo");
            }

            int IdVendedor = (int)cmbVendedor.SelectedValue;
            BeVendedor vendedor = bllVendedor.getById(IdVendedor);
            venta.IdVendedor1 = vendedor.IdVendedor1;

            return venta;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
