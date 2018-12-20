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
            SqlDataReader lector = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Publicaciones"
                                                          + " WHERE Public_Cod = " + id, "T", new List<SqlParameter>());
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

        public static List<PublicacionPuntual> getPublicacionesComprables(string descripcion, DateTime desde, DateTime hasta, 
                                                                          String rubrosStr)
        {
            List<PublicacionPuntual> publicaciones = new List<PublicacionPuntual>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@pub_desc", descripcion));
            parametros.Add(new SqlParameter("@desde", desde));
            parametros.Add(new SqlParameter("@hasta", hasta));
            parametros.Add(new SqlParameter("@rubros_str", rubrosStr));
            SqlDataReader lector = DataBase.GetDataReader("sp_get_publicaciones_comprables", "SP", parametros);
            while (lector.HasRows && lector.Read())
            {
                publicaciones.Add(PublicacionPuntual.buildCompuesta(lector));
            }
            return publicaciones;
        }
    }
}
