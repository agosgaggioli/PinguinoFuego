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
    public partial class FormBitacora : Form
    {
        BllBitacora BllBitacora = new BllBitacora();
        private BeUsuario _us;
        public FormBitacora(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Filtar BackUp");
            button2.Enabled = _us.TienePermiso("Filtar Restore");
            button5.Enabled = _us.TienePermiso("Filtar Todas");
            button4.Enabled = _us.TienePermiso("Restore");
            button3.Enabled = _us.TienePermiso("BackUp");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FormBackRestore formBackRestore = new FormBackRestore(_us);
                formBackRestore.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            actualizardatagrid();
        }
        private void actualizardatagrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BllBitacora.ObtenerBitacora();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                FormBackRestore formBackRestore = new FormBackRestore(_us);
                formBackRestore.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = BllBitacora.ObtenerBitacoraBackUp();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                actualizardatagrid();
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
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = BllBitacora.ObtenerBitacoraRestore();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }
    }
}
