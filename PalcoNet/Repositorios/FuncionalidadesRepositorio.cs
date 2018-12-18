using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PalcoNet.Modelo;
using PalcoNet.Repositorios;

namespace PalcoNet.Repositorios
{
    class FuncionalidadesRepositorio
    {
        public static List<Funcionalidad> getFuncionalidades()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            string sql = "SELECT * FROM GESTION_DE_GATOS.Funcionalidades";
            SqlDataReader lector = DataBase.GetDataReader(sql, "T", new List<SqlParameter>());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    funcionalidades.Add(Funcionalidad.buildFuncionalidad(lector));
                }
            }
            lector.Close();
            return funcionalidades;
        }
    }
}
