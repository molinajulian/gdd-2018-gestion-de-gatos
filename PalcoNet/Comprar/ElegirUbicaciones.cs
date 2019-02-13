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
        DataTable tabla_ubicaciones_a_elegir = new DataTable();
        DataTable tabla_ubicaciones_elegidas= new DataTable();
        private List<Sector> sectoresRegistrados;
        private List<Ubicacion> ubicacionesAElegir;
        private List<Ubicacion> ubiacionesElegidas = new List<Ubicacion>();
        private PublicacionPuntual Publicacion;
        private List<Ubicacion> ubicacionesDisponibles;
        private ElegirPublicacion parte1;

        public ElegirUbicaciones(PublicacionPuntual publicacion, ElegirPublicacion elegirPublicacion)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            Publicacion = publicacion;
            parte1 = elegirPublicacion;
            elegirPublicacion.Hide();
            sectoresRegistrados = publicacion.getSectores();
            inicializarUbicacionesDisponibles();
            agregarEncabezadosTablas();
            actualizarListadoSectores();
        }

        private void inicializarUbicacionesDisponibles()
        {
            ubicacionesDisponibles = UbicacionRepositorio.getUbicacionesDisponibles(Publicacion.Espectaculo);
        }

        private void agregarEncabezadosTablas()
        {
            agregarEncabezadosTablaSectores();
            agregarEncabezadosTablaUbicacionesAElegir();
            agregarEncabezadosTablaUbicacionesElegidas();
        }

        private void agregarEncabezadosTablaSectores()
        {
            tabla_sectores.Clear();
            tabla_sectores.Columns.Add("Tipo de ubicacion");
            tabla_sectores.Columns.Add("Cantidad de Filas");
            tabla_sectores.Columns.Add("Cantidad de Asientos");
            tabla_sectores.Columns.Add("Precio");
        }

        private void agregarEncabezadosTablaUbicacionesAElegir()
        {
            tabla_ubicaciones_a_elegir.Clear();
            tabla_ubicaciones_a_elegir.Columns.Add("Tipo de ubicacion");
            tabla_ubicaciones_a_elegir.Columns.Add("Fila");
            tabla_ubicaciones_a_elegir.Columns.Add("Asiento");
            tabla_ubicaciones_a_elegir.Columns.Add("Precio");
        }

        private void agregarEncabezadosTablaUbicacionesElegidas()
        {
            tabla_ubicaciones_elegidas.Clear();
            tabla_ubicaciones_elegidas.Columns.Add("Tipo de ubicacion");
            tabla_ubicaciones_elegidas.Columns.Add("Fila");
            tabla_ubicaciones_elegidas.Columns.Add("Asiento");
            tabla_ubicaciones_elegidas.Columns.Add("Precio");
        }

        public void actualizarListadoSectores()
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
            data_listado_sectores.DataSource = tabla_sectores;
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

        public void actualizarListadoUbicacionAElegir(List<Ubicacion> ubicaciones)
        {
            ubicacionesAElegir = ubicaciones;
            tabla_ubicaciones_a_elegir.Rows.Clear();
            foreach (Ubicacion ubicacion in ubicaciones)
            {
                String[] ubiacionRow =
                {
                    ubicacion.TipoUbicacion.Descripcion, ubicacion.Fila.ToString(), ubicacion.Asiento.ToString(),
                    ubicacion.Precio.ToString()
                };
                tabla_ubicaciones_a_elegir.Rows.Add(ubiacionRow);
            }
            dgvUbicacionAElegir.DataSource = tabla_ubicaciones_a_elegir;
        }

        public void actualizarListadoUbicacionElegidas(Ubicacion ubicacion)
        {
            ubiacionesElegidas.Add(ubicacion);
            String[] ubiacionRow =
            {
                ubicacion.TipoUbicacion.Descripcion, ubicacion.Fila.ToString(), ubicacion.Asiento.ToString(),
                ubicacion.Precio.ToString()
            };
            tabla_ubicaciones_elegidas.Rows.Add(ubiacionRow);
            dgvUbicacionesElegidas.DataSource = tabla_ubicaciones_elegidas;
        }

        private void actualizarSeleccionDeAsiento(Sector sector)
        {
            actualizarListadoUbicacionAElegir(getUbicacionesAElegir(sector));
        }

        private List<Ubicacion> getUbicacionesAElegir(Sector sector)
        {
            return ubicacionesDisponibles
                            .FindAll(ubicacion => ubicacion.TipoUbicacion.Id == sector.TipoUbicacion.Id)
                            .FindAll(ubicacion => noReservada(ubicacion));
        }

        private Boolean noReservada(Ubicacion ubicacion)
        {
            return !ubiacionesElegidas.Contains(ubicacion);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (data_listado_sectores.SelectedRows.Count > 1)
            {
                MessageBox.Show("Debe seleccionar 1 y solo 1 registro", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                actualizarListadoUbicacionElegidas(ubicacionesAElegir[dgvUbicacionAElegir.SelectedRows[0].Index]);
                dgvUbicacionAElegir.Rows.Remove(dgvUbicacionAElegir.SelectedRows[0]); //Actualizo el estado de opciones
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ConfirmarCompra(ubiacionesElegidas, Publicacion, parte1, this).ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            parte1.Show();
        }
    }
}
