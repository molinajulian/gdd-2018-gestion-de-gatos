using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    public class EstadoPublicacionRepositorio
    {
        public static List<SqlParameter> GenerarParametrosEstadoPublicacion(EstadoPublicacion estado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Descripcion", estado.Descripcion));
            parametros.Add(new SqlParameter("@esPosibleCambio", estado.Descripcion));

            return parametros;
        }
        public static void CreateEstadoPublicacion(EstadoPublicacion estado)
        {
            List<SqlParameter> parametros = GenerarParametrosEstadoPublicacion(estado);
            DataBase.WriteInBase("Ingresarestados", "SP", parametros);

        }


        public static void UpdateEstadoPublicacion(EstadoPublicacion estado)
        {
            List<SqlParameter> parametros = GenerarParametrosEstadoPublicacion(estado);
            DataBase.WriteInBase("Updateestado", "SP", parametros);

        }


        public static void DeleteEstadoPublicacion(EstadoPublicacion estado)
        {
            List<SqlParameter> parametros = GenerarParametrosEstadoPublicacion(estado);
            DataBase.WriteInBase("Deleteestado", "SP", parametros);

        }

        public static EstadoPublicacion ReadEstadoPublicacionFromDb(int id)
        {
            var estado = new EstadoPublicacion();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from estadopublicacion e where e.Public_Est_Id = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                estado = new EstadoPublicacion()
                {
                    Id = (int)reader.GetValue(Ordinales.EstadoPublicacion["id"]),
                    Descripcion = reader.GetValue(Ordinales.Empresa["descripcion"]).ToString(),
                    EsPosibleCambio= (bool)reader.GetValue(Ordinales.Empresa["esPosibleCambio"])


                };

            }
            return estado;
        }


    }
}

