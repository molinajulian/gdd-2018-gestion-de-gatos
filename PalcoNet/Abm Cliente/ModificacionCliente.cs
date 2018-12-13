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
        String mail_original;
        Boolean hab_original;
        bool cuilNulo = false, deptoNulo = false, pisoNulo = false, telNulo = false, localidadNulo = false;
        Cliente cliente;
        public ModificacionCliente(int doc,string descripcionDoc)
        {
            try
            {
                InitializeComponent();
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                getTiposDocumento();
                cliente = ClienteRepositorio.getCliente(doc, descripcionDoc);
                if (cliente.Habilitado) checkHabilitado.Checked = true;
                txtNombre.Text = cliente.NombreCliente;
                txtApellido.Text = cliente.Apellido;
                txtNumDoc.Text = cliente.NumeroDocumento.ToString();
                // txtNumDoc.Enabled = false;
                txtMail.Text = cliente.Email;
                if (cliente.Telefono == "0")
                {   txtTel.Text = "";telNulo = true;}
                else { txtTel.Text = cliente.Telefono; }
                datePickerFechaNac.Value = cliente.FechaDeNacimiento;
                comboTiposDoc.SelectedIndex = comboTiposDoc.FindString(cliente.TipoDeDocumento.Descripcion);
                // comboTiposDoc.Enabled = false;
                //Validaciones debido a la migracion
                if (string.IsNullOrEmpty(cliente.Cuil)) cuilNulo = true;
                if (string.IsNullOrEmpty(cliente.Domicilio.Departamento)) deptoNulo = true;
                if (string.IsNullOrEmpty(cliente.Domicilio.Piso)) pisoNulo = true;
                if (string.IsNullOrEmpty(cliente.Telefono)) telNulo = true;
                if (string.IsNullOrEmpty(cliente.Domicilio.Localidad)) localidadNulo = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un error al obtener los datos del cliente",e.Message);
                this.Show();
            }
        }
        private void verificarCamposNulos(Cliente cli)
        {

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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModificarDomicilio modificarDomicilio = new ModificarDomicilio(cliente.Domicilio);
            modificarDomicilio.ShowDialog();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            TiposDocumento seleccionado = (TiposDocumento)comboTiposDoc.SelectedItem;
            Cliente clienteModificado = new Cliente();
            clienteModificado.TipoDeDocumento = new TiposDocumento();
            clienteModificado.TipoDeDocumento.Id = seleccionado.Id;
            if (!Regex.IsMatch(txtNumDoc.Text, @"^[0-9]{1,8}$"))
            {
                MessageBox.Show("Ingrese un DNI válido.");
                return;
            }
            if ((cliente.NumeroDocumento != Int32.Parse(txtNumDoc.Text) || cliente.TipoDeDocumento.Descripcion != seleccionado.Descripcion) && ClienteRepositorio.esClienteExistente(Int32.Parse(seleccionado.Id), Decimal.Parse(txtNumDoc.Text)))
            {
                MessageBox.Show("Ya existe un cliente con el dni ingresado");
                return;
            }
            clienteModificado.NumeroDocumento = Convert.ToInt32(txtNumDoc.Text);
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-Z\s]{1,30}$"))
            {
                MessageBox.Show("Ingrese un nombre válido.");
                return;
            }
            clienteModificado.nombre = txtNombre.Text;
            if (!Regex.IsMatch(txtApellido.Text, @"^[a-zA-Z\sáéíóú]{1,30}$"))
            {
                MessageBox.Show("Ingrese un apellido válido.");
                return;
            }
            clienteModificado.Apellido = txtApellido.Text;
            if (!Regex.IsMatch(txtMail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Ingrese un mail válido.");
                return;
            }
            clienteModificado.Email = txtMail.Text;
            if (!telNulo && !Regex.IsMatch(txtTel.Text, @"^[0-9]{1,20}$"))
            {
                MessageBox.Show("Ingrese un telefono válido.");
                return;
            }
            clienteModificado.Telefono = string.IsNullOrEmpty(txtTel.Text) ? "0" : txtTel.Text;
            clienteModificado.FechaDeNacimiento = datePickerFechaNac.Value.Date;
            if (!cuilNulo && !Regex.IsMatch(txtCuil.Text, @"[0-9]{2}-[0-9]{5,9}-[0-9]{1,2}$"))
            {
                MessageBox.Show("Ingrese un cuit valido.");
                return;
            }
            else
            {
                if (cliente.Cuil != txtCuil.Text && ClienteRepositorio.esClienteExistente(0, 0, txtCuil.Text))
                {
                    MessageBox.Show("Ya existe un cliente con ese CUIL.");
                    return;
                }
            }
            clienteModificado.Cuil = string.IsNullOrEmpty(txtCuil.Text) ? "" : txtCuil.Text; 
            clienteModificado.FechaDeCreacion = DateTime.Now;
            clienteModificado.NombreCliente = txtNombre.Text;
            clienteModificado.Habilitado = checkHabilitado.Checked;
            try
            {
                ClienteRepositorio.modificarCliente(clienteModificado);
                MessageBox.Show("Cliente modificado correctamente.");
                this.Hide();
                // new ListadoCliente('M').Show();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ha ocurrido un error al modificar el cliente", ex.Message);
            }
        }

        private bool validarCamposVaciosCliente()
        {
            bool error = false;
            var controles = groupBoxModifCli.Controls;
            foreach (Control control in controles)
            {
                if (string.IsNullOrWhiteSpace(control.Text))
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
    }
}
