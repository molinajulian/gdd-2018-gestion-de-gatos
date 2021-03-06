﻿using MaterialSkin;
using MaterialSkin.Controls;
using PalcoNet.Modelo;
using PalcoNet.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PalcoNet.AbmCliente
{
    public partial class ListadoCliente : MaterialForm
    {
        DataTable tabla_clientes = new DataTable();
        List<Cliente> clientes = new List<Cliente>();
        public ListadoCliente(char modo)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            initColumns();
            if (modo == 'B') buttonModificar.Hide();
            else buttonHabilitar.Hide();
        }

        private void initColumns()
        {
            tabla_clientes.Columns.Add("Tipo doc", typeof(string));
            tabla_clientes.Columns.Add("Documento", typeof(string));
            tabla_clientes.Columns.Add("Cuil", typeof(string));
            tabla_clientes.Columns.Add("Nombre", typeof(string));
            tabla_clientes.Columns.Add("Apellido", typeof(string));
            tabla_clientes.Columns.Add("Email", typeof(string));
            tabla_clientes.Columns.Add("Calle", typeof(string));
            tabla_clientes.Columns.Add("Numero", typeof(string));
            tabla_clientes.Columns.Add("Localidad", typeof(string));
            tabla_clientes.Columns.Add("Codigo postal", typeof(string));
            tabla_clientes.Columns.Add("Habilitado", typeof(string));
            actualizarTabla();
        }

        private bool validarBusqueda()
        {
            if (!string.IsNullOrEmpty(tx_dni.Text) && !Regex.IsMatch(tx_dni.Text, @"^[0-9]{1,8}$"))
            {
                MessageBox.Show("Ingrese un DNI válido.");
                return false;
            }
            if (!string.IsNullOrEmpty(tx_nombre.Text) && !Regex.IsMatch(tx_nombre.Text, @"^[a-zA-Z\s]{1,30}$"))
            {
                MessageBox.Show("Ingrese un nombre válido.");
                return false;
            }
            if (!string.IsNullOrEmpty(tx_apellido.Text) && !Regex.IsMatch(tx_apellido.Text, @"^[a-zA-Z\s]{1,30}$"))
            {
                MessageBox.Show("Ingrese un apellido válido.");
                return false;
            }
            if (!string.IsNullOrEmpty(txEmail.Text) && !Regex.IsMatch(txEmail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Ingrese un mail válido.");
                return false;
            }
            return true;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (!validarBusqueda()) { return; }
            tabla_clientes.Clear();
            clientes = ClienteRepositorio.getClientes(tx_nombre.Text, tx_apellido.Text, tx_dni.Text, txEmail.Text);
            foreach (Cliente c in clientes)
            {
                string[] row = { c.TipoDeDocumento.Descripcion, c.NumeroDocumento.ToString(), c.Cuil,
                    c.NombreCliente, c.Apellido, c.Email, c.Domicilio.Calle, c.Domicilio.Numero,
                    c.Domicilio.Localidad, c.Domicilio.CodPostal, c.Habilitado ? "Si" : "No" };
                tabla_clientes.Rows.Add(row);
            }
            actualizarTabla();
            if(clientes.Count > 0) { 
                buttonModificar.Enabled = true;
            }
            else
            {
                buttonModificar.Enabled = false;
            }
        }
        public void actualizarTabla()
        {
            data_clientes.DataSource = tabla_clientes;
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            tabla_clientes.Rows.Clear();
            actualizarTabla();
        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (this.data_clientes.RowCount > 0)
            {
                if (data_clientes.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Debe seleccionar de a 1 registro", "Advertencia", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                } else { 
                    new ModificacionCliente(clientes[data_clientes.SelectedRows[0].Index]).Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Busque y seleccione un cliente antes.");
            }
        }
        private void actualizarEstado(int indice, Cliente c)
        {
            string[] row = { c.TipoDeDocumento.Descripcion, c.NumeroDocumento.ToString(), c.Cuil,
                    c.NombreCliente, c.Apellido, c.Email, c.Domicilio.Calle, c.Domicilio.Numero,
                    c.Domicilio.Localidad, c.Domicilio.CodPostal, c.Habilitado ? "Si" : "No"};
            data_clientes.Rows[indice].SetValues(row);
        }
        private void buttonHabilitar_Click(object sender, EventArgs e)
        {
            if (this.data_clientes.RowCount > 0)
            {
                if (data_clientes.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Debe seleccionar de a 1 registro", "Advertencia", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        Cliente seleccionado= clientes[data_clientes.SelectedRows[0].Index];
                        seleccionado.Habilitado = ClienteRepositorio.eliminarCliente(Convert.ToInt32(seleccionado.TipoDeDocumento.Id), Convert.ToDecimal(seleccionado.NumeroDocumento), !seleccionado.Habilitado);
                        actualizarEstado(data_clientes.SelectedRows[0].Index, seleccionado);
                        actualizarTabla();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error al cambiar el estado del cliente", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Busque y seleccione un cliente antes.");
            }
        }
    }
}
