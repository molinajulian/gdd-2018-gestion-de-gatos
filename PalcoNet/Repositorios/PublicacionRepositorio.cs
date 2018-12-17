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
            crearUbicacionesPorEspectaculo(publicacion.Sectores, publicacion.Espectaculos);
            MessageBox.Show("Publicacion generada exitosamente", "Alta Publicacion", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public static void crearUbicacionesPorEspectaculo(List<Sector> sectores, List<Espectaculo> espectaculos)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            foreach (Espectaculo espectaculo in espectaculos)
            {
                foreach (Sector sector in sectores)
                {
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@ubic_tipo", sector.TipoUbicacion.Id));
                    parametros.Add(new SqlParameter("@ubic_precio", sector.Precio));
                    parametros.Add(new SqlParameter("@ubic_espec_codigo", espectaculo.Id));
                    parametros.Add(new SqlParameter("@cnt_filas", sector.CantidadFilas));
                    parametros.Add(new SqlParameter("@cnt_asientos", sector.CantidadAsientos));
                    DataBase.ejecutarSP("sp_crear_ubicaciones", parametros);
                }
            }
        }

        public static void crearPublicacion(Publicacion publicacion)
        {
            foreach (Espectaculo espectaculo in publicacion.Espectaculos)
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@pub_desc", publicacion.Descripcion));
                parametros.Add(new SqlParameter("@pub_grado_cod", publicacion.Grado.Id));
                parametros.Add(new SqlParameter("@pub_fecha_creacion", publicacion.FechaPublicacion));
                parametros.Add(new SqlParameter("@espec_cod", espectaculo.Id));
                DataBase.ejecutarSP("sp_crear_publicacion", parametros);
            }
        }

        public static Publicacion GetPublicacionById(int id)
        {
            var publicacion = new Publicacion();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from publicacion r where r.Public_cod = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                publicacion = new Publicacion()
                {
                    Codigo = (int)reader.GetValue(Ordinales.Publicacion["publ_codigo"]),
                    Descripcion = reader.GetValue(Ordinales.Publicacion["publ_descripcion"]).ToString(),
                    FechaPublicacion = (DateTime)reader.GetValue(Ordinales.Publicacion["publ_fechaVencimiento"])

                };
                publicacion.Estado = EstadoPublicacionRepositorio.ReadEstadoPublicacionFromDb(publicacion.Codigo);
                publicacion.Espectaculos = EspectaculoRepositorio.ReadEspectaculoFromDb(publicacion.Codigo);
                publicacion.Grado = GradoRepositorio.ReadGradoFromDb(publicacion.Codigo);
            }
            return publicacion;
        }
    }
}
