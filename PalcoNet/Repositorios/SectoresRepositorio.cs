using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PalcoNet.Repositorios
{
    class SectoresRepositorio
    {
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
    }
}
