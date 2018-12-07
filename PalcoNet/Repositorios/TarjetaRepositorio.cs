using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class TarjetaRepositorio
    {

        public static List<SqlParameter> GenerarParametrosTarjeta(Tarjeta tarjeta)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@tarjeta", tarjeta.Nombre));
            parametros.Add(new SqlParameter("@tarjeta", tarjeta.Numero));
            parametros.Add(new SqlParameter("@CCV", tarjeta.CCV));
            parametros.Add(new SqlParameter("@FechaVencimiento", tarjeta.FechaVencimiento));
            return parametros;
        }
        public static void CreateTarjeta(Tarjeta tarjeta)
        {
            List<SqlParameter> parametros = GenerarParametrosTarjeta(tarjeta);
            DataBase.WriteInBase("Ingresartarjetas", "SP", parametros);

        }


        public static void UpdateTarjeta(Tarjeta tarjeta)
        {
            List<SqlParameter> parametros = GenerarParametrosTarjeta(tarjeta);
            DataBase.WriteInBase("Updatetarjeta", "SP", parametros);

        }


        public static void DeleteTarjeta(Tarjeta tarjeta)
        {
            List<SqlParameter> parametros = GenerarParametrosTarjeta(tarjeta);
            DataBase.WriteInBase("Deletetarjeta", "SP", parametros);

        }

        public static Tarjeta ReadTarjetaFromDb(SqlDataReader reader)
        {
            var tarjeta = new Tarjeta();
            while (reader.Read())
            {
                tarjeta = new Tarjeta(
                             reader.GetValue(Ordinales.Tarjeta["numeroTarjeta"]).ToString(),
                             reader.GetValue(Ordinales.Tarjeta["nombreTarjeta"]).ToString(),
                             (DateTime)reader.GetValue(Ordinales.Tarjeta["fechaVencimiento"]),
                             reader.GetValue(Ordinales.Tarjeta["ccv"]).ToString()
                             );
            }


            return tarjeta;


        }
        public static List<Tarjeta> GetTarjetasById(string id)
        {   
            var parametros = new List<SqlParameter>();
            var tarjetas = new List<Tarjeta>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from tarjeta tar where tar.id = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                tarjetas.Add(ReadTarjetaFromDb(reader));

            }
            return tarjetas  ;
        }
    }
}
