using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class PublicacionRepositorio
    {
        public static List<SqlParameter> GenerarParametrosPublicacion(Publicacion publicacion, string username)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Descripcion", publicacion.Descripcion));
            parametros.Add(new SqlParameter("@Codigo", publicacion.Codigo));
            parametros.Add(new SqlParameter("@FechaPublicacion", publicacion.FechaPublicacion));
            parametros.Add(new SqlParameter("@FechaFuncion", publicacion.FechaFuncion));
            parametros.Add(new SqlParameter("@username", username));
            return parametros;
        }
        public static void CreatePublicacion(Publicacion publicacion, string username)
        {
            List<SqlParameter> parametros = GenerarParametrosPublicacion(publicacion, username);
            DataBase.WriteInBase("IngresarPubl", "SP", parametros);

        }


        public static void UpdatePublicacion(Publicacion publicacion, string username)
        {
            List<SqlParameter> parametros = GenerarParametrosPublicacion(publicacion, username);
            DataBase.WriteInBase("UpdatePubl", "SP", parametros);

        }


        public static void DeletePublicacion(Publicacion publicacion, string username)
        {
            List<SqlParameter> parametros = GenerarParametrosPublicacion(publicacion, username);
            DataBase.WriteInBase("DeletePubl", "SP", parametros);

        }

        public static Publicacion ReadPublicacionFromDb(SqlDataReader reader)
        {
            return new Publicacion()
            {   FechaPublicacion=(DateTime)reader.GetValue(Ordinales.Publicacion["fechaPublicacion"]),
                FechaFuncion=(DateTime)reader.GetValue(Ordinales.Publicacion["fechaFuncion"]), 
                Descripcion = reader.GetValue(Ordinales.Publicacion["descripcion"]).ToString(),
                Codigo = (int)reader.GetValue(Ordinales.Publicacion["codigo"])
               
                //conseguir las ubicaciones de la publicacion
                //conseguir el estado de la publicacion
                //conseguir el grado de la publicacion 
                //consguir el rubro de la publicacion
                

            };
        }

    }
}
