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
        public CanjePuntos( Usuario user)
        {   Premios=new List<Premio>();
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            var parametros= new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Idcliente", Cliente.Actual.TipoDeDocumento.Id.ToString() + Cliente.Actual.NumeroDocumento.ToString()));
            parametros.Add(new SqlParameter("@fechaHoy", DataBase.GetFechaHoy()));

            SqlDataReader reader = DataBase.ejecutarFuncion("Select [dbo].consultarPuntos(@Idcliente,@fechaHoy)", parametros).ExecuteReader();
            reader.Read();
            Puntos = (int)reader.GetValue(0) == null ? 0 : (int)reader.GetValue(0);
            parametros.Clear();
            reader = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Premios", "T", new List<SqlParameter>());
            while (reader.Read())
            {
                Premios.Add(
                    new Premio()
                    {
                        Descripcion = reader.GetValue(1).ToString(),
                        Puntos = (int)reader.GetValue(2)


                    }
                    );
            }      
            }

       
        
    }
    public class CanjePuntosModel
        {   public int PuntosAcumulados { get; set; }
           
        }
}
