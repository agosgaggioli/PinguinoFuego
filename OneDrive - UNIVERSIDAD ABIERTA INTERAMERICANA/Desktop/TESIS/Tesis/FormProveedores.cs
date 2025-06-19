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
    public partial class FormProveedores : Form
    {
        BllProveedor bllProveedor = new BllProveedor();
        private BeUsuario _us;
        public FormProveedores(BeUsuario us)
        {
            InitializeComponent();

            _us = us;
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Registrar Proveedor");
            button2.Enabled = _us.TienePermiso("Eliminar Proveedor");
           

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BeProveedor beProveedor = Obtnerdatosform();
                bllProveedor.AgregarProveedor(beProveedor);
                actualizardatagrid();
                limpiarControles();
                MessageBox.Show("Proveedor Creado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private BeProveedor Obtnerdatosform()
        {
            BeProveedor Proveedor = new BeProveedor();
            Proveedor.RazonSocial1 = txtRazonSocial.Text;
            Proveedor.Contacto1 = txtContacto.Text;
            Proveedor.Direccion1 = txtDireccion.Text;
            return Proveedor;
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            actualizardatagrid();
        }
        private void actualizardatagrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bllProveedor.getAll();

            
            dataGridView1.Columns["IdProveedor1"].HeaderText = "Id";
            dataGridView1.Columns["RazonSocial1"].HeaderText = "Razón Social";
            dataGridView1.Columns["Direccion1"].HeaderText = "Dirección";
            dataGridView1.Columns["Contacto1"].HeaderText = "Contacto";
            dataGridView1.Columns["Deuda"].HeaderText = "Deuda";

            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(224, 242, 255); 
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); 

            
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.LightGray;

            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void limpiarControles()
        {
            txtContacto.Clear();
            txtRazonSocial.Clear();
            txtDireccion.Clear();
            txtIdElim.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bllProveedor.DeleteById(Convert.ToInt32(txtIdElim.Text));
                actualizardatagrid();
                limpiarControles();
                MessageBox.Show("Proveedor eliminado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
