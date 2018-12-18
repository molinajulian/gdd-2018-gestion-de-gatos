using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.Repositorios;

namespace PalcoNet.AbmPublicaciones
{
    public partial class ListaSector : MaterialForm
    {
        DataTable tabla_sectores = new DataTable();
        private List<Sector> sectoresRegistrados;
        public ListaSector(List<Sector> sectoresRegistrados)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.sectoresRegistrados = sectoresRegistrados;
            agregarEncabezadosTabla();
        }

        private void agregarEncabezadosTabla()
        {
            tabla_sectores.Columns.Add("Tipo de ubicacion");
            tabla_sectores.Columns.Add("Cantidad de Filas");
            tabla_sectores.Columns.Add("Cantidad de Asientos");
            tabla_sectores.Columns.Add("Precio");
        }


        private void actualizarTablaSectores()
        {
            data_listado_sectores.DataSource = tabla_sectores;
        }


        private void actualizarListado()
        {
            tabla_sectores.Rows.Clear();
            foreach (Sector sector in sectoresRegistrados)
            {
                String[] sectorRow = 
                {
                    sector.TipoUbicacion.Descripcion, sector.CantidadFilas.ToString(), sector.CantidadAsientos.ToString(),
                    sector.Precio.ToString()
                };
                tabla_sectores.Rows.Add(sectorRow);
            }
            actualizarTablaSectores();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*EditarSector editarSector = new EditarSector();
            this.Close();*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*SqlDataReader lector = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Ubicaciones WHERE Ubic_Espec_Cod = " + espectaculo.Id, "T", new List<SqlParameter>());
            while (lector.HasRows && lector.Read())
            {
            }*/
        }
    }
}
