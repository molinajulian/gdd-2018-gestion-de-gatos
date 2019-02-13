using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Data.SqlClient;
using PalcoNet.Repositorios;

namespace PalcoNet.AbmGrado
{
    public partial class AltaGrado : MaterialForm
    {
        public AltaGrado()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }
        private void btn_alta_grado_Click(object sender, EventArgs e)
        {
            epProvider.Clear();
            if (validarCamposGrado()) { return; }
            try  
            {
                GradoRepositorio.agregar((float)Convert.ToInt32(txtGrado.Text) / 100, txtNombre.Text);
                limpiarVentana();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error al intentar crear el grado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiarVentana()
        {
            var textBoxes = group_alta_grado.Controls.OfType<TextBox>();
            foreach(TextBox textbox in textBoxes)
            {
                textbox.Clear();
            }

        }

        private bool validarCamposGrado()
        {
            bool error = false;
            if (String.IsNullOrWhiteSpace(txtNombre.Text))
            {
                epProvider.SetError(txtNombre, "Por favor complete el campo");
                error = true;
            }
            if (String.IsNullOrWhiteSpace(txtGrado.Text))
            {
                epProvider.SetError(txtGrado, "Por favor complete el campo");
                error = true;
            }
            if (!String.IsNullOrWhiteSpace(txtGrado.Text) && Convert.ToInt32(txtGrado.Text) >=100)
            {
                epProvider.SetError(txtGrado, "No se puede crear un grado que gane más o igual que el 100%");
                error = true;
            }
            return error;
        }

        private void txtGrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
