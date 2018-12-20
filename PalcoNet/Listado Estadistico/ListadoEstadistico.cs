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
        private string trimestreIngresado { get; set; }
        public string añoIngresado { get; set; }
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
        {
            tablaEmpresasConLocalidades.Clear();
            tablaEmpresasConLocalidades.Columns.Add("RazonSocial",typeof(string));
            tablaEmpresasConLocalidades.Columns.Add("Grado", typeof(string));
            tablaEmpresasConLocalidades.Columns.Add("Fecha", typeof(string));
            data_Listado.DataSource = tablaEmpresasConLocalidades;
        }
        private void initColumnsParaClientesConMasPuntosVencidos()
        {
            tablaClientesConMasPuntosVencidos.Clear();
            tablaClientesConMasPuntosVencidos.Columns.Add("Cliente", typeof(string));
            tablaClientesConMasPuntosVencidos.Columns.Add("Puntos", typeof(string));
            data_Listado.DataSource = tablaClientesConMasPuntosVencidos;
            
        }
        private void initColumnsParaClientesConMayorCantidadDeCompras()
        {
            tabla_clientesConMasCompras.Clear();
            tabla_clientesConMasCompras.Columns.Add("Cliente", typeof(string));
            tabla_clientesConMasCompras.Columns.Add("CantidadCompras", typeof(int));
            tabla_clientesConMasCompras.Columns.Add("RazonSocial", typeof(string));
            data_Listado.DataSource = tabla_clientesConMasCompras;
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
                else { trimestreIngresado=trimestre.Text; }
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
        {
        parametros.Add(new SqlParameter("@Trimestre", int.Parse(trimestre.Text)));
        parametros.Add(new SqlParameter("@Año", int.Parse(textBox1.Text)));
        switch (tipoListadoseleccionado)
        {   
            case ("EmpresasConMasLocalidadesSinVender"):
                initColumnsParaEmpresasConLocalidades();
                SqlDataReader reader = DataBase.ejecutarFuncion("select empresasConLocalidadesSinVender(@Año,@Trimestre)", parametros).ExecuteReader();
                var lista= new List<ListadoEstadisticoEmpresasConMasLocalidadesSinVender>();
                while (reader.Read())
                {    lista.Add(
                    new ListadoEstadisticoEmpresasConMasLocalidadesSinVender()
                    {
                        RazonSocial=reader.GetValue(0).ToString(),
                        FechaEspectaculo=reader.GetValue(1).ToString(),
                        Grado=reader.GetValue(2).ToString()
                    });       
                }
                foreach (var emp in lista)
                {
                    string[] row = { emp.RazonSocial, emp.Grado, emp.FechaEspectaculo};
                    data_Listado.Rows.Add(row);
                }
                break;
            case ("ClientesConMasPuntosVencidos"):
                var lista1=new List<ListadoEstadisticoClientesConMasPuntosVencidos>();
                initColumnsParaClientesConMasPuntosVencidos();
                reader = DataBase.ejecutarFuncion("select clientesConMayoresPuntosVencidos(@Año,@Trimestre)", parametros).ExecuteReader();
                while (reader.Read())
                {
                    lista1.Add(
                        new ListadoEstadisticoClientesConMasPuntosVencidos()
                        {
                            ClienteNombre = reader.GetValue(0).ToString(),
                            PuntosVencidos= reader.GetValue(1).ToString()
                        });
                }
                foreach (var cli in lista1)
                {
                    string[] row1 = { cli.ClienteNombre, cli.PuntosVencidos};
                    data_Listado.Rows.Add(row1);
                }
                break;
            case ("ClientesConMasComprasRealizadas"):
                var lista2 = new List<ListadoEstadisticoClientesConMayorCantidadDeCompras>();
                initColumnsParaClientesConMayorCantidadDeCompras();
                reader = DataBase.ejecutarFuncion("select clientesConMayorCantidadDeComprasPorEmpresa(@Año,@Trimestre) ", parametros).ExecuteReader();
                while (reader.Read())
                {
                    lista2.Add(
                    new ListadoEstadisticoClientesConMayorCantidadDeCompras()
                    {
                        RazonSocial = reader.GetValue(2).ToString(),
                        ClienteNombre = reader.GetValue(0).ToString(),
                        CantidadCompras = (int)reader.GetValue(1)
                    });     
                }
                foreach (var cli in lista2)
                {
                    string[] row2 = {cli.ClienteNombre,cli.CantidadCompras.ToString(),cli.RazonSocial};
                    data_Listado.Rows.Add(row2);
                }
                break;
            default: break;
        }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) > 0)
            {   
               añoIngresado= textBox1.Text; }
        }
    }
    public class ListadoEstadisticoEmpresasConMasLocalidadesSinVender
    {
        public string RazonSocial { get; set; }
        public string Grado { get; set; }
        public string FechaEspectaculo { get; set; }
    }
    public class ListadoEstadisticoClientesConMasPuntosVencidos
    {
        public string ClienteNombre { get; set; }
        public string PuntosVencidos { get; set; }
    }
    public class ListadoEstadisticoClientesConMayorCantidadDeCompras
    {
        public string ClienteNombre { get; set; }
        public int CantidadCompras { get; set; }
        public string RazonSocial { get; set; }
    }
 
}
