﻿using System;
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
            parametros.Add(new SqlParameter("@nro", domicilio.Numero));
            parametros.Add(new SqlParameter("@depto", domicilio.Departamento));
            parametros.Add(new SqlParameter("@piso", domicilio.Piso));
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
            parametros.Add(new SqlParameter("@nro", numero));
            DataBase.ejecutarSP("[dbo].[sp_buscar_domicilios]", parametros);
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_get_domicilios]", "SP", parametros);
            List<Domicilio> domicilios = new List<Domicilio>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    domicilios.Add(Domicilio.buildDomicilio(lector));
                }
                lector.Close();
            }
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
            parametros.Add(new SqlParameter("@id", domicilio.Id));
            parametros.Add(new SqlParameter("@localidad", domicilio.Localidad));
            parametros.Add(new SqlParameter("@calle", domicilio.Calle));
            parametros.Add(new SqlParameter("@nro", domicilio.Numero));
            parametros.Add(new SqlParameter("@depto", domicilio.Departamento));
            parametros.Add(new SqlParameter("@piso", domicilio.Piso));
            parametros.Add(new SqlParameter("@cp", domicilio.CodPostal));
            DataBase.ejecutarSP("[dbo].[sp_actualizar_domicilio]", parametros);
        }
    }
}