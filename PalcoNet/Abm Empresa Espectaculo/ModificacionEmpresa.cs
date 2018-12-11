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
using PalcoNet.Repositorios;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Text.RegularExpressions;

namespace PalcoNet.AbmEmpresa
{
    public partial class ModificacionEmpresa : MaterialForm
    {
        Empresa empresa;
       
        public ModificacionEmpresa(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            mostrarDatosEmpresa();
        }

        public void mostrarDatosEmpresa()
        {
            txtRazon.Text = empresa.RazonSocial;
            txtCuit.Text = empresa.Cuit;
            txtMail.Text = empresa.Email;
            txtTel.Text = empresa.Telefono;
            txtLocalidad.Text = empresa.Direccion.Localidad;
            txtCalle.Text = empresa.Direccion.Calle;
            txtNumero.Text = empresa.Direccion.Numero;
            txtCp.Text = empresa.Direccion.CodPostal;
            txtPiso.Text = empresa.Direccion.Piso;
            txtDepto.Text = empresa.Direccion.Departamento;
            checkDeshabilitada.Checked = !empresa.Habilitada;
        }

        public void actualizarInstanciaEmpresa()
        {
            empresa.RazonSocial = txtRazon.Text;
            empresa.Cuit = txtCuit.Text;
            empresa.Email = txtMail.Text;
            empresa.Telefono = txtTel.Text;
            empresa.Direccion.Localidad = txtLocalidad.Text;
            empresa.Direccion.Calle = txtCalle.Text;
            empresa.Direccion.Numero = txtNumero.Text;
            empresa.Direccion.CodPostal = txtCp.Text;
            empresa.Direccion.Piso = txtPiso.Text;
            empresa.Direccion.Departamento = txtDepto.Text;
            empresa.Habilitada = checkDeshabilitada.Checked;
        }

        private void btn_modificar_empresa_Click(object sender, EventArgs e)
        {
            if (!verificaValidaciones()) return;
            actualizarInstanciaEmpresa();
            limpiarVentana();
            MessageBox.Show("La empresa ha sido modificada exitosamente", "Modificacion de empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool verificaValidaciones()
        {
            errorProvider1.Clear();
            return formularioCompleto();
        }

       
        private void btn_atras_Click(object sender, EventArgs e)
        {
            this.Hide();
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
         private bool formularioCompleto()
         {
             bool error = true;

             var controles = grupo_empresa.Controls;
             controles.Remove(controles.Find("checkDeshabilitada", false)[0]);
             foreach (Control control in controles)
             {
                 if (string.IsNullOrWhiteSpace(control.Text))
                 {
                     errorProvider1.SetError(control, "Por favor complete el campo");
                     error = false;
                 }
             }
             return error;
         }


        private Empresa getEmpresaDeUi()
        {
            return new Empresa(txtRazon.Text, txtCuit.Text, txtMail.Text, txtTel.Text,
                new Direccion(txtCalle.Text, txtNumero.Text, txtDepto.Text, txtLocalidad.Text, txtCp.Text, txtPiso.Text),
                !checkDeshabilitada.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
         {
            grupo_empresa.Enabled = false;
            if (!verificaValidaciones())
            {
                grupo_empresa.Enabled = true;
                return;
            }
            try
            {
                EmpresasRepositorio.actualizar(getEmpresaDeUi());
                MessageBox.Show("La empresa ha sido modificada exitosamente", "Modificacion de empresa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            grupo_empresa.Enabled = true;
        }

    }
}
