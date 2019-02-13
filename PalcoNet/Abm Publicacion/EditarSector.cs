using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PalcoNet.Modelo;
using MaterialSkin.Controls;
using MaterialSkin;
using PalcoNet.Repositorios;

namespace PalcoNet.AbmPublicaciones
{
    public partial class EditarSector : MaterialForm
    {
        DataTable tabla_sectores = new DataTable();
        private Sector sector;
        private ListaSector listaSector;
        public EditarSector(Sector sector, ListaSector listaSector)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            this.sector = sector;
            this.listaSector = listaSector;
            inicializarUi();
            inicializarTiposDeUbicacion();
            agregarEncabezadosTabla();
        }

        private void inicializarUi()
        {
            txtFilas.Text = sector.CantidadFilas.ToString();
            txtAsientos.Text = sector.CantidadAsientos.ToString();
            txtPrecio.Text = sector.Precio.ToString();
        }

        private void agregarEncabezadosTabla()
        {
            tabla_sectores.Columns.Add("Tipo de ubicacion");
            tabla_sectores.Columns.Add("Cantidad de Filas");
            tabla_sectores.Columns.Add("Cantidad de Asientos");
            tabla_sectores.Columns.Add("Precio");
        }

        private void inicializarTiposDeUbicacion()
        {
            SqlDataReader lector = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Ubicaciones_Tipo", "T", new List<SqlParameter>());
            List<TipoUbicacion> tipos = new List<TipoUbicacion>();
            TipoUbicacion tipoUbicacion;
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    tipoUbicacion = TipoUbicacion.build(lector);
                    tipos.Add(tipoUbicacion);
                    cmbTipo.Items.Add(tipoUbicacion);
                }
            }
            lector.Close();
            cmbTipo.DisplayMember = "Descripcion";
            cmbTipo.ValueMember = "Id";
            cmbTipo.SelectedItem = tipos.Find(ubicacion => ubicacion.Id == sector.TipoUbicacion.Id);
        }

        private Sector getSectorDeUi()
        {
            return new Sector(Convert.ToInt32(txtFilas.Text),
                              Convert.ToInt32(txtAsientos.Text),
                              (TipoUbicacion) cmbTipo.SelectedItem, 
                              Convert.ToDouble(txtPrecio.Text));
        }

        private bool validarTipos()
        {
            try
            {
                Convert.ToInt32(txtAsientos.Text);
                Convert.ToDouble(txtPrecio.Text);
                int cantFilas = Convert.ToInt32(txtFilas.Text);
                if (cantFilas > 27)
                {
                    MessageBox.Show("Las filas se traducen a su correspondiente letra. " +
                                    "No puede registrar mas de 27 filas por sector. " +
                                    "Ingrese menos filas y registre un sector nuevo para continuar ingresando.",
                        "Editar Sector", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ingrese un valor numerico entero para Filas y Asientos, Precio puede ser con decimales");
                return false;
            }
            
            return true;

        }

        private bool validarCamposSector()
        {
            return validarFormularioCompleto() && validarTipos();
        }

        private bool validarFormularioCompleto()
        {
            bool completo = true;
            var controles = group_alta_rol.Controls;
            foreach (Control control in controles)
            {
                if ((control.Name == "txtFilas" || control.Name == "txtFilas" || control.Name == "txtPrecio") && string.IsNullOrWhiteSpace(control.Text))
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
            if (!validarCamposSector()) { return; }
            sector.reemplazar(getSectorDeUi());
            listaSector.actualizarListado();
            MessageBox.Show("Sectores Agregados", "Alta Sectores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
