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
    public partial class FormBackRestore : Form
    {
        BeBitacora BeBitacora = new BeBitacora();
        BllBitacora BllBitacora = new BllBitacora();
        BllGestorBD BllGestorBD = new BllGestorBD();
        private List<BeBackUp> _listaBackups = new List<BeBackUp>();
        private BeUsuario _us;
        public FormBackRestore(BeUsuario us)
        {
            InitializeComponent();
            CargarListaBackups();
            _us = us;
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {
            button1.Enabled = _us.TienePermiso("Realizar Back Up");
            button2.Enabled = _us.TienePermiso("Realizar Restore");
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BeBitacora.IdBitacora1 = 1;
                BeBitacora.IdUsuario1 = _us.IdUsuario;
                BeBitacora.Fecha = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss").Trim());
                BeBitacora.Detalle = "Back Up";
                BllBitacora.Guardar(BeBitacora);
                BllGestorBD.CrearBackUP();
                MessageBox.Show("se creo correctamente");
                CargarListaBackups();
            }
            catch (Exception ex) { }
        }
        private void CargarListaBackups()
        {
            listBox1.Items.Clear();
            _listaBackups = BllGestorBD.ObtenerBackups();

            foreach (var b in _listaBackups)
            {
                listBox1.Items.Add($"ID: {b.IdBackUP} - Fecha: {b.Fecha:dd/MM/yyyy HH:mm:ss} - {b.Detalle}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un backup de la lista.");
                    return;
                }

                var backupSeleccionado = _listaBackups[listBox1.SelectedIndex];
                string carpetaBackup = backupSeleccionado.Detalle;

               
                BllGestorBD.CrearRestore(carpetaBackup);

                
                BeBitacora nuevaBitacora = new BeBitacora();
                nuevaBitacora.Fecha = DateTime.Now;
                nuevaBitacora.Detalle = "Restore";
                MessageBox.Show((_us.IdUsuario.ToString()));
                nuevaBitacora.IdUsuario1 = _us.IdUsuario;
                BllBitacora.Guardar(nuevaBitacora);

                MessageBox.Show("Restore realizado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en restore: " + ex.Message);
            }
        }

        private void FormBackRestore_Load(object sender, EventArgs e)
        {

        }
    }
}
