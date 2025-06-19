using BE;
using BLL;
using CU;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class FormControlUsuario : Form
    {
        List<BeUsuario> usuarios = new();
        BllUsuario BllUsuario = new BllUsuario();

        BllComponente bllComponente = new BllComponente();
        private BeUsuario _us;
        public FormControlUsuario(BeUsuario us)
        {
            InitializeComponent();
            _us = us;
            AplicarPermisos();
        }
        private void AplicarPermisos()
        {
            button9.Enabled = _us.TienePermiso("Acceso Crear Us");
            button10.Enabled = _us.TienePermiso("Acceso Eliminar Us");
            button2.Enabled = _us.TienePermiso("Acceso Crear Rol");
            button1.Enabled = _us.TienePermiso("Acceso Eliminar Rol");
            button6.Enabled = _us.TienePermiso("Acceso Crear Permiso");
            button7.Enabled = _us.TienePermiso("Acceso Eliminar Permiso");
            button5.Enabled = _us.TienePermiso("Asociar Rol");
            button11.Enabled = _us.TienePermiso("Desasociar Rol");
            button3.Enabled = _us.TienePermiso("Asociar Permiso");
            button4.Enabled = _us.TienePermiso("Desasociar Permiso");
            button8.Enabled = _us.TienePermiso("Desencriptar");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormControlUsuario_Load(object sender, EventArgs e)
        {
            
            LlenarCombos();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void LlenarCombos()
        {

            comboBox1.DataSource = BllUsuario.getAllUs();
            comboBox1.DisplayMember = "Nombre";

            comboBox2.DataSource = BllComponente.getAllGrupos();
            comboBox2.DisplayMember = "Nombre";

            comboBox3.DataSource = BllComponente.getAllPermisos();
            comboBox3.DisplayMember = "Nombre";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is BeUsuario usuarioSeleccionado)
            {
                CargarTreeViewUsuarios(usuarioSeleccionado.Nombre);
                txtNombre.Text = usuarioSeleccionado.Nombre;
                txtContrasenia.Text = usuarioSeleccionado.Contrasenia;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FormRol form = new FormRol(_us);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }

        }




        private void button3_Click(object sender, EventArgs e)
        {
          
            var grupo = (Componente)comboBox2.SelectedItem;
            var permiso = (Permiso)comboBox3.SelectedItem;

            string grupoSeleccionado = grupo.Nombre;
            string permisoSeleccionado = permiso.Nombre;

            try
            {
                bllComponente.AsignarPermisoAGrupo(grupoSeleccionado, permisoSeleccionado);
                MessageBox.Show("Permiso asignado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var usuarioSeleccionado = (BeUsuario)comboBox1.SelectedItem;
            var grupoSeleccionadoSimple = (Grupo)comboBox2.SelectedItem;

           
            Grupo grupoCompleto = BllComponente.GetGrupoCompletoPorNombre(grupoSeleccionadoSimple.Nombre);

            if (grupoCompleto == null)
            {
                MessageBox.Show("No se pudo cargar el grupo completo con permisos.");
                return;
            }

            try
            {
                BllUsuario.AgregarRolAUsuario(usuarioSeleccionado.Nombre, grupoCompleto);
                MessageBox.Show("Rol asignado con permisos correctamente.");
                CargarTreeViewUsuarios(usuarioSeleccionado.Nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void CargarTreeViewUsuarios(string nombreUsuarioSeleccionado)
        {
            treeView1.Nodes.Clear();


            BeUsuario usuario = BllUsuario.ObtenerUsuarioConPermisos(nombreUsuarioSeleccionado);

            if (usuario == null)
            {
                MessageBox.Show("Usuario no encontrado");
                return;
            }

            TreeNode nodoUsuario = new TreeNode(usuario.Nombre);

            foreach (var componente in usuario.Permisos)
            {
                TreeNode nodoGrupo = new TreeNode(componente.Nombre);

                foreach (var hijo in componente.ObtenerHijos())
                {
                    TreeNode nodoPermiso = new TreeNode(hijo.Nombre);
                    nodoGrupo.Nodes.Add(nodoPermiso);
                }

                nodoUsuario.Nodes.Add(nodoGrupo);
            }

            treeView1.Nodes.Add(nodoUsuario);
            treeView1.ExpandAll();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                FormCrearUs formCrearUs = new FormCrearUs(_us);
                formCrearUs.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                FormCrearUs formCrearUs = new FormCrearUs(_us);
                formCrearUs.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FormRol formRol = new FormRol(_us);
                formRol.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                FormPermisos formPermisos = new FormPermisos(_us);
                formPermisos.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                FormPermisos formPermisos = new FormPermisos(_us);
                formPermisos.ShowDialog();
            }
            catch (Exception ex)
            {
                throw new Exception("Error  " + ex.Message, ex);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string encriptada = txtContrasenia.Text;
                string desencriptada = Seguridad.Encriptacion.Desencriptar(encriptada);
                txtContrasenia.Text = desencriptada;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desencriptar: " + ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var usuarioSeleccionado = (BeUsuario)comboBox1.SelectedItem;
            var grupoSeleccionadoSimple = (Grupo)comboBox2.SelectedItem; 

            if (usuarioSeleccionado == null || grupoSeleccionadoSimple == null)
            {
                MessageBox.Show("Debe seleccionar un usuario y un rol para quitar.");
                return;
            }

            try
            {
                BllUsuario.QuitarRolDeUsuario(usuarioSeleccionado.Nombre, grupoSeleccionadoSimple.Nombre);
                MessageBox.Show("Rol desasociado correctamente.");
                CargarTreeViewUsuarios(usuarioSeleccionado.Nombre);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var grupo = (Componente)comboBox2.SelectedItem;
            var permiso = (Permiso)comboBox3.SelectedItem;

            if (grupo == null || permiso == null)
            {
                MessageBox.Show("Debe seleccionar un grupo y un permiso.");
                return;
            }

            string grupoSeleccionado = grupo.Nombre;
            string permisoSeleccionado = permiso.Nombre;

            try
            {
                bllComponente.DesasignarPermisoDeGrupo(grupoSeleccionado, permisoSeleccionado);
                MessageBox.Show("Permiso desasociado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
