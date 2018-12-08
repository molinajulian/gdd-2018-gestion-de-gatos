using MaterialSkin;
using MaterialSkin.Controls;
using PalcoNet.Modelo;
using PalcoNet.Registro_de_usuario;
using PalcoNet.Registro_de_Usuario;
using PalcoNet.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_usuario
{
    public partial class ConfiguracionInicial : MaterialForm
    {
        Usuario user;
        Log login;
        public ConfiguracionInicial(Usuario user, Log login)
        {
            InitializeComponent();
            this.user = user;
            this.login=login;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            llenarCombos();
        }

        public void llenarCombos()
        {
            List<Rol> roles = new List<Rol>();
            combo_roles.Items.Clear();
            roles = UsuarioRepositorio.getRoles(user);
            if (roles.Count == 0)
            {
                // Utils.mostrarError(new Exception("El usuario no tiene roles asociados"));
            } else { 
                this.Show();
                foreach (Rol rol in roles)
                {
                    combo_roles.Items.Add(rol);
                }
                combo_roles.DisplayMember = "Nombre";
            }
        }

        private void btn_rol_aceptado_Click(object sender, EventArgs e)
        {

            if (camposVacios()) { return; }
            this.user.rol = (Rol)combo_roles.SelectedItem;
            {
                this.Hide();
                MenuPpal menu = new MenuPpal(this.user, this.login);
                menu.ShowDialog();
                this.Close();
            }
        }

        private bool camposVacios()
        {
            bool error = false;

            if (string.IsNullOrWhiteSpace(combo_roles.Text))
            {
                MessageBox.Show("Por favor complete todos los campos");
                error = true;
            }
            return error;
        }


        private void ConfiguracionInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }

        private void ConfiguracionInicial_Shown(object sender, EventArgs e)
        {
            llenarCombos();
        }

        private void ConfiguracionInicial_Load(object sender, EventArgs e)
        {

        }

        private void combo_roles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
