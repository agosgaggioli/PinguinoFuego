using BE;
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

using Tesis;
using Seguridad;
using BLL;

namespace UI
{
    public partial class login : UserControl
    {
        BllUsuario bllUsuario = new BllUsuario();
        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string nombre = txtUs.Text;
            string contraseña = txtCont.Text;

            BeUsuario usuarioLogueado = ValidarLogin(nombre, contraseña);

            if (usuarioLogueado != null)
            {

                Form1 form = new Form1(usuarioLogueado);
                form.Show();

              
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
        }

        public BeUsuario ValidarLogin(string nombreIngresado, string contraseniaIngresada)
        {
            BeUsuario usuario = bllUsuario.ObtenerUsuarioConPermisoss(nombreIngresado);

            if (usuario != null)
            {
                string contraseniaDesencriptada = Seguridad.Encriptacion.Desencriptar(usuario.Contrasenia);

                if (contraseniaDesencriptada == contraseniaIngresada)
                {
                    return usuario;
                }
            }

            return null;
        }

    }
}
