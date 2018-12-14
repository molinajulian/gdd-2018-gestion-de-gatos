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
using PalcoNet.Repositorios;

namespace PalcoNet.GenerarPublicacion
{
    public partial class AltaSector : MaterialForm
    {
        DataTable tabla_sectores = new DataTable();
        private List<Sector> sectoresRegistrados;
        public AltaSector(List<Sector> sectoresRegistrados)
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
           txtDetalle.Clear();
           txtAsientos.Clear();
           txtFilas.Clear();
        }

        private bool validarCamposSector()
        {
            bool error = false;
            if (String.IsNullOrWhiteSpace(txtDetalle.Text))
            {
                epProvider.SetError(txtDetalle, "Por favor complete el campo");
                error = true;
            }
            return error;
        }

        private void btn_volver_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_alta_sector_Click(object sender, EventArgs e)
        {
            epProvider.Clear();
            if (validarCamposSector()) { return; }

            if (sectoresRegistrados.Any(sector => sector.Detalle.Equals(txtDetalle.Text)))
            {
                MessageBox.Show("Ya existe un Sector con el nombre ingresado", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            agregarSector(new Sector(Convert.ToInt32(txtFilas.TextLength), Convert.ToInt32(txtAsientos.TextLength),
                txtDetalle.Text, Convert.ToInt32(cmbTipo.SelectedValue)));
            limpiarVentana();
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
    }
}
