using MaterialSkin;
using MaterialSkin.Controls;
using PalcoNet.Modelo;
using PalcoNet.Repositorios;
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
using PalcoNet.Repositorios;

namespace PalcoNet.Historial_Cliente
{
    public partial class HistorialCliente : MaterialForm
    {
        int offsetDefault = 20;
        int paginaActual;
        int cantidadDePaginas;
        DataTable tabla_historial = new DataTable();
        Cliente cli;
        Usuario usuario;
        public HistorialCliente(Usuario usuario)
        {
            
            InitializeComponent();
            this.usuario = usuario;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            initColumns();
            if (usuario.rol.nombre == "CLIENTE")
            {
                ocultarOpcionesAdmin();
                cli = ClienteRepositorio.getCliente(usuario);
                txtLimit.Text = offsetDefault.ToString();
                int cantidad = CompraRepositorio.GetCantidadHistorial(Convert.ToInt32(cli.TipoDeDocumento.Id), cli.NumeroDocumento);
                cantidadDePaginas = Convert.ToInt32(Math.Ceiling((double)cantidad / offsetDefault));
                paginaActual = 0;
                buttonBack.Hide();
                generarTextLabel();
                List<CompraListado> historial = CompraRepositorio.GetHistorialCompra(Convert.ToInt32(cli.TipoDeDocumento.Id), cli.NumeroDocumento, paginaActual * offsetDefault);
                generarRows(historial);
            }
            else
            {
                getTiposDocumento();
                buttonBack.Hide();
                buttonNext.Hide();
                labelAclaracion.Hide();
                txtLimit.Hide();
            }
        }
        public void getTiposDocumento()
        {
            List<TipoDocumento> tipos = new List<TipoDocumento>();
            comboTiposDoc.Items.Clear();
            tipos = ClienteRepositorio.getTiposDoc();
            foreach (TipoDocumento tipo in tipos)
            {
                comboTiposDoc.Items.Add(tipo);
                comboTiposDoc.DisplayMember = "Descripcion";
            }
        }
        private void ocultarOpcionesAdmin()
        {
            labelDoc.Hide();
            labelTipoDoc.Hide();
            txtDoc.Hide();
            comboTiposDoc.Hide();
            buttonBuscar.Hide();
        }
        private void generarTextLabel()
        {
            labelAclaracion.Text = "Página " + (paginaActual + 1) + " de " + cantidadDePaginas.ToString();
        }
        private void initColumns()
        {
            tabla_historial.Columns.Add("Total comprado", typeof(string));
            tabla_historial.Columns.Add("Fecha de compra", typeof(string));
            tabla_historial.Columns.Add("Descripción del espectáculo", typeof(string));
            tabla_historial.Columns.Add("Fecha de espectáculo", typeof(string));
            tabla_historial.Columns.Add("Tipo de espectáculo", typeof(string));
            actualizarTabla();
        }
        public void actualizarTabla()
        {
            data_historial.DataSource = tabla_historial;
        }
        private void limpiarHistorial()
        {
            tabla_historial.Rows.Clear();
            data_historial.ClearSelection();
            actualizarTabla();
        }
        private void generarRows(List<CompraListado> historial)
        {
            foreach (CompraListado c in historial)
            {
                string[] row = { c.Total.ToString(), c.FechaCompra.ToString("yyyy-MM-dd"), c.EspectaculoDescripción, c.FechaEspectaculo.ToString("yyyy-MM-dd"), c.RubroDescripción };
                tabla_historial.Rows.Add(row);
            }
            actualizarTabla();
        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            limpiarHistorial();
            paginaActual += 1;
            if (paginaActual == cantidadDePaginas-1) buttonNext.Hide();
            List<CompraListado> historial = CompraRepositorio.GetHistorialCompra(Convert.ToInt32(cli.TipoDeDocumento.Id), cli.NumeroDocumento, paginaActual * offsetDefault);
            generarRows(historial);
            actualizarTabla();
            if (!buttonBack.Visible)    buttonBack.Show();
            generarTextLabel();

        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            limpiarHistorial();
            paginaActual -= 1;
            if (paginaActual == -1 || paginaActual == 0) 
            { 
                paginaActual = 0;
                buttonBack.Hide();
            }
            List<CompraListado> historial = CompraRepositorio.GetHistorialCompra(Convert.ToInt32(cli.TipoDeDocumento.Id), cli.NumeroDocumento, paginaActual * offsetDefault);
            generarRows(historial);
            actualizarTabla();
            buttonNext.Show();
            generarTextLabel();
        }

        private void txtDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            TipoDocumento TipoDeDocumento = ((TipoDocumento)comboTiposDoc.SelectedItem);
            if (TipoDeDocumento == null || string.IsNullOrEmpty(txtDoc.Text))
            {
                MessageBox.Show("Elija un tipo de documento y complete el documento.", "Error al buscar el cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    cli = ClienteRepositorio.getCliente(usuario, Convert.ToInt32(TipoDeDocumento.Id), Convert.ToInt32(txtDoc.Text));
                    txtLimit.Text = offsetDefault.ToString();
                    int cantidad = CompraRepositorio.GetCantidadHistorial(Convert.ToInt32(cli.TipoDeDocumento.Id), cli.NumeroDocumento);
                    cantidadDePaginas = Convert.ToInt32(Math.Ceiling((double)cantidad / offsetDefault));
                    paginaActual = 0;
                    buttonBack.Hide();
                    generarTextLabel();
                    List<CompraListado> historial = CompraRepositorio.GetHistorialCompra(Convert.ToInt32(cli.TipoDeDocumento.Id), cli.NumeroDocumento, paginaActual * offsetDefault);
                    generarRows(historial);
                    buttonBack.Show();
                    buttonNext.Show();
                    labelAclaracion.Show();
                    txtLimit.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al buscar el cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
