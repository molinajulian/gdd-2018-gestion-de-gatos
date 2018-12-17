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
    }
}

