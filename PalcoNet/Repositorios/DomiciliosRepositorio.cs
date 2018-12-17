using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PalcoNet.Modelo;

namespace PalcoNet.Repositorios
{
    public class DomiciliosRepositorio
    {
        public static int agregar(Domicilio domicilio)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@localidad", domicilio.Localidad));
            parametros.Add(new SqlParameter("@calle", domicilio.Calle));
            parametros.Add(new SqlParameter("@nro", Convert.ToDecimal(domicilio.Numero)));
            parametros.Add(new SqlParameter("@depto", domicilio.Departamento));
            parametros.Add(new SqlParameter("@piso", string.IsNullOrEmpty(domicilio.Piso) ? Convert.ToDecimal(0) : Convert.ToDecimal(domicilio.Piso)));
            parametros.Add(new SqlParameter("@cp", domicilio.CodPostal));
            SqlParameter output = new SqlParameter("@dom_id", -1);
            output.Direction = ParameterDirection.Output;
            parametros.Add(output);
            SqlCommand sqlCommand = DataBase.ejecutarSP("[dbo].[sp_agregar_domicilio]", parametros);
            return Convert.ToInt32(sqlCommand.Parameters["@dom_id"].Value);
        }

        public static List<Domicilio> getDomicilios(string calle, string numero)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@calle", calle));
            parametros.Add(new SqlParameter("@nro", !numero.Equals("") ? Convert.ToInt32(numero) : 0));
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_get_domicilios]", "SP", parametros);
            List<Domicilio> domicilios = new List<Domicilio>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    domicilios.Add(Domicilio.buildDomicilio(lector));
                }
            }
            lector.Close();
            return domicilios;
        }

        public static void eliminar(Domicilio domicilio)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@localidad", domicilio.Localidad));
            parametros.Add(new SqlParameter("@calle", domicilio.Calle));
            parametros.Add(new SqlParameter("@nro", domicilio.Numero));
            parametros.Add(new SqlParameter("@depto", domicilio.Departamento));
            parametros.Add(new SqlParameter("@piso", domicilio.Piso));
            parametros.Add(new SqlParameter("@cp", domicilio.CodPostal));
            DataBase.ejecutarSP("[dbo].[sp_eliminar_domicilio]", parametros);

        }

        public static void actualizar(Domicilio domicilio)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@dom_id", domicilio.Id));
            parametros.Add(new SqlParameter("@localidad", domicilio.Localidad));
            parametros.Add(new SqlParameter("@calle", domicilio.Calle));
            parametros.Add(new SqlParameter("@nro", domicilio.Numero));
            parametros.Add(new SqlParameter("@depto", domicilio.Departamento));
            parametros.Add(new SqlParameter("@piso", domicilio.Piso));
            parametros.Add(new SqlParameter("@cp", domicilio.CodPostal));
            DataBase.ejecutarSP("[dbo].[sp_actualizar_domicilio]", parametros);
        }

        public static Domicilio getDomicilio(string dom_id)
        {
            String sql = "SELECT * FROM GESTION_DE_GATOS.Domicilios WHERE Dom_Id = " + dom_id;
            SqlDataReader lector = DataBase.GetDataReader(sql, "T", new List<SqlParameter>());
            Domicilio domicilio = null;
            if (lector.HasRows && lector.Read())
            {
                domicilio = Domicilio.buildDomicilio(lector);
                lector.Close();
                return domicilio;
            }
            lector.Close();
            throw new DomicilioNoEncontradoException(dom_id);
        }

        public class DomicilioNoEncontradoException : Exception
        {
            public DomicilioNoEncontradoException(String id) : base("No se encontro un domicilio con el Id : " + id)
            {

            }
        }
    }
}