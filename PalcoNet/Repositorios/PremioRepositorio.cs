using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class PremioRepositorio
    {
        public static List<SqlParameter> GenerarParametrosPremio(Premio premio)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Descuento", premio.Descripcion));
            parametros.Add(new SqlParameter("@Puntos", premio.Puntos));



            return parametros;
        }
        public static void CreatePremio(Premio premio)
        {
            List<SqlParameter> parametros = GenerarParametrosPremio(premio);
            DataBase.WriteInBase("Ingresarpremios", "SP", parametros);

        }


        public static void UpdatePremio(Premio premio)
        {
            List<SqlParameter> parametros = GenerarParametrosPremio(premio);
            DataBase.WriteInBase("Updatepremio", "SP", parametros);

        }


        public static void DeletePremio(Premio premio)
        {
            List<SqlParameter> parametros = GenerarParametrosPremio(premio);
            DataBase.WriteInBase("Deletepremio", "SP", parametros);

        }

        public static Premio ReadPremioFromDb(int id)
        {
            var premio = new Premio();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from premio g where g.premio_cod = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                premio = new Premio()
                {
                    Id = (int)reader.GetValue(Ordinales.Premio["Premio_Id"]),
                    Descripcion = reader.GetValue(Ordinales.Premio["Premio_Desc"]).ToString(),
                    Puntos = (int)reader.GetValue(Ordinales.Premio["Premio_Puntos"])

                };

            }
            return premio;

        }
    }
}
