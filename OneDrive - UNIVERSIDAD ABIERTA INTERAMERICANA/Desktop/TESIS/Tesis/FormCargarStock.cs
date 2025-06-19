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

namespace UI
{
    public partial class FormCargarStock : Form
    {
        BllVehiculo BllVehiculo = new BllVehiculo();
        private BeUsuario _us;
        public FormCargarStock(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();

        }
        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Cargar Stock");
            button2.Enabled = _us.TienePermiso("Modificar Precio");
            button3.Enabled = _us.TienePermiso("Eliminar Vehiculo");
        }

        private void actualizardatagrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BllVehiculo.getAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BeVehiculo Vehiculo = Obtnerdatosform();
                BllVehiculo.cargaraVehiculo(Vehiculo);
                MessageBox.Show("exitoso");
                actualizardatagrid();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
        private BeVehiculo Obtnerdatosform()
        {
            BeVehiculo Vehiculo = new BeVehiculo();
            Vehiculo.Marca1 = txtMarca.Text;
            Vehiculo.Patente1 = txtPatente.Text;
            Vehiculo.Version1 = txtVersion.Text;
            Vehiculo.Año1 = Convert.ToInt32(txtAño.Text);
            Vehiculo.Precio1 = Convert.ToInt32(txtPrecio.Text);
            Vehiculo.Kilometros1 = txtChasis.Text;
            return Vehiculo;
        }

        private void FormCargarStock_Load(object sender, EventArgs e)
        {
            actualizardatagrid();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                BllVehiculo.Update(Convert.ToInt32(txtIdNuevoVehiculo.Text), Convert.ToInt32(txtIdNuevoPrecio.Text));
                actualizardatagrid();
                MessageBox.Show("Precio modificado correctamente");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtIdNuevoPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                BllVehiculo.DeleteById(Convert.ToInt32(txtEliminarId.Text));
                actualizardatagrid();
                MessageBox.Show("Vehiculo eliminado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
