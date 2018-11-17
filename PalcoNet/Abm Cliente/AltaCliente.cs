using PagoAgilFrba.Modelo;
using PagoAgilFrba.Repositorios;
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
using PalcoNet.Modelo;

namespace PagoAgilFrba.AbmCliente
{
    public partial class AltaCliente : MaterialForm
    {
        Cliente cliente = new Cliente();
        Direccion direccion = new Direccion();
        public AltaCliente()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void boton_alta_Click(object sender, EventArgs e)
        {
            //epProvider.Clear();
            if(validarCamposVaciosCliente()) { return; }

            cliente.habilitado = true;
            if (!Regex.IsMatch(txDni.Text, @"^[0-9]{1,8}$"))
            {
                MessageBox.Show("Ingrese un DNI válido.");
                return;
            }
            if (ClientesRepositorio.esClienteExistente(Convert.ToInt32(txDni.Text)))
            {
                MessageBox.Show("Ya existe un cliente con el dni ingresado");
                return;
            }
            cliente.dni = Convert.ToInt32(txDni.Text);
            if (!Regex.IsMatch(txNombre.Text, @"^[a-zA-Z\s]{1,30}$"))
            {
                MessageBox.Show("Ingrese un nombre válido.");
                return;
            }
            cliente.nombre = txNombre.Text;
            if (!Regex.IsMatch(txApellido.Text, @"^[a-zA-Z\s]{1,30}$"))
            {
                MessageBox.Show("Ingrese un apellido válido.");
                return;
            }
            cliente.apellido = txApellido.Text;
            if (!Regex.IsMatch(txMail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Ingrese un mail válido.");
                return;
            }
            else if (ClientesRepositorio.esClienteExistenteMail(txMail.Text))
            {
                MessageBox.Show("Ya existe un cliente con el mail ingresado");
                return;
            }
            cliente.mail = txMail.Text;
            if (!Regex.IsMatch(txTelefono.Text, @"^[0-9]{1,20}$"))
            {
                MessageBox.Show("Ingrese un telefono válido.");
                return;
            }
            cliente.telefono = txTelefono.Text;
            cliente.fecha_nac = datePickerFechaNac.Value.Date;
            if (!Regex.IsMatch(txLocalidad.Text, @"^[a-zA-Z0-9\s]{1,20}$"))
            {
                MessageBox.Show("Ingrese una localidad válida.");
                return;
            }
            direccion.localidad = txLocalidad.Text;
            if (!Regex.IsMatch(txCp.Text, @"^[0-9]{1,4}$"))
            {
                MessageBox.Show("Ingrese un código postal válido.");
                return;
            }
            direccion.cp = Convert.ToInt16(txCp.Text);
            if (!Regex.IsMatch(txPiso.Text, @"^[0-9]{1,3}$") && !string.IsNullOrEmpty(txPiso.Text))
            {
                MessageBox.Show("Ingrese un piso válido.");
                return;
            }
            direccion.piso = string.IsNullOrWhiteSpace(txPiso.Text) ? short.MaxValue : Convert.ToInt16(txPiso.Text);
            if (!Regex.IsMatch(txDpto.Text, @"^[a-zA-Z]$") && !string.IsNullOrEmpty(txDpto.Text))
            {
                MessageBox.Show("Ingrese un departamento válido.");
                return;
            }
            direccion.dpto = string.IsNullOrWhiteSpace(txDpto.Text) ? ' ' : txDpto.Text.First();
            if (!Regex.IsMatch(txCalle.Text, @"[a-zA-Z0-9\s]{1,50}$"))
            {
                MessageBox.Show("Ingrese una calle válida.");
                return;
            }
            if (!Regex.IsMatch(txNumero.Text, @"^[0-9]{1,6}$"))
            {
                MessageBox.Show("Ingrese un número válido.");
                return;
            }
            direccion.calle = txCalle.Text + " " + txNumero.Text;
            cliente.direccion = direccion;


            ClientesRepositorio.agregar(cliente);
            limpiarVentana();
            MessageBox.Show("Cliente agregado correctamente");

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
                if (control == txPiso || control == txDpto)
                {
                     
                }
                else if(string.IsNullOrWhiteSpace(control.Text))
                {
                    MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    error = true;
                    break;
                }
            }
            return error;
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
