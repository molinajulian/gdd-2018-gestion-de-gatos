using MaterialSkin;
using MaterialSkin.Controls;
using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Palconet.AbmCliente
{
    public partial class ModificacionCliente : MaterialForm
    {
        String mail_original;
        Boolean hab_original;
        public ModificacionCliente(Int32 dni)
        {
            /*InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            Cliente cliente = ClientesRepositorio.getClientes(dni.ToString(), null, null).First();
            hab_original = cliente.habilitado;
            txNombre.Text = cliente.nombre;
            txApellido.Text = cliente.apellido;
            txDni.Text = cliente.dni.ToString();
            mail_original = txMail.Text = cliente.mail;
            txTelefono.Text = cliente.telefono;
            txLocalidad.Text = cliente.direccion.localidad;
            txCp.Text = cliente.direccion.cp.ToString();
            txNumero.Text = cliente.direccion.calle.Split(' ').Last();
            var auxiliar = cliente.direccion.calle.Split(' ').ToList();
            auxiliar.RemoveAt(auxiliar.Count-1);
            txCalle.Text = String.Join(" ",auxiliar);
            txPiso.Text = cliente.direccion.piso.ToString() == "0" ? "" : cliente.direccion.piso.ToString();
            txDpto.Text = cliente.direccion.dpto.ToString();
            dateTimePicker1.Value = cliente.fecha_nac;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validarCamposVaciosCliente()) { return; }
            if (txMail.Text != mail_original) 
            { 
                if (ClientesRepositorio.esClienteExistenteMail(txMail.Text))
                {
                    MessageBox.Show("Ya existe un cliente con el mail ingresado");
                    return;
                }
            }
            Cliente cliente = new Cliente();
            Direccion direccion = new Direccion();
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
            cliente.mail = txMail.Text;
            cliente.habilitado = hab_original;
            if (!Regex.IsMatch(txTelefono.Text, @"^[0-9]{1,20}$"))
            {
                MessageBox.Show("Ingrese un telefono válido.");
                return;
            }
            cliente.telefono = txTelefono.Text;
            cliente.fecha_nac = dateTimePicker1.Value.Date;
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
            if (!Regex.IsMatch(txCalle.Text, @"^[a-zA-Z0-9\s]{1,50}$"))
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

            ClientesRepositorio.modificarCliente(cliente);
            MessageBox.Show("Cliente modificado correctamente.");
            this.Hide();
            new ListadoCliente('M').Show();
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
                else if (string.IsNullOrWhiteSpace(control.Text))
                {
                    MessageBox.Show("Por favor complete todos los campos");
                    error = true;
                }
            }
            return error;
        }

        private void ModificacionCliente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }*/
    }
}
