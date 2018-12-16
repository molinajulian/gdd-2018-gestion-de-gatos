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
    public partial class CambiarContraseña : MaterialForm
    {
        Usuario user;
        private List<Rol> rolesDeUsuario;
        Log login;
        string errorAlCambiar = "Ha ocurrido un error al cambiar la contraseña";
        public CambiarContraseña(Usuario user, Log login)
        {
            InitializeComponent();
            this.user = user;
            this.login=login;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        private void avanzarAMenuPpal()
        {
            this.Hide();
            MenuPpal menu = new MenuPpal(this.user, this.login);
            menu.ShowDialog();
            this.Close();
        }
        private void btn_Cambiar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContraseña.Text) || string.IsNullOrEmpty(txtRepetirContraseña.Text))
            {
                MessageBox.Show("Por favor complete los campos", errorAlCambiar, MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation);
            }
            else
            {
                if (txtContraseña.Text.Length > 20 || txtRepetirContraseña.Text.Length > 20)
                {
                    MessageBox.Show("Las contraseñas no pueden ser mayor a 20 caracteres", errorAlCambiar, MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (txtContraseña.Text != txtRepetirContraseña.Text)
                    {
                        MessageBox.Show("Las contraseñas deben ser iguales", errorAlCambiar, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        try
                        {
                            UsuarioRepositorio.cambiarContraseña(user.id, txtContraseña.Text);
                            new ConfiguracionInicial(user, login).Show();

                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, errorAlCambiar, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }

                    }
                }
                
            }
            
        }

        private void txtContraseña_Click(object sender, EventArgs e)
        {
            txtContraseña.Clear();
            txtContraseña.UseSystemPasswordChar = true;
        }

        private void txtRepetirContraseña_Click(object sender, EventArgs e)
        {
            txtRepetirContraseña.Clear();
            txtRepetirContraseña.UseSystemPasswordChar = true;
        }

        private void CambiarContraseña_Load(object sender, EventArgs e)
        {

        }
    }
}
