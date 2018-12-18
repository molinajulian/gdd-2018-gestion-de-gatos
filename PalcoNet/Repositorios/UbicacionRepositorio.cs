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
            parametros.Add(new SqlParameter("@SinNumerar", ubicacion.SinNumerar));
            parametros.Add(new SqlParameter("@Precio", ubicacion.Precio));
            parametros.Add(new SqlParameter("@EspecCodigo", ubicacion.EspectaculoId));
            parametros.Add(new SqlParameter("@TipoId", ubicacion.TipoUbicacion.Id));
            parametros.Add(new SqlParameter("@CompraId", ubicacion.CompraID));  
            return parametros;
        }
        public static void CreateUbicacion(Ubicacion ubicacion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
              parametros.Add(new SqlParameter("@Fila", ubicacion.Fila));
            parametros.Add(new SqlParameter("@Asiento", ubicacion.Asiento));
            parametros.Add(new SqlParameter("@SinNumerar", ubicacion.SinNumerar));
            parametros.Add(new SqlParameter("@Precio", ubicacion.Precio));
            parametros.Add(new SqlParameter("@EspecCodigo", ubicacion.EspectaculoId));
            parametros.Add(new SqlParameter("@TipoId", ubicacion.TipoUbicacion.Id));
            parametros.Add(new SqlParameter("@CompraId", ubicacion.CompraID));
            DataBase.WriteInBase("[dbo].[sp.crear_ubicacion]", "SP", parametros);

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

        public static List<Ubicacion> generarUbicaciones(List<Sector> sectoresRegistrados)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            foreach (Sector sector in sectoresRegistrados)
            {
                parametros.Add(new SqlParameter("@ubic_tipo", sector.TipoUbicacion.Id));
                parametros.Add(new SqlParameter("@ubic_precio", sector.Precio));
                parametros.Add(new SqlParameter("@ubic_espec_codigo", sector.Precio));
                DataBase.ejecutarSP("dbo.sp_generar_ubicaciones", parametros);
            }
            return null;
        }

        public static List<Sector> getSectoresDeEspectaculo(Espectaculo espectaculo)
        {
            List<Sector> sectores = new List<Sector>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ubic_espec_codigo", espectaculo.Id));
            string sql = "SELECT COUNT(distinct [Ubic_Fila]) filas, COUNT(distinct [Ubic_Asiento]) asientos, " +
                         "[Ubic_Precio], Ubicaciones.Ubic_Tipo_Cod, Ubic_Tipo_Descr " +
                         "FROM [GD2C2018].[GESTION_DE_GATOS].[Ubicaciones] " +
                         "JOIN [GD2C2018].[GESTION_DE_GATOS].[Ubicaciones_Tipo] " +
                         "ON Ubicaciones.Ubic_Tipo_Cod = Ubicaciones_Tipo.Ubic_Tipo_Cod " +
                         "WHERE Ubic_Espec_Cod = " + espectaculo.Id +
                         " GROUP BY Ubic_Precio, Ubicaciones.Ubic_Tipo_Cod, Ubic_Tipo_Descr";
            SqlDataReader lector = DataBase.GetDataReader(sql, "T", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    sectores.Add(new Sector(
                        Convert.ToInt32(lector[0]),
                        Convert.ToInt32(lector[1]),
                        new TipoUbicacion(Convert.ToInt32(lector[3]), lector[4].ToString()),
                        Convert.ToDouble(lector[2])));
                }
            }
            return sectores;
        }

        public static void crearUbicacionesPorEspectaculo(List<Sector> sectores, List<Espectaculo> espectaculos)
        {
            foreach (Espectaculo espectaculo in espectaculos)
            {
                crearUbicacionesPorEspectaculo(sectores, espectaculo);
            }
        }

        public static void crearUbicacionesPorEspectaculo(List<Sector> sectores, Espectaculo espectaculo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            foreach (Sector sector in sectores)
            {
                parametros.Add(new SqlParameter("@ubic_tipo", sector.TipoUbicacion.Id));
                parametros.Add(new SqlParameter("@ubic_precio", sector.Precio));
                parametros.Add(new SqlParameter("@ubic_espec_codigo", espectaculo.Id));
                parametros.Add(new SqlParameter("@cnt_filas", sector.CantidadFilas));
                parametros.Add(new SqlParameter("@cnt_asientos", sector.CantidadAsientos));
                DataBase.ejecutarSP("sp_crear_ubicaciones", parametros);
                parametros.Clear();
            }
        }

        public static void eliminarSectoresDePublicacion(Espectaculo espectaculo)
        {
            string sql = "DELETE FROM GESTION_DE_GATOS.Ubicaciones WHERE Ubic_Espec_Cod = " + espectaculo.Id;
            DataBase.ejecutarFuncion(sql, new List<SqlParameter>());
        }

        public static void actualizarSectores(List<Sector> getSectores, Espectaculo espectaculo)
        {
            eliminarSectoresDePublicacion(espectaculo);
            crearUbicacionesPorEspectaculo(getSectores, espectaculo);
        }
    }
}
