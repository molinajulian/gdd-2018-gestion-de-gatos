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

namespace PalcoNet.AbmEmpresa
{
    public partial class AltaEmpresa : MaterialForm
    {
        public AltaEmpresa()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private Empresa getEmpresaDeUi()
        {
             return new Empresa(txtRazon.Text, txtCuit.Text, txtMail.Text, txtTel.Text,
                new Direccion(txCalle.Text, txNumero.Text, txDpto.Text, txLocalidad.Text, txCp.Text, txPiso.Text));
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
            if (!Regex.IsMatch(txCp.Text, @"^[0-9]{1,4}$"))
            {
                MessageBox.Show("Ingrese un código postal válido.");
                return false;
            }
            if (!Regex.IsMatch(txPiso.Text, @"^[0-9]{1,3}$") && !string.IsNullOrEmpty(txPiso.Text))
            {
                MessageBox.Show("Ingrese un piso válido.");
                return false;
            }
            if (!Regex.IsMatch(txDpto.Text, @"^[a-zA-Z]$") && !string.IsNullOrEmpty(txDpto.Text))
            {
                MessageBox.Show("Ingrese un departamento válido.");
                return false;
            }
            if (!Regex.IsMatch(txCalle.Text, @"[a-zA-Z0-9\s]{1,50}$"))
            {
                MessageBox.Show("Ingrese una calle válida.");
                return false;
            }
            if (!Regex.IsMatch(txNumero.Text, @"^[0-9]{1,6}$"))
            {
                MessageBox.Show("Ingrese un número válido.");
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
                 if (string.IsNullOrWhiteSpace(control.Text))
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


        private void button1_Click(object sender, EventArgs e)
        {
            grupo_empresa.Enabled = false;
            if (!verificaValidaciones())
            {
                grupo_empresa.Enabled = true;
                return;
            }
            try { 
                EmpresasRepositorio.agregar(getEmpresaDeUi());
                limpiarVentana();
                MessageBox.Show("La empresa ha sido dada de alta exitosamente", "Alta de empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            grupo_empresa.Enabled = true;
        }

    }
}
