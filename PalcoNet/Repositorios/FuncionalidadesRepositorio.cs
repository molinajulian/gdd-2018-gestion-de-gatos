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

        internal static List<Funcionalidad> getFuncionalidades(int idRol)
        {
            string sql = "SELECT fpr.Func_Id,Func_Descr FROM GESTION_DE_GATOS.Funcionalidad_Por_Rol fpr JOIN GESTION_DE_GATOS.Funcionalidades f ON f.Func_Id = fpr.Func_Id  where fpr.Rol_Id="+idRol.ToString();
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
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
