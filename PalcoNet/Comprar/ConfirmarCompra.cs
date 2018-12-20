﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.AbmTarjeta;
using PalcoNet.Repositorios;

namespace PalcoNet.Comprar
{
    public partial class ListaSector : MaterialForm
    {
        DataTable tabla_ubicaciones = new DataTable();
        private List<Ubicacion> UbicacionesAComprar;
        private PublicacionPuntual PublicacionElegida;
        public ListaSector(List<Ubicacion> ubicacionesElegidas, PublicacionPuntual publicacionElegida)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            UbicacionesAComprar = ubicacionesElegidas;
            PublicacionElegida = publicacionElegida;
            agregarEncabezadosTabla();
            actualizarListado();
        }

        private void agregarEncabezadosTabla()
        {
            tabla_ubicaciones.Columns.Add("Nro Fila");
            tabla_ubicaciones.Columns.Add("Nro Asiento");
            tabla_ubicaciones.Columns.Add("Precio");
            tabla_ubicaciones.Columns.Add("Espectaculo");
        }

        private void actualizarTablaUbicaciones()
        {
            data_ubicaciones.DataSource = tabla_ubicaciones;
        }

        public void actualizarListado()
        {
            tabla_ubicaciones.Rows.Clear();
            foreach (Ubicacion ubicacion in UbicacionesAComprar)
            {
                String[] ubicacionRow = 
                {
                    ubicacion.Fila.ToString(), ubicacion.Asiento.ToString(),
                    ubicacion.Precio.ToString(), PublicacionElegida.Espectaculo.Descripcion
                };
                tabla_ubicaciones.Rows.Add(ubicacionRow);
            }
            actualizarTablaUbicaciones();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void btnComprar_Click(object sender, EventArgs e)
        {
            CompraRepositorio.realizarCompra(UbicacionesAComprar, PublicacionElegida);
        }

        private void btn_agregar_tarjeta_Click(object sender, EventArgs e)
        {
            new AltaTarjeta(Cliente.Actual).ShowDialog();
        }
    }
}
