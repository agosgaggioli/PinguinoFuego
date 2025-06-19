using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormStockDisponible : Form
    {
        BllVehiculo bllVehiculo = new BllVehiculo();
        public FormStockDisponible()
        {
            InitializeComponent();
        }

        private void FormStockDisponible_Load(object sender, EventArgs e)
        {
            actualizardatagrid();
        }
        private void actualizardatagrid()
        {
            var listaReducida = bllVehiculo.getAll()
                .Select(v => new
                {
                    Marca = v.Marca1,
                    Version = v.Version1,
                    Año = v.Año1,
                    Patente = v.Patente1,
                    PrecioContado = v.PrecioContado1,
                    PrecioUsado = v.PrecioConUsado1
                })
                .OrderBy(v => v.Marca) 
                .ToList();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaReducida;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string marca = row.Cells["Marca"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(marca)) continue;

                switch (marca.ToLower())
                {
                    case "ford":
                        row.DefaultCellStyle.BackColor = Color.LightSkyBlue;
                        break;
                    case "jeep":
                        row.DefaultCellStyle.BackColor = Color.PaleTurquoise;
                        break;
                    case "nissan":
                        row.DefaultCellStyle.BackColor = Color.LightSteelBlue; 
                        break;
                    case "toyota":
                        row.DefaultCellStyle.BackColor = Color.PowderBlue; 
                        break;
                    case "volkswagen":
                        row.DefaultCellStyle.BackColor = Color.Gainsboro; 
                        break;
                    case "renault":
                        row.DefaultCellStyle.BackColor = Color.Silver; 
                        break;
                    case "honda":
                        row.DefaultCellStyle.BackColor = Color.LightGray; 
                        break;
                    case "peugeot":
                        // Color personalizado (más claro que Silver)
                        row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E5E4E2");
                        break;
                    case "fiat":
                        row.DefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230); 
                        break;
                    default:
                        row.DefaultCellStyle.BackColor = Color.White; 
                        break;
                }
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
