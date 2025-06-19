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
    public partial class FormCompra : Form
    {
        private BeUsuario _us;
        public FormCompra(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();
        }

       

        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Acceso Proveedores");
            button2.Enabled = _us.TienePermiso("Acceso Cargar Compra");
            button3.Enabled = _us.TienePermiso("Acceso Imputar Pago");
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormProveedores formProveedores = new FormProveedores(_us);
                formProveedores.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FormCargarCompra formCargarCompras = new FormCargarCompra(_us);
                formCargarCompras.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ImputarPago imputarPago = new ImputarPago(_us);
                imputarPago.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        private void FormCompra_Load(object sender, EventArgs e)
        {

        }
    }
}
