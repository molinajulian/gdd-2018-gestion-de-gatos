using MaterialSkin;
using MaterialSkin.Controls;
using PalcoNet.Modelo;
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

namespace PalcoNet.Login_e_Inicio
{
    public partial class Log : MaterialForm
    {
        public Log()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void btn_login_Click(object sender, EventArgs e)
        {


            Usuario user = new Usuario(textUsuario.Text, textContrasena.Text);

            int usuarioAdmitido = Convert.ToInt32(UsuariosRepositorio.validarUsuario(user));

            if (usuarioAdmitido.Equals(1))
            {
                ConfiguracionInicial login2 = new ConfiguracionInicial(user,this);
                textContrasena.Text="Contraseña";
                textUsuario.Text = "Nombre de Usuario";
                textContrasena.UseSystemPasswordChar = false;
            }
            else if (usuarioAdmitido.Equals(0)) MessageBox.Show("Usuario o contraseña invalidos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (usuarioAdmitido.Equals(-1)) MessageBox.Show("El usuario ingresado se encuentra inhabilitado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else MessageBox.Show("La sucursal a la cual se encuentra asignado el usuario esta deshabilitada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
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

        private void textContrasena_Enter(object sender, EventArgs e)
        {

        }

        private void textContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {

            textContrasena.UseSystemPasswordChar = true;
        }
    }
}
