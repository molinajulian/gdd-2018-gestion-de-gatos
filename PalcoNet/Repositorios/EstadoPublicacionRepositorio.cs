using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    public class EstadoPublicacionRepositorio
    {

        public static List<EstadoPublicacion> getEstados()
        {
            List<EstadoPublicacion> estados = new List<EstadoPublicacion>();
            var parametros = new List<SqlParameter>();
            var query = DataBase.ejecutarFuncion("SELECT * FROM GESTION_DE_GATOS.Publicaciones_Estado", new List<SqlParameter>());
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                estados.Add(new EstadoPublicacion(
                        Convert.ToInt32(reader[Ordinales.EstadoPublicacion["id"]]),
                        reader[Ordinales.EstadoPublicacion["descripcion"]].ToString(),
                        Convert.ToInt32(reader[Ordinales.EstadoPublicacion["editable"]]) == 1 ? true : false));
            }
            return estados;
        }

        public static EstadoPublicacion ReadEstadoPublicacionFromDb(int id)
        {
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from GESTION_DE_GATOS.Publicaciones_Estado e where e.Public_Est_Id = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            {
                return new EstadoPublicacion(
                    Convert.ToInt32(reader[Ordinales.EstadoPublicacion["id"]]),
                    reader[Ordinales.EstadoPublicacion["descripcion"]].ToString(),
                    Convert.ToInt32(reader[Ordinales.EstadoPublicacion["editable"]]) == 1 ? true : false);
            }
            return null;
        }
    }
}

