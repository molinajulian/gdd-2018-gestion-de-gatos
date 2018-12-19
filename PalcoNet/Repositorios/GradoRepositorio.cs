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
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            Dictionary<string, int> camposGrado = Ordinales.Grado;
            SqlCommand cmb = DataBase.ejecutarFuncion("SELECT * FROM GESTION_DE_GATOS.Grados WHERE Grado_Cod = @id", parametros);
            SqlDataReader lector = cmb.ExecuteReader();
            if (lector.Read())
            {
                return new Grado(
                    Convert.ToInt32(lector[camposGrado["codigo"]].ToString()),
                    Convert.ToDouble(lector[camposGrado["comision"]]),
                    lector[camposGrado["descripcion"]].ToString());
            }
            return null;
        }

        public static void agregar(float grado,string descripcion)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@grado", grado));
            parametros.Add(new SqlParameter("@descripcion", descripcion.ToUpper()));
            DataBase.ejecutarSP("[dbo].[sp_crear_grado]", parametros);
        }
    }
}
