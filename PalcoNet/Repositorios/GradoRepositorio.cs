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
                    lector[camposGrado["descripcion"]].ToString(),
                    Convert.ToBoolean(lector[camposGrado["habilitado"]])
                    ));
            }
            lector.Close();
            return grados;
        }
        public static List<Grado> getGrados(string descripcion)
        {
            List<Grado> grados = new List<Grado>();
            Dictionary<string, int> camposGrado = Ordinales.Grado;
            SqlDataReader lector = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Grados WHERE Grado_Descr LIKE ('%" + descripcion + "%')", "T", new List<SqlParameter>());
            while (lector.HasRows && lector.Read())
            {
                grados.Add(new Grado(
                    Convert.ToInt32(lector[camposGrado["codigo"]].ToString()),
                    Convert.ToDouble(lector[camposGrado["comision"]]),
                    lector[camposGrado["descripcion"]].ToString(),
                    Convert.ToBoolean(lector[camposGrado["habilitado"]])
                    ));
            }
            lector.Close();
            return grados;
        }
        public static Grado ReadGradoFromDb(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            Dictionary<string, int> camposGrado = Ordinales.Grado;
            SqlCommand cmb = DataBase.ejecutarFuncion("SLECT * FROM GESTION_DE_GATOS.Grados WHERE Grado_Cod = @id", parametros);
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
        internal static bool cambiarEstado(Grado seleccionada)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id",seleccionada.Id));
            parametros.Add(new SqlParameter("@estado_final",seleccionada.Habilitado ? 0 : 1));
            DataBase.ejecutarSP("[dbo].[sp_cambiar_estado_grado]", parametros);
            return !seleccionada.Habilitado;
        }

        internal static void actualizar(Grado grado)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", grado.Id));
            parametros.Add(new SqlParameter("@habilitado", grado.Habilitado ? 0 : 1));
            parametros.Add(new SqlParameter("@comision", grado.Comision));
            parametros.Add(new SqlParameter("@descripcion", grado.Descripcion));
            DataBase.ejecutarSP("[dbo].[sp_modificar_grado]", parametros);
        }
        internal static Grado ReadGradoFromDb(int p)
        {
            throw new NotImplementedException();
        }

    }
}
