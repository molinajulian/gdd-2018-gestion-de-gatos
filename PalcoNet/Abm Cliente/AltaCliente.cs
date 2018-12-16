using PalcoNet.Modelo;
using PalcoNet.Repositorios;
using PalcoNet.AbmTarjeta;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.AbmDomicilio;

namespace PalcoNet.AbmCliente
{
    public partial class AltaCliente : MaterialForm
    {
        Cliente cliente = new Cliente();
        Domicilio domicilio = new Domicilio();
        public AltaCliente()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            cliente.Tarjetas = new List<Tarjeta>();
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

        private void boton_alta_Click(object sender, EventArgs e)
        {
            if(!validarIngreso()) { return; }
            actualizarInstanciaCliente();
            try
            {
                domicilio.Id = DomiciliosRepositorio.agregar(domicilio);
                string clienteId = ClienteRepositorio.agregar(cliente);
                TarjetaRepositorio.agregar(cliente.Tarjetas, clienteId);
                limpiarVentana();
                MessageBox.Show("Cliente agregado correctamente con sus respectivas tarjetas y domicilio");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private void actualizarInstanciaCliente()
        {
            cliente.TipoDeDocumento = new TiposDocumento();
            cliente.TipoDeDocumento.Id = ((TiposDocumento)comboTiposDoc.SelectedItem).Id;
            cliente.NumeroDocumento = Convert.ToInt32(txDni.Text);
            cliente.nombre = txNombre.Text;
            cliente.Apellido = txApellido.Text;
            cliente.Email = txMail.Text;
            cliente.Telefono = txTelefono.Text;
            cliente.FechaDeNacimiento = datePickerFechaNac.Value.Date;
            cliente.Cuil = txtCuil.Text;
            cliente.Domicilio = domicilio;
            cliente.FechaDeCreacion = DateTime.Now;
            cliente.NombreCliente = txNombre.Text;
        }

        private void limpiarVentana()
        {
            var text_boxes = groupBox1.Controls.OfType<TextBox>();
            foreach(TextBox textbox in text_boxes)
            {
                textbox.Clear();
            }
        }

        private bool validarTipos()
        {
            if (!Regex.IsMatch(txDni.Text, @"^[0-9]{1,8}$"))
            {
                MessageBox.Show("Ingrese un DNI válido.");
                return false;
            }
            if (ClienteRepositorio.esClienteExistente(Int32.Parse(((TiposDocumento)comboTiposDoc.SelectedItem).Id), Decimal.Parse(txDni.Text)))
            {
                MessageBox.Show("Ya existe un cliente con el dni ingresado");
                return false;
            }
            if (!Regex.IsMatch(txNombre.Text, @"^[a-zA-Z\s]{1,30}$"))
            {
                MessageBox.Show("Ingrese un nombre válido.");
                return false;
            }
            if (!Regex.IsMatch(txApellido.Text, @"^[a-zA-Z\s]{1,30}$"))
            {
                MessageBox.Show("Ingrese un apellido válido.");
                return false;
            }
            if (!Regex.IsMatch(txMail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Ingrese un mail válido.");
                return false;
            }
            if (!Regex.IsMatch(txMail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Ingrese un mail válido.");
                return false;
            }
            if (!Regex.IsMatch(txTelefono.Text, @"^[0-9]{1,20}$"))
            {
                MessageBox.Show("Ingrese un telefono válido.");
                return false;
            }
            if (!Regex.IsMatch(txtCuil.Text, @"[0-9]{2}-[0-9]{5,9}-[0-9]{1,2}$"))
            {
                MessageBox.Show("Ingrese un cuil valido.");
                return false;
            }
            if (ClienteRepositorio.esClienteExistente(0, 0, txtCuil.Text))
            {
                MessageBox.Show("Ya existe un cliente con ese CUIL.");
                return false;
            }
            if (cliente.Tarjetas.Count == 0)
            {
                MessageBox.Show("Debe registrar al menos una tarjeta para la plataforma.");
                return false;
            }
            return true;
        }

        private bool validarIngreso()
        {
            return validarFormularioCompleto() && validarTipos();
        }

        private bool validarFormularioCompleto()
        {
            bool completo = true;
            var controles = groupBox1.Controls;
            foreach (Control control in controles)
            {
                
                if(string.IsNullOrWhiteSpace(control.Text))
                {
                    MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    completo = false;
                    break;
                }
            }
            return completo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaTarjeta t = new AltaTarjeta(ref cliente);
            t.ShowDialog();
        }

        private void btnRegistrarDomicilio_Click(object sender, EventArgs e)
        {
            AltaDomicilio altaDomicilio = new AltaDomicilio(domicilio);
            altaDomicilio.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
