using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Modelo;
using PalcoNet.Repositorios;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Text.RegularExpressions;
using PalcoNet.AbmDomicilio;

namespace PalcoNet.AbmEmpresa
{
    public partial class AltaEmpresa : MaterialForm
    {
        Domicilio domicilio = new Domicilio();
        bool esRegistro;
        public AltaEmpresa(bool registro=false)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            esRegistro = registro;
            if (!registro)
            {
                labelAclaracion.Hide();
                labelUsuario.Hide();
                labelContraseña.Hide();
                txtContraseña.Hide();
                txtUsuario.Hide();
                txtUsuario.Enabled = false;
            }
        }

        private Empresa getEmpresaDeUi()
        {
             return new Empresa(txtRazon.Text, txtCuit.Text, txtMail.Text, txtTel.Text, domicilio);
        }

        private bool verificaValidaciones()
        {
            epProvider.Clear();
            if (!formularioCompleto())  return false ; 
            if (!verificaTiposDeDatos()) return false;
            return true;
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool verificaTiposDeDatos()
        {
            if (!Regex.IsMatch(txtMail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Ingrese un mail válido.");
                return false;
            }
            if (!Regex.IsMatch(txtTel.Text, @"^[0-9]{1,20}$"))
            {
                MessageBox.Show("Ingrese un telefono válido.");
                return false;
            }
            if (!Regex.IsMatch(txtCuit.Text, @"[0-9]{2}-[0-9]{5,9}-[0-9]{1,2}$"))
            {
                MessageBox.Show("Ingrese un CUIT válido.");
                return false;
            }
            if (string.IsNullOrEmpty(domicilio.Calle))
            {
                MessageBox.Show("Debe registrar un domicilio.");
                return false;
            }
            return true;
        }

        private bool formularioCompleto()
        {
            bool verifica = true;
             var controles =grupo_empresa.Controls;
             foreach (Control control in controles)
             {
                 if (((control.Name == "txtUsuario" || control.Name == "txtContraseña") && esRegistro) && string.IsNullOrWhiteSpace(control.Text))
                 {
                     epProvider.SetError(control, "Por favor complete el campo");
                     verifica = false;
                 }
             }
             return verifica;
        }

        private void limpiarVentana()
        {
            var textboxes = grupo_empresa.Controls.OfType<TextBox>();
            foreach (TextBox textbox in textboxes)
            {
                textbox.Clear();
            }
            var comboboxes = grupo_empresa.Controls.OfType<ComboBox>();
            foreach (ComboBox combo_box in comboboxes)
            {
                combo_box.ResetText();
            }
        }


        private void btn_alta_empresa_Click(object sender, EventArgs e)
        {
            grupo_empresa.Enabled = false;
            if (!verificaValidaciones())
            {
                grupo_empresa.Enabled = true;
                return;
            }
            try
            {
                Empresa empresa = getEmpresaDeUi();
                empresa.Domicilio.Id = DomiciliosRepositorio.agregar(domicilio);
                EmpresasRepositorio.agregar(empresa,esRegistro ? txtContraseña.Text : "");
                limpiarVentana();
                MessageBox.Show("La empresa ha sido dada de alta exitosamente", "Alta de empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            grupo_empresa.Enabled = true;
        }

        private void buttonAltaDomicilio_Click(object sender, EventArgs e)
        {
            AltaDomicilio altaDomicilio = new AltaDomicilio(ref domicilio);
            altaDomicilio.ShowDialog();
            buttonAltaDomicilio.Hide();
        }

        private void txtCuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtUsuario.Visible && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            else
            {
                if (e.KeyChar == '\b')
                {
                    if(txtCuit.Text.Length > 0)
                    {
                        txtUsuario.Text = txtCuit.Text.Substring(0,txtCuit.Text.Length-1);
                    }
                }
                else
                {
                    txtUsuario.Text += e.KeyChar.ToString();
                }
                
            }
        }
        private void txtContraseña_Click(object sender, EventArgs e)
        {
            txtContraseña.Clear();
            txtContraseña.UseSystemPasswordChar = true;
        }

        private void grupo_empresa_Enter(object sender, EventArgs e)
        {

        }
    }
}
