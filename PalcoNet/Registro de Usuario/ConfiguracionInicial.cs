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
        private List<Rol> rolesDeUsuario;
        public ConfiguracionInicial(Usuario user)
        {
            InitializeComponent();
            this.user = user;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            configurarSegunRoles();
        }

        public void configurarSegunRoles()
        {
            rolesDeUsuario = user.obtenerRoles();
            if (rolesDeUsuario.Count == 1)
            {
                user.rol = rolesDeUsuario.First();
                avanzarAMenuPpal();
            }
            else if (rolesDeUsuario.Count == 0)
            {
                MessageBox.Show("ERROR", "El usuario no tiene roles asociados");
            }
            else
            {
                llenarCombos(rolesDeUsuario);
            }
        }

        public void llenarCombos(List<Rol> rolesDeUsuario)
        {
            combo_roles.Items.Clear();
            this.Show();
            foreach (Rol rol in rolesDeUsuario)
            {
                combo_roles.Items.Add(rol);
            }
            combo_roles.DisplayMember = "Nombre";
        }

        private void btn_rol_aceptado_Click(object sender, EventArgs e)
        {

            if (camposVacios()) { return; }
            this.user.rol = (Rol)combo_roles.SelectedItem;
            {
                avanzarAMenuPpal();
            }
        }

        private void avanzarAMenuPpal()
        {
            this.Hide();
            inicializarSesion();
            MenuPpal menu = new MenuPpal(this.user);
            menu.ShowDialog();
            this.Close();
        }

        private void inicializarSesion()
        {
            Usuario.inicializarUsuarioActual(this.user);
            if (this.user.rol.id ==  2)
            {
                Empresa.Actual = EmpresasRepositorio.getEmpresa(this.user);
            } else if (this.user.rol.id == 3)
            {
                Cliente.Actual = ClienteRepositorio.getCliente(this.user);
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
           
        }

        private void ConfiguracionInicial_Load(object sender, EventArgs e)
        {

        }

        private void combo_roles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
