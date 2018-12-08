using PalcoNet.Modelo;
using PalcoNet.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MaterialSkin.Controls;
using MaterialSkin;

namespace PalcoNet.AbmTarjeta
{
    public partial class AltaTarjeta : MaterialForm
    {
        Cliente cliente = new Cliente();
        Tarjeta tarjeta = new Tarjeta();

        public AltaTarjeta(ref Cliente c)
        {
            InitializeComponent();
            cliente = c;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

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
                /* if (control == txPiso || control == txDpto)
                {
                     
                }
                else if(string.IsNullOrWhiteSpace(control.Text))
                {
                    MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    error = true;
                    break;
                }*/ 
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    error = true;
                    break;
                }
            }
            return error;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (txtNumero.Text.Length > 16 || txtBanco.Text.Length == 0)
            {
                MessageBox.Show("Ingrese un numero de tarjeta válido y un banco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tarjeta.Banco = txtBanco.Text;
                tarjeta.FechaVencimiento = datePickerFechaVenc.Value;
                tarjeta.Numero = txtNumero.Text;
                cliente.Tarjeta.Add(tarjeta);
                MessageBox.Show("Tarjeta creada con exito.","", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Hide();
            }
        }

        private void txNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void AltaTarjeta_Load(object sender, EventArgs e)
        {
        
        }
    }
}
