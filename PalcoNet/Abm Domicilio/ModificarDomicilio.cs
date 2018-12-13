using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.Modelo;
using PalcoNet.Repositorios;

namespace PalcoNet.AbmDomicilio
{
    public partial class ModificarDomicilio : MaterialForm
    {
        Domicilio domicilio;
        public ModificarDomicilio(Domicilio domicilio)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.domicilio = domicilio;
            inicializarUi();
        }

        private void inicializarUi()
        {
            txCalle.Text = domicilio.Calle;
            txNumero.Text = domicilio.Numero;
            txCp.Text = domicilio.CodPostal;
            txLocalidad.Text = domicilio.Localidad;
            txPiso.Text = domicilio.Piso;
            txDpto.Text = domicilio.Departamento;
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

        private void actualizarDomicilioDeUi()
        {
            domicilio.Calle = txCalle.Text;
            domicilio.Numero = txNumero.Text;
            domicilio.Localidad = txLocalidad.Text;
            domicilio.CodPostal = txCp.Text;
            domicilio.Piso = txPiso.Text;
            domicilio.Departamento = txDpto.Text;
        }

        private void btn_actualizar_domicilio_Click(object sender, System.EventArgs e)
        {
            group_domicilio.Enabled = false;
            if (!validarCamposDomicilio())
            {
                group_domicilio.Enabled = true;
                return;
            }
            try
            {
                actualizarDomicilioDeUi();
                DomiciliosRepositorio.actualizar(domicilio);
                MessageBox.Show("El domicilio ha sido actualizado exitosamente", "Modificacion de domicilio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            group_domicilio.Enabled = true;
        }
    }
}
