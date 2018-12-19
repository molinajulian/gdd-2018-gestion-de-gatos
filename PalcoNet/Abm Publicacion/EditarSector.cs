using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.Repositorios;

namespace PalcoNet.AbmPublicaciones
{
    public partial class EditarSector : MaterialForm
    {
        DataTable tabla_sectores = new DataTable();
        private Sector sector;
        private ListaSector listaSector;
        public EditarSector(Sector sector, ListaSector listaSector)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.sector = sector;
            this.listaSector = listaSector;
            inicializarUi();
            inicializarTiposDeUbicacion();
            agregarEncabezadosTabla();
        }

        private void inicializarUi()
        {
            txtFilas.Text = sector.CantidadFilas.ToString();
            txtAsientos.Text = sector.CantidadAsientos.ToString();
            txtPrecio.Text = sector.Precio.ToString();
        }

        private void agregarEncabezadosTabla()
        {
            tabla_sectores.Columns.Add("Tipo de ubicacion");
            tabla_sectores.Columns.Add("Cantidad de Filas");
            tabla_sectores.Columns.Add("Cantidad de Asientos");
            tabla_sectores.Columns.Add("Precio");
        }

        private void inicializarTiposDeUbicacion()
        {
            SqlDataReader lector = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Ubicaciones_Tipo", "T", new List<SqlParameter>());
            List<TipoUbicacion> tipos = new List<TipoUbicacion>();
            TipoUbicacion tipoUbicacion;
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    tipoUbicacion = TipoUbicacion.build(lector);
                    tipos.Add(tipoUbicacion);
                    cmbTipo.Items.Add(tipoUbicacion);
                }
            }
            lector.Close();
            cmbTipo.DisplayMember = "Descripcion";
            cmbTipo.ValueMember = "Id";
            cmbTipo.SelectedItem = tipos.Find(ubicacion => ubicacion.Id == sector.TipoUbicacion.Id);
        }

        private Sector getSectorDeUi()
        {
            return new Sector(Convert.ToInt32(txtFilas.Text),
                              Convert.ToInt32(txtAsientos.Text),
                              (TipoUbicacion) cmbTipo.SelectedItem, 
                              Convert.ToDouble(txtPrecio.Text));
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sector.reemplazar(getSectorDeUi());
            listaSector.actualizarListado();
            MessageBox.Show("Sectores Agregados", "Alta Sectores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
