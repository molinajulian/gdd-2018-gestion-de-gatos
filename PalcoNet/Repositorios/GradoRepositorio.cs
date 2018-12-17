using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PalcoNet.Repositorios
{
    class GradoRepositorio
    {

        public static List<Grado> getGrados()
        {
            List<Grado> grados = new List<Grado>();
            Dictionary<string, int> camposGrado = Ordinales.Grado;
            SqlDataReader lector = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Grados", "T", new List<SqlParameter>());
            while (lector.HasRows && lector.Read())
            {
                grados.Add(new Grado(
                    Convert.ToInt32(lector[camposGrado["codigo"]].ToString()),
                    Convert.ToDouble(lector[camposGrado["comision"]]),
                    lector[camposGrado["descripcion"]].ToString()));
            }
            lector.Close();
            return grados;
        }

        public static Grado ReadGradoFromDb(int id)
        {
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            Dictionary<string, int> camposGrado = Ordinales.Grado;
            var query = DataBase.ejecutarFuncion("Select top 1 * from grado g where g.grado_cod = @id", parametros);
            SqlDataReader lector = query.ExecuteReader();
            if (lector.Read())
            {
                return new Grado(
                    Convert.ToInt32(lector[camposGrado["codigo"]].ToString()),
                    Convert.ToDouble(lector[camposGrado["comision"]]),
                    lector[camposGrado["descripcion"]].ToString());

            }
            return null;

        }
    }
}
