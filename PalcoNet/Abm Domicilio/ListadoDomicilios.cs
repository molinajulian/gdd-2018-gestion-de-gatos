﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PalcoNet.Modelo;
using PalcoNet.Repositorios;
using MaterialSkin.Controls;
using MaterialSkin;

namespace PalcoNet.AbmDomicilio
{
    public partial class ListadoDomicilios : MaterialForm
    {
        DataTable tabla_domicilios = new DataTable();
        Char modo;
        Rol rol_actual;
        Menu menu;
        private List<Domicilio> domicilios;
        private Domicilio domicilioElegido;
        public ListadoDomicilios(Domicilio domicilioAElegir)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            tabla_domicilios.Columns.Add("Calle");
            tabla_domicilios.Columns.Add("Numero");
            tabla_domicilios.Columns.Add("Piso");
            tabla_domicilios.Columns.Add("Departamento");
            tabla_domicilios.Columns.Add("Localidad");
            tabla_domicilios.Columns.Add("Codigo Postal");
            domicilioElegido = domicilioAElegir;
        }


        public void actualizarListado()
        {
            data_listado_domicilios.DataSource = tabla_domicilios;
        }

        private void limpiarTabla()
        {
            tabla_domicilios.Rows.Clear();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            tabla_domicilios.Rows.Clear();
            domicilios = DomiciliosRepositorio.getDomicilios(txCalle.Text, txNumero.Text);
            foreach(Domicilio domicilio in domicilios)
            {
                String[] domiRow = new String[]
                {
                    domicilio.Calle, domicilio.Numero, domicilio.Piso, domicilio.Departamento,
                    domicilio.Localidad, domicilio.CodPostal
                };
                tabla_domicilios.Rows.Add(domiRow);
            }
            actualizarListado();
        }


        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txCalle.Clear();
            txNumero.Clear();
            limpiarTabla();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if(data_listado_domicilios.SelectedRows.Count == 1) { 
                domicilioElegido.reemplazar(domicilios[data_listado_domicilios.SelectedRows[0].Index]);
                MessageBox.Show("Domicilio seleccionado exitosamente", "Seleccion de domicilio", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar 1, y solo 1 fila para marcar la seleccion", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            AltaDomicilio alta = new AltaDomicilio(ref domicilioElegido, true);
            alta.ShowDialog();
        }
    }
}
