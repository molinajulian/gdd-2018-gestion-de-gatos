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
            parametros.Add(new SqlParameter("@Descuento", grado.Descuento));
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

        public static Grado ReadGradoFromDb(SqlDataReader reader)
        {
            return new Grado()
            {
                Comision =(int) reader.GetValue(Ordinales.Grado["descripcion"]),
                Descuento = (int)reader.GetValue(Ordinales.Grado["codigo"]),
                Tipo = reader.GetValue(Ordinales.Grado["descripcion"]).ToString()

            };
        }

       

    }
}
