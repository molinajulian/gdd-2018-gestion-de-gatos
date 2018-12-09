using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class TipoUbicacionRepositorio
    {
        public static List<SqlParameter> GenerarParametrosTipoUbicacion(TipoUbicacion tipoUbicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Descripcion", tipoUbicacion.Descripcion));
            return parametros;
        }
        
        public static void CreateTipoUbicacion(TipoUbicacion tipoUbicacion)
        {
            List<SqlParameter> parametros = GenerarParametrosTipoUbicacion(tipoUbicacion);
            DataBase.WriteInBase("IngresartipoUbicacions", "SP", parametros);

        }


        public static void UpdateTipoUbicacion(TipoUbicacion tipoUbicacion)
        {
            List<SqlParameter> parametros = GenerarParametrosTipoUbicacion(tipoUbicacion);
            DataBase.WriteInBase("UpdatetipoUbicacion", "SP", parametros);

        }


        public static void DeleteTipoUbicacion(int id,string username)
        {
            List<SqlParameter> parametros = DataBase.GenerarParametrosDelete(id,username);
            DataBase.WriteInBase("DeletetipoUbicacion", "SP", parametros);
        }

        public static TipoUbicacion ReadTipoUbicacionFromDb(int id)
        {
            var tipoUbicacion = new TipoUbicacion();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from tipoUbicacion t where t.Ubic_cod = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                tipoUbicacion = new TipoUbicacion()
                {
                    Id = (int)reader.GetValue(Ordinales.TipoUbicacion["TipoPubl_id"]),
                    Descripcion = reader.GetValue(Ordinales.TipoUbicacion["TipoPubl_descripcion"]).ToString()
                };

            }
            return tipoUbicacion;

        }
    }
}
