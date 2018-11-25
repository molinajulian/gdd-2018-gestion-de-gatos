using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class DireccionRepositorio
    {
        public static List<SqlParameter> GenerarParametrosDireccion(Direccion direccion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@localidad", direccion.Localidad));
            parametros.Add(new SqlParameter("@cp", direccion.CodPostal));
            parametros.Add(new SqlParameter("@calle", direccion.Calle));
            parametros.Add(new SqlParameter("@numero", direccion.Numero));
            parametros.Add(new SqlParameter("@departamento", direccion.Departamento));       
            return parametros;
        }
        public static void CreateDireccion(Direccion direccion)
        {
            List<SqlParameter> parametros = GenerarParametrosDireccion(direccion);
            DataBase.WriteInBase("Ingresardireccions", "SP", parametros);

        }


        public static void UpdateDireccion(Direccion direccion)
        {
            List<SqlParameter> parametros = GenerarParametrosDireccion(direccion);
            DataBase.WriteInBase("Updatedireccion", "SP", parametros);

        }


        public static void DeleteDireccion(Direccion direccion)
        {
            List<SqlParameter> parametros = GenerarParametrosDireccion(direccion);
            DataBase.WriteInBase("Deletedireccion", "SP", parametros);

        }

        public static Direccion ReadDireccionFromDb(SqlDataReader reader)
        {
            return new Direccion(
                                reader.GetValue(Ordinales.Direccion["calle"]).ToString(),
                                reader.GetValue(Ordinales.Direccion["numero"]).ToString(),
                                reader.GetValue(Ordinales.Direccion["departamento"]).ToString(),
                                reader.GetValue(Ordinales.Direccion["localidad"]).ToString(),
                                reader.GetValue(Ordinales.Direccion["codPostal"]).ToString()
                                );
        }

    }
}
