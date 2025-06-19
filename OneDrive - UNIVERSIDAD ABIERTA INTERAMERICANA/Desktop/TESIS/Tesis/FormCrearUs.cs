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
    public partial class FormCrearUs : Form
    {
        BllUsuario BllUsuario = new BllUsuario();
        private BeUsuario _us;
        public FormCrearUs(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {

            button1.Enabled = _us.TienePermiso("Crear Us");
            button2.Enabled = _us.TienePermiso("Eliminar Us");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BeUsuario beUsuario = new BeUsuario(textBox1.Text, textBox2.Text);

                BllUsuario.CargarUs(beUsuario);
                MessageBox.Show("exitoso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                BllUsuario.DeleteById(Convert.ToInt32(textBox3.Text));

                MessageBox.Show("Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCrearUs_Load(object sender, EventArgs e)
        {

        }
    }
}
