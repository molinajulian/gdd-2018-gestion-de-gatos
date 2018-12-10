using MaterialSkin;
using MaterialSkin.Controls;
using PalcoNet.Modelo;
using PalcoNet.Repositorios;
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

namespace PalcoNet.AbmCliente
{
    public partial class ModificacionCliente : MaterialForm
    {
        String mail_original;
        Boolean hab_original;
        public ModificacionCliente(Int32 dni)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            Cliente cliente = ClienteRepositorio.getClientes(dni.ToString(), null, null).First();
            hab_original = cliente.Habilitado;
            txtNombre.Text = cliente.nombre;
            txtApellido.Text = cliente.Apellido;
            txtNumDoc.Text = cliente.NumeroDocumento.ToString();
            mail_original = txtMail.Text = cliente.Email;
            txtTel.Text = cliente.Telefono;
            txtLoc.Text = cliente.Direccion.Localidad;
            txtCp.Text = cliente.Direccion.CodPostal.ToString();
            txtNum.Text = cliente.Direccion.Calle.Split(' ').Last();
            var auxiliar = cliente.Direccion.Calle.Split(' ').ToList();
            auxiliar.RemoveAt(auxiliar.Count-1);
            txtCalle.Text = String.Join(" ",auxiliar);
            txtPiso.Text = cliente.Direccion.Piso.ToString() == "0" ? "" : cliente.Direccion.Piso.ToString();
            txtPiso.Text = cliente.Direccion.Departamento.ToString();
            datePickerFechaNac.Value = cliente.FechaDeNacimiento;
        }

        public ModificacionCliente()
        {
            // TODO: Complete member initialization
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validarCamposVaciosCliente()) { return; }
            if (txtMail.Text != mail_original) 
            {
                if (ClienteRepositorio.esClienteExistenteMail(txtMail.Text))
                {
                    MessageBox.Show("Ya existe un cliente con el mail ingresado");
                    return;
                }
            }
            Cliente cliente = new Cliente();
            Direccion direccion = new Direccion();
            cliente.NumeroDocumento =Convert.ToInt32(txtNumDoc.Text);
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z\s]{1,30}$"))
            {
                MessageBox.Show("Ingrese un nombre válido.");
                return;
            }
            cliente.nombre = txtNombre.Text;
            if (!Regex.IsMatch(txtApellido.Text, @"^[a-zA-Z\s]{1,30}$"))
            {
                MessageBox.Show("Ingrese un apellido válido.");
                return;
            }
            cliente.Apellido = txtApellido.Text;
            if (!Regex.IsMatch(txtMail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Ingrese un mail válido.");
                return;
            }
            cliente.Email = txtMail.Text;
            cliente.Habilitado = hab_original;
            if (!Regex.IsMatch(txtTel.Text, @"^[0-9]{1,20}$"))
            {
                MessageBox.Show("Ingrese un telefono válido.");
                return;
            }
            cliente.Telefono = txtTel.Text;
            cliente.FechaDeNacimiento = datePickerFechaNac.Value.Date;
            if (!Regex.IsMatch(txtLoc.Text, @"^[a-zA-Z0-9\s]{1,20}$"))
            {
                MessageBox.Show("Ingrese una localidad válida.");
                return;
            }
            direccion.Localidad = txtLoc.Text;
            if (!Regex.IsMatch(txtCp.Text, @"^[0-9]{1,4}$"))
            {
                MessageBox.Show("Ingrese un código postal válido.");
                return;
            }
            direccion.CodPostal = txtCp.Text;
            if (!Regex.IsMatch(txtPiso.Text, @"^[0-9]{1,3}$") && !string.IsNullOrEmpty(txtPiso.Text))
            {
                MessageBox.Show("Ingrese un piso válido.");
                return;
            }
            direccion.Piso = string.IsNullOrWhiteSpace(txtPiso.Text) ? null : txtPiso.Text;
            if (!Regex.IsMatch(txtDepto.Text, @"^[a-zA-Z]$") && !string.IsNullOrEmpty(txtDepto.Text))
            {
                MessageBox.Show("Ingrese un departamento válido.");
                return;
            }
            direccion.Departamento = string.IsNullOrWhiteSpace(txtDepto.Text) ? ' '.ToString() : txtDepto.Text;
            if (!Regex.IsMatch(txtCalle.Text, @"^[a-zA-Z0-9\s]{1,50}$"))
            {
                MessageBox.Show("Ingrese una calle válida.");
                return;
            }
            if (!Regex.IsMatch(txtNum.Text, @"^[0-9]{1,6}$"))
            {
                MessageBox.Show("Ingrese un número válido.");
                return;
            }
            direccion.Calle = txtCalle.Text + " " + txtNum.Text;
            cliente.Direccion = direccion;

            ClienteRepositorio.modificarCliente(cliente);
            MessageBox.Show("Cliente modificado correctamente.");
            this.Hide();
            new ListadoCliente('M').Show();
        }

        private bool validarCamposVaciosCliente()
        {
            bool error = false;
            var controles = groupBoxModifCli.Controls;
            foreach (Control control in controles)
            {
                if (control == txtPiso || control == txtDepto)
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
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
