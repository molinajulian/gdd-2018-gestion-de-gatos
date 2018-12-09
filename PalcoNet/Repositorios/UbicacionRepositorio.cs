using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class UbicacionRepositorio
    {
        public static List<SqlParameter> GenerarParametrosUbicacion(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Fila", ubicacion.Fila));
            parametros.Add(new SqlParameter("@Asiento", ubicacion.Asiento));
            parametros.Add(new SqlParameter("@TipoUbicacion", ubicacion.TipoUbicacion));
            parametros.AddRange(TipoUbicacionRepositorio.GenerarParametrosTipoUbicacion(ubicacion.TipoUbicacion));



            return parametros;
        }
        public static void CreateUbicacion(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = GenerarParametrosUbicacion(ubicacion);
            DataBase.WriteInBase("Ingresarubicacions", "SP", parametros);

        }


        public static void UpdateUbicacion(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = GenerarParametrosUbicacion(ubicacion);
            DataBase.WriteInBase("Updateubicacion", "SP", parametros);

        }


        public static void DeleteUbicacion(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = GenerarParametrosUbicacion(ubicacion);
            DataBase.WriteInBase("Deleteubicacion", "SP", parametros);

        }

        public static List<Ubicacion> ReadUbicacionesFromDb(int id)
        {
            var ubicaciones = new List<Ubicacion>();
           
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from ubicacion r where r.Ubic_Cod = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                ubicaciones.Add(new Ubicacion()
                {   Id = (int)reader.GetValue(Ordinales.Ubicacion["codigo"]),
                    Fila = (char)reader.GetValue(Ordinales.Ubicacion["fila"]),
                    Asiento = (int)reader.GetValue(Ordinales.Ubicacion["asiento"]),
                    TipoUbicacion = TipoUbicacionRepositorio.ReadTipoUbicacionFromDb((int)reader.GetValue(Ordinales.Ubicacion["codigo"]))


                });

            }
            return ubicaciones;
        }

    }
}
