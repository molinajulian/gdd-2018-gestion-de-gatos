using MaterialSkin;
using MaterialSkin.Controls;
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
using System.Data.SqlClient;
using PalcoNet.Modelo;
using PalcoNet.Repositorios;
namespace PalcoNet.Generar_Rendicion_Comisiones
{
    public partial class RendicionDeComisiones :  MaterialForm
    {
        public string cuitIngresado { get; set; }
        public int cantIngresada { get; set; }
        public List<SqlParameter> parametros { get; set; }
        private DataTable tabla_facturas = new DataTable();
        public RendicionDeComisiones()
        {   
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            tabla_facturas.Columns.Add("Fecha Facturacion");
            tabla_facturas.Columns.Add("Numero Factura");
            tabla_facturas.Columns.Add("Total");
            tabla_facturas.Columns.Add("Empresa Cuit");
        }


        private void actualizarTablaRendiciones()
        {
            Factura factura = FacturaRepositorio.getUltimaFactura();
            tabla_facturas.Rows.Clear();
            String[] ubiacionRow =
            {
                factura.Fecha.ToString(), factura.Numero.ToString(), factura.Total.ToString(),
                factura.EmpresaCuit
            };
            tabla_facturas.Rows.Add(ubiacionRow);
            dgvFacturas.DataSource = tabla_facturas;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@empresaCuit", txtEmpresa.Text));
                parametros.Add(new SqlParameter("@cantidad", Convert.ToInt32(txtCantidad.Text)));
                parametros.Add(new SqlParameter("@username", Usuario.Actual.username));
                parametros.Add(new SqlParameter("@fechaHoy", DataBase.GetFechaHoy()));
                DataBase.ejecutarSP("GenerarRendicionComisiones", parametros);
                MessageBox.Show("Factura realizada", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                actualizarTablaRendiciones();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RendicionDeComisiones_Load(object sender, EventArgs e)
        {

        }
    }
}
