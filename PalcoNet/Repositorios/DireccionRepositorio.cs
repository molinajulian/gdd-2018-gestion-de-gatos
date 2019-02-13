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
        public static List<SqlParameter> GenerarParametrosDireccion(Domicilio domicilio)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@localidad", domicilio.Localidad));
            parametros.Add(new SqlParameter("@cp", domicilio.CodPostal));
            parametros.Add(new SqlParameter("@calle", domicilio.Calle));
            parametros.Add(new SqlParameter("@numero", domicilio.Numero));
            parametros.Add(new SqlParameter("@departamento", domicilio.Departamento));       
            return parametros;
        }
        public static void CreateDireccion(Domicilio domicilio)
        {
            List<SqlParameter> parametros = GenerarParametrosDireccion(domicilio);
            DataBase.WriteInBase("Ingresardireccions", "SP", parametros);

        }


        public static void UpdateDireccion(Domicilio domicilio)
        {
            List<SqlParameter> parametros = GenerarParametrosDireccion(domicilio);
            DataBase.WriteInBase("Updatedireccion", "SP", parametros);

        }


        public static void DeleteDireccion(Domicilio domicilio)
        {
            List<SqlParameter> parametros = GenerarParametrosDireccion(domicilio);
            DataBase.WriteInBase("Deletedireccion", "SP", parametros);

        }

        public static Domicilio ReadDireccionFromDb(string  id)
        {
            var direccion = new Domicilio();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from GESTION_DE_GATOS.Domicilios dom where dom.Dom_Id = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                direccion = new Domicilio(
                                Convert.ToInt32(id),
                                reader.GetValue(Ordinales.Domicilio["calle"]).ToString(),
                                reader.GetValue(Ordinales.Domicilio["numero"]).ToString(),
                                reader.GetValue(Ordinales.Domicilio["departamento"]).ToString(),
                                reader.GetValue(Ordinales.Domicilio["localidad"]).ToString(),
                                reader.GetValue(Ordinales.Domicilio["codPostal"]).ToString(),
                                reader.GetValue(Ordinales.Domicilio["piso"]).ToString() 
                                );

            }
            return direccion;
        }

    }
}
