using PalcoNet.Modelo;
using System;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;

namespace PalcoNet.AbmTarjeta
{
    public partial class AltaTarjeta : MaterialForm
    {
        Cliente cliente;

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
                cliente.Tarjeta.Add(new Tarjeta(txtNumero.Text, txtBanco.Text, datePickerFechaVenc.Value));
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
