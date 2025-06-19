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
    public partial class FormVendedores : Form
    {
        BllVendedor BllVendedor = new BllVendedor();
        public FormVendedores()
        {
            InitializeComponent();
        }

        private void FormVendedores_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            actualizardatagrid();
        }
        private void actualizardatagrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BllVendedor.getAll();
        }
        private void ConfigurarDataGridView()
        {

            dataGridView1.AutoGenerateColumns = false;


            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "IdVendedor1",
                HeaderText = "ID"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "DniVendedor1",
                HeaderText = "DNI Vendedor"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ApellidoVendedor1",
                HeaderText = "Apellido"
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NombreVendedor1",
                HeaderText = "Nombre"
            });
            

            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
    
}
