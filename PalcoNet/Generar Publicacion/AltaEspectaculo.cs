using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.Repositorios;

namespace PalcoNet.GenerarPublicacion
{
    public partial class AltaEspectaculo : MaterialForm
    {
        DataTable tabla_sectores = new DataTable();
        private List<Sector> sectoresRegistrados;
        public AltaEspectaculo(List<Sector> sectoresRegistrados)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.sectoresRegistrados = sectoresRegistrados;
        }

        private void limpiarVentana()
        {
           txtDescripcion.Clear();
           txtLocalidad.Clear();
           txtCalle.Clear();
           txtCp.Clear();
           txtNumero.Clear();
           txtDepto.Clear();
           txtPiso.Clear();
        }

        private bool formularioCompleto()
        {
            bool verifica = true;

            var controles = group_alta_espectaculo.Controls;
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

        private bool validarCamposEspectaculo()
        {
            epProvider.Clear();
            if (formularioCompleto()) return false;
            return true;
        }

        public void agregarSector(Sector sector)
        {
            sectoresRegistrados.Add(sector);
            actualizarTablaSectores();
        }

        private void actualizarTablaSectores()
        {
            data_listado_sectores.DataSource = tabla_sectores;
        }

        private Espectaculo getEspectaculoDeUi()
        {
            return null; //return new Espectaculo(//TODO: Aca);
        }

        private void btn_alta_espectaculo_Click(object sender, EventArgs e)
        {
            group_alta_espectaculo.Enabled = false;
            if (validarCamposEspectaculo()) { return; }
            EspectaculoRepositorio.CreateEspectaculo(getEspectaculoDeUi());
            limpiarVentana();
            group_alta_espectaculo.Enabled = true;
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
