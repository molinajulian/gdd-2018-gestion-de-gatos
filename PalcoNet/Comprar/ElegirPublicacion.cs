﻿using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.Repositorios;

namespace PalcoNet.Comprar
{
    public partial class ElegirPublicacion : MaterialForm
    {
        Cliente cliente;
        DataTable tabla_publicaciones = new DataTable();
        List<PublicacionPuntual> Publicaciones = new List<PublicacionPuntual>();
        public ElegirPublicacion()
        {
            InitializeComponent();
            cliente = Cliente.Actual;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            tabla_publicaciones.Columns.Add("Descripcion Publicacion", typeof(string));
            tabla_publicaciones.Columns.Add("Titulo Espectaculo", typeof(string));
            tabla_publicaciones.Columns.Add("Fecha ocurrencia", typeof(string));
            inicializarRubros();
        }

        public void inicializarRubros()
        {
            foreach (Rubro rubro in RubroRepositorio.getRubros())
            {
                lvCategorias.Items.Add(rubro);
            }

            lvCategorias.DisplayMember = "Descripcion";
            lvCategorias.ValueMember = "Codigo";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool validarCamposCompra()
        {
            if (dtpHasta.Value.CompareTo(dtpDesde.Value) != 1)
            {
                MessageBox.Show("La fecha limite debe ser mayor que la inicial", "Compra", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validarCamposCompra())
            {
                return;
            }
            actualizarListado(PublicacionRepositorio.getPublicacionesComprables(txtDescripcion.Text, dtpDesde.Value, dtpHasta.Value,
                                                                                getCategoriasStr()));
        }

        private String getCategoriasStr()
        {
            String expr = "";
            foreach (Rubro rubro in lvCategorias.SelectedItems)
            {
                expr += rubro.Codigo + ",";
            }

            expr = expr.Trim(',');
            return expr;
        }

        private void actualizarListado(List<PublicacionPuntual> publicaciones)
        {
            Publicaciones = publicaciones;
            tabla_publicaciones.Rows.Clear();
            foreach (PublicacionPuntual publicacion in publicaciones)
            {
                String[] publicacionRow = { publicacion.Descripcion , publicacion.Espectaculo.Descripcion,
                                            publicacion.Espectaculo.FechaOcurrencia.ToString() };
                tabla_publicaciones.Rows.Add(publicacionRow);
            }
            data_publicaciones.DataSource = tabla_publicaciones;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (data_publicaciones.SelectedRows.Count > 1)
            {
                MessageBox.Show("Debe seleccionar 1 y solo 1 registro", "Advertencia", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                new ElegirUbicaciones(Publicaciones[data_publicaciones.SelectedRows[0].Index]).ShowDialog();
            }
        }
    }
}