using BE;
using BLL;
using CU;
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
    public partial class FormPermisos : Form
    {
        BllComponente BllComponente = new BllComponente();
        private BeUsuario _us;
        public FormPermisos(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {

            button1.Enabled = _us.TienePermiso("Crear Permiso");
            button2.Enabled = _us.TienePermiso("Eliminar Permiso");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Permiso permiso = new Permiso(textBox1.Text);
                BllComponente.GuardarPermiso(permiso);
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
                BllComponente.DeleteByIdPermiso(Convert.ToInt32(textBox2.Text));

                MessageBox.Show("Permiso eliminado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormPermisos_Load(object sender, EventArgs e)
        {

        }
    }
}
