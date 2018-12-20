using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.Repositorios;

namespace PalcoNet.Comprar
{
    public partial class ElegirUbicaciones : MaterialForm
    {
        DataTable tabla_sectores = new DataTable();
        private List<Sector> sectoresRegistrados;
        private PublicacionPuntual Publicacion;

        public ElegirUbicaciones(PublicacionPuntual publicacion)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            Publicacion = publicacion;
            sectoresRegistrados = publicacion.getSectores();
            agregarEncabezadosTabla();
            actualizarListado();
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

        public void actualizarListado()
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
            if (data_listado_sectores.SelectedRows.Count > 1)
            {
                MessageBox.Show("Debe seleccionar 1 y solo 1 registro", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                actualizarSeleccionDeAsiento(sectoresRegistrados[data_listado_sectores.SelectedRows[0].Index]);
            }
        }

        private void actualizarSeleccionDeAsiento(Sector sector)
        {
            List<Ubicacion> ubicacionesDisponibles = UbicacionRepositorio.getUbicacionesDisponibles(sector, Publicacion.Espectaculo);
            txtTipo.Text = sector.TipoUbicacion.Descripcion;
            //cmbFila.Items
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Agrego la ubicacion a ubicaciones elegidas
            //Actualizo el dgv de ubicaciones de abajo
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Paso a la pantalla siguiente las ubicaciones elegidas y la publicacionPuntual
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
