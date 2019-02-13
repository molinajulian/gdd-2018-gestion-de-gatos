using PalcoNet.Modelo;
using PalcoNet.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PalcoNet.Repositorios
{
    class RolRepositorio
    {

        public static List<Funcionalidad> buscarFuncionalidadesPorRol(Rol rol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@rol_id", rol.id));
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_funcionalidades_por_rol]", "SP", parametros);
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    funcionalidades.Add(Funcionalidad.buildFuncionalidad(lector));
                }
            }
            lector.Close();
            return funcionalidades;
        }
        public static void agregar(Rol rol, List<Funcionalidad> funcionalidades)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", rol.nombre));
            SqlParameter output = new SqlParameter("@id", -1);
            output.Direction = ParameterDirection.Output;
            parametros.Add(output);
            SqlCommand sqlCommand = DataBase.ejecutarSP("[dbo].[sp_crear_rol]", parametros);
            int idRol = Convert.ToInt32(sqlCommand.Parameters["@id"].Value);
            foreach (Funcionalidad fun in funcionalidades)
            {
                DataBase.GetDataReader("INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES("+idRol+","+fun.id+")", "T", new List<SqlParameter>());
            }
        }

        public static List<Rol> getRoles(int modo=0)
        {
            List<Rol> roles = new List<Rol>();
            StringBuilder stringBuilder = new StringBuilder();
            String sql = stringBuilder
                .Append("SELECT * FROM GESTION_DE_GATOS.ROLES WHERE (Rol_Nombre = 'CLIENTE' or Rol_nombre = 'EMPRESA') and Rol_Estado=1")
                .ToString();
            if (modo == 1) sql = sql.Replace(" WHERE (Rol_Nombre = 'CLIENTE' or Rol_nombre = 'EMPRESA') and Rol_Estado=1", "");
            SqlDataReader lector = DataBase.GetDataReader(sql, "T", new List<SqlParameter>());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol rol = modo == 0 ? Rol.buildRol(lector) : Rol.buildRolListado(lector);
                    roles.Add(rol);
                }
            }
            lector.Close();
            return roles;
        }

        public static List<Funcionalidad> getFuncionalidades(Rol rol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            parametros.Add(new SqlParameter("@rol_id", DBNull.Value));
            SqlDataReader lector = DataBase.GetDataReader("dbo.sp_funcionalidades_por_rol", "SP", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    funcionalidades.Add(Funcionalidad.buildFuncionalidad(lector));
                }
            }
            lector.Close();
            return funcionalidades;
        }
        public static List<Rol> getRoles(string descripcion)
        {
            List<Rol> roles = new List<Rol>();
            SqlDataReader lector = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Roles WHERE Rol_Nombre LIKE ('%" + descripcion + "%')", "T", new List<SqlParameter>());
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol rol =Rol.buildRolListado(lector);
                    roles.Add(rol);
                }
            }
            lector.Close();
            return roles;
        }

        internal static bool cambiarEstado(Rol seleccionada)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", seleccionada.id));
            parametros.Add(new SqlParameter("@estado_final", seleccionada.Habilitado ? 0 : 1));
            DataBase.ejecutarSP("[dbo].[sp_cambiar_estado_rol]", parametros);
            return !seleccionada.Habilitado;
        }


        internal static void modificar(Rol rol,List<Funcionalidad> funcionalidades)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id",rol.id));
            parametros.Add(new SqlParameter("@nombre", rol.nombre));
            parametros.Add(new SqlParameter("@habilitado", rol.Habilitado ? 1: 0));
            DataBase.ejecutarSP("[dbo].[sp_modificar_rol]", parametros);
            DataBase.GetDataReader("DELETE FROM GESTION_DE_GATOS.Funcionalidad_Por_Rol WHERE Rol_Id ="+rol.id.ToString(), "T", new List<SqlParameter>());
            foreach (Funcionalidad fun in funcionalidades)
            {
                DataBase.GetDataReader("INSERT INTO GESTION_DE_GATOS.Funcionalidad_Por_Rol (Rol_Id,Func_Id) VALUES(" + rol.id + "," + fun.id + ")", "T", new List<SqlParameter>());
            }
        }
    }
}
