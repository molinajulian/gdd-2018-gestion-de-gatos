using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.Repositorios;

namespace PalcoNet.AbmDomicilio
{
    public partial class AltaDomicilio : MaterialForm
    {

        private Domicilio domicilio = null;
        public AltaDomicilio(Domicilio domicilio)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.domicilio = domicilio;
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void setDomicilioDeUi()
        {
            domicilio.Calle = txCalle.Text;
            domicilio.Numero = txNumero.Text;
            domicilio.Departamento = txDpto.Text;
            domicilio.Localidad = txLocalidad.Text;
            domicilio.CodPostal = txCp.Text;
            domicilio.Piso = txPiso.Text;
        }
        private void btn_alta_rol_Click(object sender, EventArgs e)
        {
            if (!validarCamposDomicilio()) { return; }
            try
            {
                setDomicilioDeUi();
                MessageBox.Show("Domicilio Registrado Exitosamente", "Alta Domicilio", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void limpiarVentana()
        {
            var textBoxes = group_alta_rol.Controls.OfType<TextBox>();
            foreach(TextBox textbox in textBoxes)
            {
                textbox.Clear();
            }
        }

        private bool validarCamposDomicilio()
        {
            if (!Regex.IsMatch(txLocalidad.Text, @"^[a-zA-Z0-9\s]{1,20}$"))
            {
                MessageBox.Show("Ingrese una localidad válida.");
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
    }
}
