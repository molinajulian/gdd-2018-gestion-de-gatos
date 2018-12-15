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
            getTiposDocumento();
            getRoles();
            comboTiposDoc.Hide();
        }
        private void getRoles()
        {
            List<Rol> roles = new List<Rol>();
            combo_roles.Items.Clear();
            roles = RolRepositorio.getRoles();
            foreach (Rol rol in roles)
            {
                combo_roles.Items.Add(rol);
            }
            combo_roles.Items.Add(new Rol(0, "OTRO"));
            combo_roles.DisplayMember = "Nombre";
        }
        private void getTiposDocumento()
        {
            List<TiposDocumento> tipos = new List<TiposDocumento>();
            comboTiposDoc.Items.Clear();
            tipos = ClienteRepositorio.getTiposDoc();
            foreach (TiposDocumento tipo in tipos)
            {
                comboTiposDoc.Items.Add(tipo);
                comboTiposDoc.DisplayMember = "Descripcion";
            }
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            try {
                if ((string.IsNullOrEmpty(textUsuario.Text) || textUsuario.Text == "Nombre de Usuario") ||
                    (string.IsNullOrEmpty(textContrasena.Text) || textContrasena.Text == "Contraseña") ||
                     string.IsNullOrEmpty(combo_roles.Text) ||
                     combo_roles.Text == "CLIENTE" && comboTiposDoc.SelectedItem == null)
                {
                    MessageBox.Show("Por favor complete todos los campos", "Advertencia.", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                }
                else
                {
                    usuarioRepositorio.validarUsuario(textUsuario.Text, textContrasena.Text);
                    this.Hide();
                    new ConfiguracionInicial(usuarioRepositorio.buscarUsuario(textUsuario.Text), this).Show();
                    textContrasena.Text = "Contraseña";
                    textUsuario.Text = "Nombre de Usuario";
                    textContrasena.UseSystemPasswordChar = false;
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ha ocurrido un error al intentar ingresar al sistema.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                this.Show();
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

        private void combo_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rol seleccionado = (Rol)combo_roles.SelectedItem;
            if (seleccionado.nombre == "CLIENTE") comboTiposDoc.Show();
            else comboTiposDoc.Hide();
        }

    }
}
