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
    public partial class FormStock : Form
    {
        private BeUsuario _us;
        public FormStock(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();

        }
        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Acceso Stock");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormCargarStock formCargarStock = new FormCargarStock(_us);
                formCargarStock.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormStock_Load(object sender, EventArgs e)
        {

        }
    }
}
