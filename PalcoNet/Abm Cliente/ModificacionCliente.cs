using MaterialSkin;
using MaterialSkin.Controls;
using PalcoNet.Modelo;
using PalcoNet.Repositorios;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.SqlClient;
using PalcoNet.AbmDomicilio;

namespace PalcoNet.AbmCliente
{
    public partial class ModificacionCliente : MaterialForm
    {
        private Cliente cliente;
        public ModificacionCliente(Cliente cliente)
        {
            try
            {
                InitializeComponent();
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                getTiposDocumento();
                this.cliente = cliente;
                llenarCamposUi();
            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un error al obtener los datos del cliente",e.Message);
                this.Show();
            }
        }

        private void llenarCamposUi()
        {
            checkHabilitado.Checked = cliente.Habilitado;
            txtNombre.Text = cliente.NombreCliente;
            txtApellido.Text = cliente.Apellido;
            txtNumDoc.Text = cliente.NumeroDocumento.ToString();
            txtMail.Text = cliente.Email;
            txtTel.Text = cliente.Telefono; 
            datePickerFechaNac.Value = cliente.FechaDeNacimiento;
            comboTiposDoc.SelectedIndex = comboTiposDoc.FindString(cliente.TipoDeDocumento.Descripcion);
        }

        private void getTiposDocumento()
        {
            List<TiposDocumento> tipos = new List<TiposDocumento>();
            comboTiposDoc.Items.Clear();
            tipos = ClienteRepositorio.getTiposDoc();
            foreach (TiposDocumento tipo in tipos)
            {
                comboTiposDoc.Items.Add(tipo);
                comboTiposDoc.DisplayMember = "Descripcion";
                comboTiposDoc.ValueMember = "Id";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModificarDomicilio modificarDomicilio = new ModificarDomicilio(cliente.Domicilio);
            modificarDomicilio.ShowDialog();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (!validarCamposCliente()) { return; }
            try
            {
                ClienteRepositorio.modificarCliente(getClienteDeUi());
                MessageBox.Show("Cliente modificado correctamente.");
                this.Hide();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error al modificar el cliente", ex.Message);
            }
        }

        private Cliente getClienteDeUi()
        {
            Cliente clienteModificado = new Cliente();
            TiposDocumento seleccionado = (TiposDocumento)comboTiposDoc.SelectedItem;
            clienteModificado.TipoDeDocumento = new TiposDocumento();
            clienteModificado.TipoDeDocumento.Id = seleccionado.Id;
            clienteModificado.NumeroDocumento = Convert.ToInt32(txtNumDoc.Text);
            clienteModificado.nombre = txtNombre.Text;
            clienteModificado.Apellido = txtApellido.Text;
            clienteModificado.Email = txtMail.Text;
            clienteModificado.Telefono = string.IsNullOrEmpty(txtTel.Text) ? "0" : txtTel.Text;
            clienteModificado.FechaDeNacimiento = datePickerFechaNac.Value.Date;
            clienteModificado.Cuil = string.IsNullOrEmpty(txtCuil.Text) ? "" : txtCuil.Text;
            clienteModificado.FechaDeCreacion = DateTime.Now;
            clienteModificado.NombreCliente = txtNombre.Text;
            clienteModificado.Habilitado = checkHabilitado.Checked;
            return clienteModificado;
        }

        private bool validarCamposCliente()
        {
            if (!Regex.IsMatch(txtNumDoc.Text, @"^[0-9]{1,8}$"))
            {
                MessageBox.Show("Ingrese un DNI válido.");
                return false;
            }
            if ((cliente.NumeroDocumento != Int32.Parse(txtNumDoc.Text) || 
                 cliente.TipoDeDocumento.Descripcion != ((TiposDocumento)comboTiposDoc.SelectedItem).Descripcion)
                && ClienteRepositorio.esClienteExistente(Int32.Parse(((TiposDocumento)comboTiposDoc.SelectedItem).Id), Decimal.Parse(txtNumDoc.Text)))
            {
                MessageBox.Show("Ya existe un cliente con el dni ingresado");
                return false;
            }
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z\s]{1,30}$"))
            {
                MessageBox.Show("Ingrese un nombre válido.");
                return false;
            }
            if (!Regex.IsMatch(txtApellido.Text, @"^[a-zA-Z\sáéíóú]{1,30}$"))
            {
                MessageBox.Show("Ingrese un apellido válido.");
                return false;
            }
            if (!Regex.IsMatch(txtMail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Ingrese un mail válido.");
                return false;
            }
            if (!txtTel.Text.Equals("") && !Regex.IsMatch(txtTel.Text, @"^[0-9]{1,20}$"))
            {
                MessageBox.Show("Ingrese un telefono válido.");
                return false;
            }
            if (!txtCuil.Text.Equals("") && !Regex.IsMatch(txtCuil.Text, @"[0-9]{2}-[0-9]{5,9}-[0-9]{1,2}$"))
            {
                MessageBox.Show("Ingrese un cuil valido.");
                return false;
            }
            if (cliente.Cuil != txtCuil.Text && ClienteRepositorio.esClienteExistente(0, 0, txtCuil.Text))
            {
                MessageBox.Show("Ya existe un cliente con ese CUIL.");
                return false;
            }
            return true;
        }
    }
}
