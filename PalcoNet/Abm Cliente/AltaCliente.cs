using PalcoNet.Modelo;
using PalcoNet.Repositorios;
using PalcoNet.AbmTarjeta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MaterialSkin.Controls;
using MaterialSkin;

namespace PalcoNet.AbmCliente
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
            cliente.Tarjeta = new List<Tarjeta>();
            getTiposDocumento();
        }

        public void getTiposDocumento()
        {
            List<TiposDocumento> tipos = new List<TiposDocumento>();
            comboTiposDoc.Items.Clear();
            tipos = ClienteRepositorio.getTiposDoc();
            foreach (TiposDocumento tipo in tipos)
            {
                comboTiposDoc.Items.Add(tipo);
                comboTiposDoc.DisplayMember = "Descripcion";
            }
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

        private void boton_alta_Click(object sender, EventArgs e)
        {
           //  cliente.Habilitado = true;
            TiposDocumento seleccionado = (TiposDocumento)comboTiposDoc.SelectedItem;
            cliente.TipoDeDocumento = new TiposDocumento();
            cliente.TipoDeDocumento.Id = seleccionado.Id;
            if (!Regex.IsMatch(txDni.Text, @"^[0-9]{1,8}$"))
            {
                MessageBox.Show("Ingrese un DNI válido.");
                return;
            }
            if (ClienteRepositorio.esClienteExistente(Int32.Parse(seleccionado.Id),Decimal.Parse(txDni.Text)))
            {
                MessageBox.Show("Ya existe un cliente con el dni ingresado");
                return;
            }
            cliente.NumeroDocumento = Convert.ToInt32(txDni.Text);
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
            cliente.Apellido = txApellido.Text;
            if (!Regex.IsMatch(txMail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Ingrese un mail válido.");
                return;
            }
            if (!Regex.IsMatch(txMail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Ingrese un mail válido.");
                return;
            }
            cliente.Email = txMail.Text;
            if (!Regex.IsMatch(txTelefono.Text, @"^[0-9]{1,20}$"))
            {
                MessageBox.Show("Ingrese un telefono válido.");
                return;
            }
            cliente.Telefono = txTelefono.Text;
            cliente.FechaDeNacimiento = datePickerFechaNac.Value.Date;
            if (!Regex.IsMatch(txtCuil.Text, @"[0-9]{2}-[0-9]{5,9}-[0-9]{1,2}$"))
            {
                MessageBox.Show("Ingrese un cuit valido.");
                return;
            }
            else
            {
                if (ClienteRepositorio.esClienteExistente(0, 0, txtCuil.Text)) 
                {
                    MessageBox.Show("Ya existe un cliente con ese CUIL.");
                    return;
                }
            }
            cliente.Cuil = txtCuil.Text;
            if (!Regex.IsMatch(txLocalidad.Text, @"^[a-zA-Z0-9\s]{1,20}$"))
            {
                MessageBox.Show("Ingrese una localidad válida.");
                return;
            }
            direccion.Localidad = txLocalidad.Text;
            if (!Regex.IsMatch(txCp.Text, @"^[0-9]{1,4}$"))
            {
                MessageBox.Show("Ingrese un código postal válido.");
                return;
            }
            direccion.CodPostal = txCp.Text;
            if (!Regex.IsMatch(txPiso.Text, @"^[0-9]{1,3}$") && !string.IsNullOrEmpty(txPiso.Text))
            {
                MessageBox.Show("Ingrese un piso válido.");
                return;
            }
            direccion.Piso = string.IsNullOrWhiteSpace(txPiso.Text) ? ' '.ToString() : txPiso.Text;
            if (!Regex.IsMatch(txtDepto.Text, @"^[a-zA-Z]$") && !string.IsNullOrEmpty(txtDepto.Text))
            {
                MessageBox.Show("Ingrese un departamento válido.");
                return;
            }
            direccion.Departamento = string.IsNullOrWhiteSpace(txtDepto.Text) ? ' '.ToString() : txtDepto.Text;
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
            direccion.Calle = txCalle.Text;
            direccion.Numero = txNumero.Text;
            cliente.Direccion = direccion;
            if (cliente.Tarjeta.Count == 0)
            {
                MessageBox.Show("Debe registrar al menos una tarjeta para la plataforma.");
                return;
            }
            cliente.FechaDeCreacion = DateTime.Now;
            cliente.NombreCliente = txNombre.Text;
            try
            {
                string clienteId = ClienteRepositorio.agregar(cliente);
                TarjetaRepositorio.agregar(cliente,clienteId);
                limpiarVentana();
                MessageBox.Show("Cliente agregado correctamente con sus respectivas tarjetas");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
            

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
                if (control == txPiso || control == txtDepto)
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

        private void button1_Click(object sender, EventArgs e)
        {
            AltaTarjeta t = new AltaTarjeta(ref cliente);
            t.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void txNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboTiposDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
