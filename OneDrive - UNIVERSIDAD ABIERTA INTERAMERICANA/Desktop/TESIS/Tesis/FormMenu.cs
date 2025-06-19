using BE;
using CU;
using UI;

namespace Tesis
{
    public partial class Form1 : Form
    {
        private BeUsuario _us;

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();
        }

        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Gestion Ventas");
            button3.Enabled = _us.TienePermiso("Gestion Compras");
            button7.Enabled = _us.TienePermiso("Gestion Admin");
            button5.Enabled = _us.TienePermiso("Gestion Admin");
            button2.Enabled = _us.TienePermiso("Gestion Stock");
            button4.Enabled = _us.TienePermiso("Gestion Dashboard");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormVentas ventasForm = new FormVentas(_us);

                ventasForm.Show();
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
                FormCompra formCompra = new FormCompra(_us);
                formCompra.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FormStock formStock = new FormStock(_us);
                formStock.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                FormUsuarios formUsuarios = new FormUsuarios(_us);
                formUsuarios.Show();
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
                FormDashboard formDahboard = new FormDashboard(_us);
                formDahboard.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                FormBitacora formBitacora = new FormBitacora(_us);
                formBitacora.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
