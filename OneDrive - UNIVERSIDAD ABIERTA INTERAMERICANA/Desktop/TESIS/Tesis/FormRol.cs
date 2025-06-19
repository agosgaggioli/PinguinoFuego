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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class FormRol : Form
    {
        BllComponente BllComponente = new BllComponente();
        private BeUsuario _us;
        public FormRol(BeUsuario us)
        {
            InitializeComponent();
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {

            button1.Enabled = _us.TienePermiso("Crear Rol");
            button2.Enabled = _us.TienePermiso("Eliminar Rol");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Grupo grupo = new Grupo(textBox1.Text);
                BllComponente.GuardarGrupo(grupo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormRol_Load(object sender, EventArgs e)
        {
             

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                BllComponente.DeleteByIdRol(Convert.ToInt32(textBox2.Text));

                MessageBox.Show("Rol eliminado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
