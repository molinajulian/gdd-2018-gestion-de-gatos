using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class GradoRepositorio
    {
        public static List<SqlParameter> GenerarParametrosGrado(Grado grado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Descripcion", grado.Comision));
            parametros.Add(new SqlParameter("@Descuento", grado.Descripcion));
            parametros.Add(new SqlParameter("@Tipo", grado.Tipo));


            return parametros;
        }
        public static void CreateGrado(Grado grado)
        {
            List<SqlParameter> parametros = GenerarParametrosGrado(grado);
            DataBase.WriteInBase("Ingresargrados", "SP", parametros);

        }


        public static void UpdateGrado(Grado grado)
        {
            List<SqlParameter> parametros = GenerarParametrosGrado(grado);
            DataBase.WriteInBase("Updategrado", "SP", parametros);

        }


        public static void DeleteGrado(Grado grado)
        {
            List<SqlParameter> parametros = GenerarParametrosGrado(grado);
            DataBase.WriteInBase("Deletegrado", "SP", parametros);

        }

        public static Grado ReadGradoFromDb( int id )
        {
            var grado = new Grado();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from grado g where g.grado_cod = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                grado = new Grado()
                {
                    Comision = (int)reader.GetValue(Ordinales.Grado["descripcion"]),
                    Descripcion = (int)reader.GetValue(Ordinales.Grado["codigo"]),
                    Tipo = reader.GetValue(Ordinales.Grado["descripcion"]).ToString()

                };

            }
            return grado;
            
        }

       

    }
}
