using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class GradoRepositorio
    {

        public static List<Grado> getGrados()
        {
            List<Grado> grados = new List<Grado>();
            Dictionary<string, int> camposGrado = Ordinales.Grado;
            SqlDataReader lector =
                DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Grados", "T", new List<SqlParameter>());
            while (lector.HasRows && lector.Read())
            {
                grados.Add(new Grado(
                    Convert.ToInt32(lector[camposGrado["codigo"]].ToString()),
                    Convert.ToDouble(lector[camposGrado["comision"]]),
                    lector[camposGrado["descripcion"]].ToString()));
            }
            return grados;
        }
    }
}
