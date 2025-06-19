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
    public partial class FormUsuarios : Form
    {
        private BeUsuario _us;
        public FormUsuarios(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Acceso Us");
            button2.Enabled = _us.TienePermiso("Acceso Control");
            button4.Enabled = _us.TienePermiso("Acceso Rol");
            button3.Enabled = _us.TienePermiso("Acceso Permiso");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FormControlUsuario formControlUsuario = new FormControlUsuario(_us);
                formControlUsuario.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormCrearUs formCrearUs = new FormCrearUs(_us);
                formCrearUs.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FormPermisos formPermisos = new FormPermisos(_us);
                formPermisos.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                FormRol formRol = new FormRol(_us);
                formRol.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
