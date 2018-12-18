﻿using System;
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
    public partial class EditarSector : MaterialForm
    {
        DataTable tabla_sectores = new DataTable();
        private List<Sector> sectoresRegistrados;
        public EditarSector(List<Sector> sectoresRegistrados)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.sectoresRegistrados = sectoresRegistrados;
            inicializarTiposDeUbicacion();
            agregarEncabezadosTabla();
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
            TipoUbicacion tipoUbicacion;
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    tipoUbicacion = TipoUbicacion.build(lector);
                    cmbTipo.Items.Add(tipoUbicacion);
                }
            }
            lector.Close();
            cmbTipo.DisplayMember = "Descripcion";
            cmbTipo.ValueMember = "Id";
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

        public void agregarSector(Sector sector)
        {
            sectoresRegistrados.Add(sector);
            actualizarListado();
            limpiarVentana();
        }

        private void actualizarTablaSectores()
        {
            data_listado_sectores.DataSource = tabla_sectores;
        }

        private void btn_alta_sector_Click_1(object sender, EventArgs e)
        {
            epProvider.Clear();
            if (validarCamposSector()) { return; }
            if (sectoresRegistrados.Any(sector => sector.Detalle.Equals(txtDetalle.Text)))
            {
                MessageBox.Show("Ya existe un Sector con el nombre ingresado", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            agregarSector(getSectorDeUi());
        }

        private void actualizarListado()
        {
            tabla_sectores.Rows.Clear();
            foreach (Sector sector in sectoresRegistrados)
            {
                String[] sectorRow = 
                {
                    sector.CantidadFilas.ToString(), sector.CantidadAsientos.ToString(),
                    sector.TipoUbicacion.Descripcion, sector.Precio.ToString()
                };
                tabla_sectores.Rows.Add(sectorRow);
            }
            actualizarTablaSectores();
        }

        private Sector getSectorDeUi()
        {
            return new Sector(Convert.ToInt32(txtFilas.Text),
                Convert.ToInt32(txtAsientos.Text), txtDetalle.Text,
                (TipoUbicacion) cmbTipo.SelectedItem, 
                Convert.ToDouble(txtPrecio.Text));
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sectores Agregados", "Alta Sectores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
