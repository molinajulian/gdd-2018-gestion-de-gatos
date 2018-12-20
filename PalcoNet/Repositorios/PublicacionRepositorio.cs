using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalcoNet.Repositorios
{
    class PublicacionRepositorio
    {

        public static void darAltaPublicacion(Publicacion publicacion)
        {
            EspectaculoRepositorio.crearTodos(publicacion.Espectaculos);
            crearPublicacion(publicacion);
            UbicacionRepositorio.crearUbicacionesPorEspectaculo(publicacion.Sectores, publicacion.Espectaculos);
            MessageBox.Show("Publicacion generada exitosamente", "Alta Publicacion", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static void crearPublicacion(Publicacion publicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            foreach (Espectaculo espectaculo in publicacion.Espectaculos)
            {
                parametros.Add(new SqlParameter("@pub_desc", publicacion.Descripcion));
                parametros.Add(new SqlParameter("@pub_grado_cod", publicacion.Grado.Id));
                parametros.Add(new SqlParameter("@pub_fecha_creacion", publicacion.FechaPublicacion));
                parametros.Add(new SqlParameter("@espec_cod", espectaculo.Id));
                parametros.Add(new SqlParameter("@pub_estado_id", publicacion.Estado.Id));
                parametros.Add(new SqlParameter("@editor_id", publicacion.Editor.id));
                DataBase.ejecutarSP("sp_crear_publicacion", parametros);
                parametros.Clear();
            }
        }

        public static PublicacionPuntual GetPublicacionById(int id)
        {
            var query = "SELECT Public_Cod,isnull(Public_Desc,''),Public_Fecha_Creacion,Public_Grado_Cod,Public_Espec_Cod,Public_Estado_Id,isnull(Public_Editor,-1) FROM GESTION_DE_GATOS.Publicaciones WHERE Public_Cod = " + id;
            SqlDataReader lector = DataBase.GetDataReader(query, "T", new List<SqlParameter>());
            if (lector.HasRows && lector.Read())
            {
                return PublicacionPuntual.build(lector);
            }
            return null;
        }

        public static List<PublicacionPuntual> getPublicacionesEditables(string tituloPub)
        {
            EstadoPublicacion estadoBorrador = EstadoPublicacionRepositorio.getEstados()
                .Find(publicacion => publicacion.Descripcion.Equals("BORRADOR"));
            List<PublicacionPuntual> publicaciones = new List<PublicacionPuntual>();
            SqlDataReader lector = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Publicaciones"
                                                          + " WHERE Public_Desc LIKE '%" + tituloPub + "%'" 
                                                          + " AND Public_Editor IS NOT NULL AND Public_Estado_Id = " + estadoBorrador.Id, "T", new List<SqlParameter>());
            while (lector.HasRows && lector.Read())
            {
                publicaciones.Add(PublicacionPuntual.build(lector));
            }
            return publicaciones;
        }

        public static void actualizarPublicacionPuntual(PublicacionPuntual publicacion)
        {
            actualizarPublicacion(publicacion);
            EspectaculoRepositorio.actualizar(publicacion.Espectaculo);
            UbicacionRepositorio.actualizarSectores(publicacion.getSectores(), publicacion.Espectaculo);
            MessageBox.Show("Publicacion y Espectaculos actualizados exitosamente", "Modificacion Publicacion Puntual", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void actualizarPublicacion(PublicacionPuntual publicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@pub_cod", publicacion.Codigo));
            parametros.Add(new SqlParameter("@pub_desc", publicacion.Descripcion));
            parametros.Add(new SqlParameter("@pub_grado_cod", publicacion.Grado.Id));
            parametros.Add(new SqlParameter("@pub_estado_id", publicacion.Estado.Id));
            parametros.Add(new SqlParameter("@editor_id", publicacion.Editor.id));
            parametros.Add(new SqlParameter("@espec_cod", publicacion.Espectaculo.Id));
            DataBase.ejecutarSP("sp_actualizar_publicacion", parametros);
        }

        public static List<PublicacionPuntual> getPublicacionesComprables(string descripcion, DateTime desde,
                                                                          DateTime hasta, string rubrosStr, 
                                                                          int offset, int limit, bool ascending)
        {
            List<PublicacionPuntual> publicaciones = new List<PublicacionPuntual>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@pub_desc", descripcion));
            parametros.Add(new SqlParameter("@desde", desde));
            parametros.Add(new SqlParameter("@hasta", hasta));
            parametros.Add(new SqlParameter("@rubros_str", rubrosStr));
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT [Public_Cod], [Public_Desc], [Public_Fecha_Creacion], [Public_Grado_Cod], " +
                      "[Public_Espec_Cod], [Public_Estado_Id], [Public_Editor], [Espec_Cod], [Espec_Desc], " +
                      "[Espec_Fecha], [Espec_Fecha_Venc], [Espec_Rubro_Cod], [Espec_Emp_Cuit], [Espec_Dom_Id], [Espec_Estado] " +
                      "FROM GESTION_DE_GATOS.Publicaciones " +
                      "JOIN GESTION_DE_GATOS.Espectaculos " +
                      "ON Public_Espec_Cod = Espec_Cod " +
                      "WHERE Public_Desc LIKE '%' + @pub_desc + '%' " +
                      "AND Public_Estado_Id = 2 " +
                      "AND Espec_Fecha BETWEEN @desde AND @hasta ");
            sb.Append(rubrosStr.Equals("")
                ? ""
                : "AND Espec_Rubro_Cod IN (SELECT * FROM dbo.SPLIT_STRING(@rubros_str, ',')) ");
            sb.Append(" ORDER BY Public_Grado_Cod " + (ascending ? "ASC" : "DESC") +
                      " OFFSET " + offset + " ROWS" +
                      " FETCH NEXT " + limit + " ROWS ONLY;");
            SqlDataReader lector = DataBase.GetDataReader(sb.ToString(), "T", parametros);
            while (lector.HasRows && lector.Read())
            {
                publicaciones.Add(PublicacionPuntual.buildCompuesta(lector));
            }
            return publicaciones;
        }
    }
}
