using MaterialSkin;
using MaterialSkin.Controls;
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

namespace PalcoNet.Listado_Estadistico
{
    public partial class ListadoEstadistico : MaterialForm
    {
        private List<SqlParameter> parametros { get; set; }
        private string tipoListadoseleccionado{get;set;} 
        DataTable tablaEmpresasConLocalidades = new DataTable();
        DataTable tablaClientesConMasPuntosVencidos= new DataTable();
        DataTable tabla_clientesConMasCompras = new DataTable();
        public ListadoEstadistico()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            var parametros = new List<SqlParameter>();
            tipoListado.Items.Add("EmpresasConMasLocalidadesSinVender");
            tipoListado.Items.Add("ClientesConMasPuntosVencidos");
            tipoListado.Items.Add("ClientesConMasComprasRealizadas");
                    }
        private void initColumnsParaEmpresasConLocalidades()
        {   data_Listado.Columns.Add(,);
            
        }
        private void initColumnsParaClientesConMasPuntosVencidos()
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
            actualizarTabla();
        }
        private void initColumnsParaClientesConMayorCantidadDeCompras()
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
            actualizarTabla();
        }

        private void data_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void combo_roles_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoListadoseleccionado =(string)tipoListado.SelectedItem;
            
        }

        private void tx_dni_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(trimestre.Text) > 4 || int.Parse(trimestre.Text) < 1)
                    throw new Exception("ingrese un valor de trimestre valido");
                else { parametros.Add(new SqlParameter("@Trimestre", int.Parse(trimestre.Text))); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia.", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {SqlDataReader reader=new SqlDataReader();
            switch (tipoListadoseleccionado)
            {   
                case ("EmpresasConMasLocalidadesSinVender"): 
                    
                   reader =  DataBase.ejecutarFuncion("", parametros).ExecuteReader();
                   while (reader.Read())
                   { }   
                    break;
                case ("ClientesConMasPuntosVencidos"): 
                    reader =  DataBase.ejecutarFuncion("", parametros).ExecuteReader();
                   while (reader.Read())
                   { } 
                    break;
                case ("ClientesConMasComprasRealizadas"):
                    reader =  DataBase.ejecutarFuncion("", parametros).ExecuteReader();
                   while (reader.Read())
                   { } 
                    break;
                default: break;
            }
        }
    }
}
