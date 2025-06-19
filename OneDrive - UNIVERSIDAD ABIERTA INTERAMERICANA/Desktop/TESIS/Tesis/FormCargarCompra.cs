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
    public partial class FormCargarCompra : Form
    {
        BllProveedor bllproveedor = new BllProveedor();
        BllCompra BllCompra= new BllCompra();
        private BeUsuario _us;
        
        public FormCargarCompra(BeUsuario us)
        {
            InitializeComponent();
            CargarComboBox();
            limpiarControles();
            _us = us;
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Cargar Compra");
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CargarComboBox()
        {
            cmbProvedor.DataSource = null;
            cmbProvedor.DataSource = bllproveedor.getAll();
            cmbProvedor.ValueMember = "IdProveedor1";
            cmbProvedor.DisplayMember = "ProveedorDisplay";
        }
        private void limpiarControles()
        {
            txtDescripcion.Clear();
            txtMonto.Clear();
        }
        private void FormCargarCompra_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BeCompra compra = Obtnerdatosform();
                BllCompra.CrearCompra(compra);
                MessageBox.Show("Compra cargada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private BeCompra Obtnerdatosform()
        {
            BeCompra Compra = new BeCompra();
            Compra.Monto1= Convert.ToInt32( txtMonto.Text);
            Compra.Descripcion1 = txtDescripcion.Text;
            int idSeleccionado = (int)cmbProvedor.SelectedValue;
            BeProveedor proveedor = bllproveedor.getById(idSeleccionado);
            Compra.IdProveedor1 = proveedor.IdProveedor1;
            Compra.RazonSocialProvedor1 = proveedor.RazonSocial1;

            return Compra;
        }
    }
}
