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

namespace PalcoNet.Canje_Puntos
{
    public partial class CanjePuntos : MaterialForm
    {
        public int Puntos { get; set; }
        public List<Premio> Premios { get; set; }
        public DataTable premiosParaCanjear= new DataTable();
        public List<Premio> ACanjear { get; set; }
        public CanjePuntos( Usuario user)
        {   Premios=new List<Premio>();
            ACanjear = new List<Premio>();
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            var parametros= new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Idcliente", Cliente.Actual.TipoDeDocumento.Id.ToString() + Cliente.Actual.NumeroDocumento.ToString()));
            parametros.Add(new SqlParameter("@fechaHoy", DataBase.GetFechaHoy()));
            btn_buscar.Enabled = false; 
            SqlDataReader reader = DataBase.ejecutarFuncion("Select [dbo].consultarPuntos(@Idcliente,@fechaHoy)", parametros).ExecuteReader();
            reader.Read();
            Puntos = (int)reader.GetValue(0) == null ? 0 : (int)reader.GetValue(0);
            parametros.Clear();
            Premios.Clear();
            reader = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Premios pre where pre.Premio_Id not in(select pad.Premio_Id from GESTION_DE_GATOS.Premios_Adquiridos pad)", "T", new List<SqlParameter>());
            while (reader.Read())
            {
                Premios.Add(
                    new Premio()
                    {   Id=(int)reader.GetValue(0),
                        Descripcion = reader.GetValue(1).ToString(),
                        Puntos = (int)reader.GetValue(2)
                    });
            }      
            foreach(var pre in Premios)
            {      
                string[] row={pre.Id.ToString(),pre.Descripcion,pre.Puntos.ToString() };
                data_clientes.Rows.Add(row);
            }
    }

        public void initColumns()
        {   
            premiosParaCanjear.Columns.Add("Nombre premio", typeof(string));
            premiosParaCanjear.Columns.Add("Puntos necesarios", typeof(string));
            data_clientes.DataSource = premiosParaCanjear;
            }

        private void data_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var parametros = new List<SqlParameter>();
                btn_buscar.Enabled = true;
                parametros.Add(new SqlParameter("@clienteTipoDoc", Cliente.Actual.TipoDeDocumento.Id));
                parametros.Add(new SqlParameter("@doc", Cliente.Actual.NumeroDocumento));
                parametros.Add(new SqlParameter("@premioId", Premios[data_clientes.SelectedRows[0].Index].Id));
                parametros.Add(new SqlParameter("@fechaHoy", DataBase.GetFechaHoy()));
                DataBase.WriteInBase("canjearPuntos", "SP", parametros);
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error al cambiar los puntos por el premio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Se ha canjeado correctamente");
            data_clientes.Rows.Clear();
            var parametros1= new List<SqlParameter>();
            parametros1.Add(new SqlParameter("@Idcliente", Cliente.Actual.TipoDeDocumento.Id.ToString() + Cliente.Actual.NumeroDocumento.ToString()));
            parametros1.Add(new SqlParameter("@fechaHoy", DataBase.GetFechaHoy()));
            btn_buscar.Enabled = false; 
            SqlDataReader reader = DataBase.ejecutarFuncion("Select [dbo].consultarPuntos(@Idcliente,@fechaHoy)", parametros1).ExecuteReader();
            reader.Read();
            Puntos = (int)reader.GetValue(0) == null ? 0 : (int)reader.GetValue(0);
            parametros1.Clear();
            Premios.Clear();
            reader = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Premios", "T", new List<SqlParameter>());
            while (reader.Read())
            {
                Premios.Add(
                    new Premio()
                    {   Id=(int)reader.GetValue(0),
                        Descripcion = reader.GetValue(1).ToString(),
                        Puntos = (int)reader.GetValue(2)
                    });
            }      
            foreach(var pre in Premios)
            {      
                string[] row={pre.Id.ToString(),pre.Descripcion,pre.Puntos.ToString() };
                data_clientes.Rows.Add(row);
            }
            
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }
        
    }
    public class CanjePuntosModel
        {   public int PuntosAcumulados { get; set; }
           
        }
}
