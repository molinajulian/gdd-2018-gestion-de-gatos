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
            List<Sucursal> sucursales = new List<Sucursal>();
            combo_roles.Items.Clear();
            combo_sucursales.Items.Clear();
            roles = UsuariosRepositorio.getRoles(user);
            if (roles == null)
            {
                MessageBox.Show("Este usuario no tiene roles habilitados.");
            }
            else
            {
                this.Show();
                login.Hide();
                foreach (Rol rol in roles)
                {
                    combo_roles.Items.Add(rol);
                }
                combo_roles.DisplayMember = "nombre";


                sucursales = UsuariosRepositorio.getSucursales(user);
                foreach (Sucursal sucursal in sucursales)
                {
                    combo_sucursales.Items.Add(sucursal);
                }
                combo_sucursales.DisplayMember = "nombre";
            }
        }

        private void btn_rol_aceptado_Click(object sender, EventArgs e)
        {

            if (validarCamposVacios()) { return; }
            this.user.rol = (Rol)combo_roles.SelectedItem;
            this.user.sucursal = (Sucursal)combo_sucursales.SelectedItem;
            if (combo_roles.Text.ToLower() != "administrador" && SucursalesRepositorio.validarHabilitacionSucursal(user.sucursal.codigo_postal) == 0) MessageBox.Show("Sucursal seleccionada se encuentra inhabilitada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                this.Hide();
                Menu menu = new Menu(this.user,this.login,this);
                menu.Show();
            }
        }

        private bool validarCamposVacios()
        {
            bool error = false;

            if (string.IsNullOrWhiteSpace(combo_roles.Text) || (string.IsNullOrWhiteSpace(combo_sucursales.Text) && combo_roles.Text.ToLower() != "administrador"))
            {
                MessageBox.Show("Por favor complete todos los campos");
                error = true;
            }
            return error;
        }

        private void combo_roles_SelectedValueChanged(object sender, EventArgs e)
        {
            if (combo_roles.Text.ToLower() == "administrador")
            { 
                combo_sucursales.Enabled = false;
                combo_sucursales.SelectedIndex = -1;
            }
            else
                combo_sucursales.Enabled = true;
        }

        private void ConfiguracionInicial_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Close();
        }

        private void ConfiguracionInicial_Shown(object sender, EventArgs e)
        {
            llenarCombos();
        }
    }
}
