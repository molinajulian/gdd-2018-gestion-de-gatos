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
            List<SqlParameter> parametros = new List<SqlParameter>();
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            SqlDataReader lector = DataBase.GetDataReader("404_NOT_FOUND.SP_BUSCAR_FUNCIONALIDADES", "SP", parametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Funcionalidad funcionalidad = Funcionalidad.buildFuncionalidad(lector);
                    funcionalidades.Add(funcionalidad);
                }
                lector.Close();
            }
            return funcionalidades;
        }
    }
}
