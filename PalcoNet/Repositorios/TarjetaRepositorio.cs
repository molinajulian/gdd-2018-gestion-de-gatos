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
            parametros.Add(new SqlParameter("@tarjeta", tarjeta.Numero));
            parametros.Add(new SqlParameter("@FechaVencimiento", tarjeta.FechaVencimiento));
            return parametros;
        }
        public static void CreateTarjeta(Tarjeta tarjeta)
        {
            List<SqlParameter> parametros = GenerarParametrosTarjeta(tarjeta);
            DataBase.WriteInBase("Ingresartarjetas", "SP", parametros);

        }

        public static void agregar(List<Tarjeta> tarjetas, Cliente cliente)
        {
            foreach (Tarjeta tar in tarjetas)
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@num", Convert.ToDecimal(tar.Numero)));
                parametros.Add(new SqlParameter("@venc", tar.FechaVencimiento));
                parametros.Add(new SqlParameter("@banco", tar.Banco));
                parametros.Add(new SqlParameter("@tipoDoc", cliente.TipoDeDocumento.Id));
                parametros.Add(new SqlParameter("@doc",cliente.NumeroDocumento));
                DataBase.ejecutarSP("[dbo].[sp_crear_tarjeta]", parametros);
            }
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

        /*public static Tarjeta ReadTarjetaFromDb(SqlDataReader reader)
        {
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
        }*/
        
        public static List<Tarjeta> getTarjetasCliente(Cliente cliente)
        {
            List<Tarjeta> tarjetas = new List<Tarjeta>();
            SqlDataReader lector = DataBase.GetDataReader("SELECT [Tar_Cred_Id],[Tar_Cred_Num],[Tar_Cred_Venc],[Tar_Cred_Banco] " + 
                                                          " FROM GESTION_DE_GATOS.Tarjetas_Credito " +
                                                          "WHERE Tar_Cred_Cli_Doc = " + cliente.NumeroDocumento + 
                                                          " AND Tar_Cred_Cli_Tipo_Doc = " + cliente.TipoDeDocumento.Id
                                                           , "T", new List<SqlParameter>());
            while (lector.HasRows && lector.Read())
            {
                tarjetas.Add(Tarjeta.build(lector));
            }
            return tarjetas;
        }

        public static List<Tarjeta> GetTarjetasById(string id)
        {   
            var parametros = new List<SqlParameter>();
            var tarjetas = new List<Tarjeta>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from tarjeta tar where tar.Tar_Cred_Id = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                //tarjetas.Add(ReadTarjetaFromDb(reader));

            }
            return tarjetas  ;
        }
    }
}
