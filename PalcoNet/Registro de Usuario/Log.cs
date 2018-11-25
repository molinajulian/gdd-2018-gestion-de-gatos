using MaterialSkin;
using MaterialSkin.Controls;
using PalcoNet.Modelo;
using PalcoNet.Registro_de_Usuario;
using PalcoNet.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_usuario
{
    public partial class Log : MaterialForm
    {
        private UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        public Log()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try {
                usuarioRepositorio.validarUsuario(textUsuario.Text, textContrasena.Text);
                MenuPpal menuPpal = new MenuPpal(usuarioRepositorio.buscarUsuario(textUsuario.Text), this);
                textContrasena.Text = "Contraseña";
                textUsuario.Text = "Nombre de Usuario";
                textContrasena.UseSystemPasswordChar = false;
                this.Hide();
                menuPpal.Show();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textUsuario_Click(object sender, EventArgs e)
        {
            textUsuario.Clear();
        }

        private void textContrasena_Click(object sender, EventArgs e)
        {
            textContrasena.Clear();
            textContrasena.UseSystemPasswordChar = true;
        }

        private void textContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {

            textContrasena.UseSystemPasswordChar = true;
        }

        private void Log_Load(object sender, EventArgs e)
        {

        }

    }
}
