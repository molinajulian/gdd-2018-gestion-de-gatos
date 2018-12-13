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
    public partial class ListadoCliente : MaterialForm
    {
        DataTable tabla_clientes = new DataTable();
        public ListadoCliente(Char modo)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            initColumns();
            getClientes();
            if (modo == 'B')
                btn_modificar.Hide();
            else
                switch_habilitacion.Hide();
        }
        private void getClientes()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                clientes = ClienteRepositorio.getClientes();
                foreach (Cliente c in clientes)
                {
                    string[] row = new string[] { c.TipoDeDocumento.Descripcion.ToString(), c.NumeroDocumento.ToString(), c.Cuil, c.NombreCliente, c.Apellido, c.Email, c.Domicilio.Calle, c.Domicilio.Numero, c.Domicilio.Localidad, c.Domicilio.CodPostal, c.Habilitado == true ? "Si" : "No" };
                    tabla_clientes.Rows.Add(row);
                }
                data_clientes.DataSource = tabla_clientes;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ocurrio un error al obtener la información de los clientes");
                this.Show();
            }
        }
        private void initColumns()
        {
            tabla_clientes.Columns.Add("Tipo doc", typeof(string));
            tabla_clientes.Columns.Add("Documento", typeof(string));
            tabla_clientes.Columns.Add("Cuil", typeof(string));
            tabla_clientes.Columns.Add("Nombre", typeof(string));
            tabla_clientes.Columns.Add("Apellido", typeof(string));
            tabla_clientes.Columns.Add("Email", typeof(string));
            tabla_clientes.Columns.Add("Calle", typeof(string));
            tabla_clientes.Columns.Add("Numero", typeof(string));
            tabla_clientes.Columns.Add("Localidad", typeof(string));
            tabla_clientes.Columns.Add("Codigo postal", typeof(string));
            tabla_clientes.Columns.Add("Habilitado", typeof(string));
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tx_dni.Text) && !Regex.IsMatch(tx_dni.Text, @"^[0-9]{1,8}$"))
            {
                MessageBox.Show("Ingrese un DNI válido.");
                return;
            }
            if (!string.IsNullOrEmpty(tx_nombre.Text) && !Regex.IsMatch(tx_nombre.Text, @"^[a-zA-Z\s]{1,30}$"))
            {
                MessageBox.Show("Ingrese un nombre válido.");
                return;
            }
            if (!string.IsNullOrEmpty(tx_apellido.Text) && !Regex.IsMatch(tx_apellido.Text, @"^[a-zA-Z\s]{1,30}$"))
            {
                MessageBox.Show("Ingrese un apellido válido.");
                return;
            }
            if (!string.IsNullOrEmpty(txEmail.Text) && !Regex.IsMatch(txEmail.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Ingrese un mail válido.");
                return;
            }
            tabla_clientes.Clear();
            List<Cliente> clientes = ClienteRepositorio.getClientes(tx_dni.Text, tx_nombre.Text, tx_apellido.Text,txEmail.Text);
            foreach (Cliente c in clientes)
            {
                string[] row = new string[] { c.TipoDeDocumento.Descripcion.ToString(), c.NumeroDocumento.ToString(), c.Cuil, c.NombreCliente, c.Apellido, c.Email, c.Domicilio.Calle, c.Domicilio.Numero, c.Domicilio.Localidad, c.Domicilio.CodPostal, c.Habilitado == true ? "Si" : "No" };
                tabla_clientes.Rows.Add(row);
            }
            data_clientes.DataSource = tabla_clientes;
            // refreshValues();

        }
        public void refreshValues()
        {
            tabla_clientes.Rows.Clear();
            data_clientes.DataSource = tabla_clientes;
        }


        private void grupo_filtros_Enter(object sender, EventArgs e)
        {

        }

        private void data_clientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (data_clientes.SelectedRows.Count != 0)
            //{
            //    DataGridViewRow row = this.data_clientes.SelectedRows[0];
            //    if (row.Cells["Habilitado"].Value.ToString() == "No")
            //    {
            //        switch_habilitacion.Text="Habilitar";
            //    }
            //    else
            //    {
            //        switch_habilitacion.Text="Inhabilitar";
            //    }
            //}
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            tabla_clientes.Rows.Clear();
            refreshValues();
        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (this.data_clientes.RowCount > 0)
            {
                int doc = Convert.ToInt32(this.data_clientes.SelectedRows[0].Cells["Documento"].Value.ToString());
                string descripcionTipoDoc = this.data_clientes.SelectedRows[0].Cells["Tipo doc"].Value.ToString();
                this.Hide();
                new ModificacionCliente(doc,descripcionTipoDoc).Show();
            }
            else
            {
                MessageBox.Show("Busque y seleccione un cliente antes.");
            }
        }

        private void switch_habilitacion_Click(object sender, EventArgs e)
        {
            if (this.data_clientes.RowCount > 0)
            {
                if (this.data_clientes.SelectedRows[0].Cells["Habilitado"].Value.ToString() == "Si")
                {
          
                    ClienteRepositorio.eliminarCliente(this.data_clientes.SelectedRows[0].Cells["Tipo doc"].Value.ToString(), this.data_clientes.SelectedRows[0].Cells["Documento"].Value.ToString());
                }
                else
                {
                    ClienteRepositorio.habilitarCliente(Convert.ToInt32(this.data_clientes.SelectedRows[0].Cells["DNI"].Value.ToString()));
                }
                refreshValues();
                getClientes();
            }
            else
            {
                MessageBox.Show("Busque y seleccione un cliente antes.");
            }
        }

        private void data_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListadoCliente_Load(object sender, EventArgs e)
        {

        }

        private void tx_nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        

    }
}
