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
            comboTrimestre.Items.Add("Primero");
            comboTrimestre.Items.Add("Segundo");
            comboTrimestre.Items.Add("Tercero");
            comboTrimestre.Items.Add("Cuarto");
            comboListado.Items.Add("Empresas con mas localidades sin vender");
            comboListado.Items.Add("Clientes con mas puntos vencidos");
            comboListado.Items.Add("Clientes con mas compras realizadas");
            getGrados();
            txtMes.Hide();
            comboGrados.Hide();
            labelGrado.Hide();
            labelMes.Hide();
            initColumnsParaEmpresasConLocalidades();
            initColumnsParaClientesConMasPuntosVencidos();
            initColumnsParaClientesConMayorCantidadDeCompras();
        }
        private void getGrados()
        {
            List<Grado> grados = GradoRepositorio.getGrados();
            foreach (Grado g in grados)
            {
                comboGrados.Items.Add(g);
            }
            comboGrados.DisplayMember = "Descripcion";
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
        private int getTrimestre(string trimestre)
        {
            switch (trimestre)
            {
                case "Primero": return 1;
                case "Segundo": return 2;
                case "Tercero": return 3;
                case "Cuarto": return 4;
            }
            return -1;
        }
        public void refreshValues(DataTable tabla)
        {
            data_Listado.DataSource = tabla;
        }
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAño.Text) || comboListado.SelectedIndex == -1 || comboTrimestre.SelectedIndex == -1)
            {
                MessageBox.Show("Complete todos los campos para continuar", "Error al buscar el listado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                
                Grado g = (Grado)comboGrados.SelectedItem;
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@año", Convert.ToInt32(txtAño.Text)));
                parametros.Add(new SqlParameter("@trimestre", getTrimestre((string)comboTrimestre.SelectedItem)));
                if (!string.IsNullOrEmpty(txtMes.Text)) parametros.Add(new SqlParameter("@mes", Convert.ToInt32(txtMes.Text)));
                if (g != null) parametros.Add(new SqlParameter("@gradoVisibilidad", g.Id));
                switch (tipoListadoseleccionado)
                {
                    case ("Empresas con mas localidades sin vender"):
                        tablaEmpresasConLocalidades.Rows.Clear();
                        refreshValues(tablaEmpresasConLocalidades);
                        txtMes.Show();
                        comboGrados.Show();
                        labelGrado.Show();
                        labelMes.Show();
                        string query = "select * from empresasConLocalidadesSinVender(null,null2,@Año,@Trimestre)";
                        if (g != null) query=query.Replace("null", "@gradoVisibilidad");
                        if (!string.IsNullOrEmpty(txtMes.Text)) {query = query.Replace("@gradoVisibilidad2", "@mes"); query = query.Replace("null2","@mes");};
                        query = query.Replace("@gradoVisibilidad2", "null");
                        query = query.Replace("null2", "null");
                        SqlDataReader reader = DataBase.ejecutarFuncion(query, parametros).ExecuteReader();
                        var lista = new List<ListadoEstadisticoEmpresasConMasLocalidadesSinVender>();
                        while (reader.Read())
                        {
                            lista.Add(
                                new ListadoEstadisticoEmpresasConMasLocalidadesSinVender()
                                {
                                    RazonSocial = reader.GetValue(0).ToString(),
                                    FechaEspectaculo = reader.GetValue(1).ToString(),
                                    Grado = reader.GetValue(2).ToString()
                                });
                        }
                        foreach (var emp in lista)
                        {
                            string[] row = { emp.RazonSocial, emp.Grado, emp.FechaEspectaculo };
                            tablaEmpresasConLocalidades.Rows.Add(row);
                        }
                        refreshValues(tablaEmpresasConLocalidades);
                        break;
                    case ("Clientes con mas puntos vencidos"):
                        txtMes.Hide();
                        comboGrados.Hide();
                        txtMes.Text = "";
                        comboGrados.SelectedIndex = -1;
                        labelGrado.Hide();
                        labelMes.Hide();
                        tablaClientesConMasPuntosVencidos.Rows.Clear();
                        refreshValues(tablaClientesConMasPuntosVencidos);
                        if (parametros.Count == 3) parametros.RemoveAt(2);
                        if (parametros.Count == 4) { parametros.RemoveAt(3); parametros.RemoveAt(2); }
                        var lista1 = new List<ListadoEstadisticoClientesConMasPuntosVencidos>();
                        reader = DataBase.ejecutarFuncion("select * from clientesConMayoresPuntosVencidos(@Año,@Trimestre)", parametros).ExecuteReader();
                        while (reader.Read())
                        {
                            lista1.Add(
                                new ListadoEstadisticoClientesConMasPuntosVencidos()
                                {
                                    ClienteNombre = reader.GetValue(0).ToString(),
                                    PuntosVencidos = reader.GetValue(1).ToString()
                                });
                        }
                        foreach (var cli in lista1)
                        {
                            string[] row1 = { cli.ClienteNombre, cli.PuntosVencidos };
                            tablaClientesConMasPuntosVencidos.Rows.Add(row1);
                        }
                        refreshValues(tablaClientesConMasPuntosVencidos);
                        break;
                    case ("Clientes con mas compras realizadas"):
                        txtMes.Hide();
                        comboGrados.Hide();
                        txtMes.Text = "";
                        comboGrados.SelectedIndex = -1;
                        labelGrado.Hide();
                        labelMes.Hide();
                        tabla_clientesConMasCompras.Rows.Clear();
                        refreshValues(tabla_clientesConMasCompras);
                        if (parametros.Count == 3) parametros.RemoveAt(2);
                        if (parametros.Count == 4) { parametros.RemoveAt(3); parametros.RemoveAt(2); }
                        var lista2 = new List<ListadoEstadisticoClientesConMayorCantidadDeCompras>();
                        reader = DataBase.ejecutarFuncion("select * from clientesConMayorCantidadDeComprasPorEmpresa(@Año,@Trimestre) ", parametros).ExecuteReader();
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
                            string[] row2 = { cli.ClienteNombre, cli.CantidadCompras.ToString(), cli.RazonSocial };
                            tabla_clientesConMasCompras.Rows.Add(row2);
                        }
                        refreshValues(tabla_clientesConMasCompras);
                        break;
                    default: break;
                }
            }
        
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
