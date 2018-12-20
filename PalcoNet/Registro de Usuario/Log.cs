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
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Registro_de_usuario
{
    public partial class Log : MaterialForm
    {
        bool rolCliente = false;
        bool rolEmpresa = false;
        private UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
        string errorAlIngresar = "Ha ocurrido un error al intentar ingresar al sistema.";
        public Log()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            reiniciarSesiones();
            try
            {
                getTiposDocumento();
                getRoles();
                comboTiposDoc.Hide();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ha ocurrido un error al inicializar el sistema.", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void reiniciarSesiones()
        {
            Usuario.Actual = null;
            Empresa.Actual = null;
            Cliente.Actual = null;
        }

        public void getRoles()
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
        public void getTiposDocumento()
        {
            List<TipoDocumento> tipos = new List<TipoDocumento>();
            comboTiposDoc.Items.Clear();
            tipos = ClienteRepositorio.getTiposDoc();
            foreach (TipoDocumento tipo in tipos)
            {
                comboTiposDoc.Items.Add(tipo);
                comboTiposDoc.DisplayMember = "Descripcion";
            }
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            
            
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
                try
                {
                    Rol rolSeleccionado = (Rol)combo_roles.SelectedItem;
                    TipoDocumento tipoDocumentoSeleccionado = (TipoDocumento)comboTiposDoc.SelectedItem;
                    string tipoUsuario = setTipoUsuario(rolSeleccionado.nombre);
                    int TipoDocumento=0;
                    if (tipoUsuario == "C") TipoDocumento = Convert.ToInt32(tipoDocumentoSeleccionado.Id);
                    int idUsuario = usuarioRepositorio.validarUsuario(textUsuario.Text, textContrasena.Text, tipoUsuario, TipoDocumento);
                    Usuario usuarioLogueado = UsuarioRepositorio.buscarUsuario(idUsuario);
                    if (tipoUsuario == "C")
                    {
                        Cliente.Actual = ClienteRepositorio.getCliente(usuarioLogueado);
                    }
                    else if(tipoUsuario == "E")
                    {
                        Empresa.Actual = EmpresasRepositorio.getEmpresa(usuarioLogueado);
                    }
                    if (usuarioLogueado.primerLogueo)
                    {
                        new CambiarContraseña(usuarioLogueado).ShowDialog();
                        textContrasena.Text = "Contraseña";
                        textUsuario.Text = "Nombre de Usuario";
                        textContrasena.UseSystemPasswordChar = false;
                        this.Show();
                    }
                    else
                    {
                        ConfiguracionInicial ci = new ConfiguracionInicial(usuarioLogueado);
                        if (ci.IsDisposed) this.Show(); ;
                        textContrasena.Text = "Contraseña";
                        textUsuario.Text = "Nombre de Usuario";
                        textContrasena.UseSystemPasswordChar = false;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, errorAlIngresar, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    this.Show();
                }
            }
        }
        private string setTipoUsuario(string nombre)
        {
            if (nombre == "EMPRESA")
            {
                return "E";
            }
            else
            {
                return nombre == "CLIENTE" ? "C" : "O";
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
        private void textUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (rolCliente && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if (rolEmpresa && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
                {
                    e.Handled = true;
                }
                else
                {
                    rolCliente = false;
                    rolEmpresa = false;
                }
            }
        }
        private void combo_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rol seleccionado = (Rol)combo_roles.SelectedItem;
            if (seleccionado.nombre == "CLIENTE")
            {
                comboTiposDoc.Show();
                rolCliente = true;
                rolEmpresa = false;
            }
            else
            {
                comboTiposDoc.Hide();
                rolCliente = false;
                if (seleccionado.nombre == "EMPRESA") rolEmpresa = true;
            }
        }

        private void btnNoTengoUsuario_Click(object sender, EventArgs e)
        {
            new TipoDeRegistro().ShowDialog();
        }

    }
}
