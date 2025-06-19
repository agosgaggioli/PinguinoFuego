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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace UI
{
    public partial class FormClientes : Form
    {
        BLLCliente bLLCliente = new BLLCliente();
        private BeUsuario _us;
        public FormClientes(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Registrar Cliente");
            button2.Enabled = _us.TienePermiso("Eliminar Cliente");
        }
        private BeCliente Obtnerdatosform()
        {
            BeCliente cliente = new BeCliente();
            cliente.ApellidoCliente1 = txtApellido.Text;
            cliente.NombreCliente1 = txtNombre.Text;
            cliente.Direccion1 = txtDireccion.Text;
            cliente.DniCliente1 = txtDni.Text;
            cliente.DeudaCliente1 = 0;
            return cliente;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BeCliente cliente = Obtnerdatosform();
                bLLCliente.cargaraCliente(cliente);
                MessageBox.Show("Cliente creado con exito");
                actualizardatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            actualizardatagrid();
        }
        private void ConfigurarDataGridView()
        {
            
            dataGridView1.AutoGenerateColumns = false;

           
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "IdCliente1",
                HeaderText = "ID"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DniCliente1",
                HeaderText = "DNI Cliente"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ApellidoCliente1",
                HeaderText = "Apellido"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NombreCliente1",
                HeaderText = "Nombre"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DeudaCliente1",
                HeaderText = "Deuda",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } 
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Direccion1",
                HeaderText = "Dirección"
            });

            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void actualizardatagrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bLLCliente.getAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bLLCliente.DeleteById(Convert.ToInt32(txtdnielim.Text));
                MessageBox.Show("Cliente eliminado correctamente");
                actualizardatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
