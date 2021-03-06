﻿using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.Repositorios;

namespace PalcoNet.AbmTarjeta
{
    public partial class AltaTarjeta : MaterialForm
    {
        Cliente cliente;
        private bool Persistente;

        public AltaTarjeta(Cliente c, bool persistente = false)
        {
            InitializeComponent();
            cliente = c;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            Persistente = persistente;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void limpiarVentana()
        {
            var text_boxes = groupBox1.Controls.OfType<TextBox>();
            foreach(TextBox textbox in text_boxes)
            {
                textbox.Clear();
            }
        }

        private bool validarCamposVaciosCliente()
        {
            bool error = false;
            var controles = groupBox1.Controls;
            foreach (Control control in controles)
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    error = true;
                    break;
                }
            }
            return error;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (txtNumero.Text.Length > 16 || txtBanco.Text.Length == 0)
            {
                MessageBox.Show("Ingrese un numero de tarjeta válido y un banco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Tarjeta tarjeta = new Tarjeta(Convert.ToInt64(txtNumero.Text), txtBanco.Text,
                    datePickerFechaVenc.Value);
                cliente.Tarjetas.Add(tarjeta);
                if (Persistente)
                {
                    List<Tarjeta> tarjetas = new List<Tarjeta>();
                    tarjetas.Add(tarjeta);
                    TarjetaRepositorio.agregar(tarjetas, cliente);
                }
                MessageBox.Show("Tarjeta creada con exito.","", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Hide();
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
