using PalcoNet.Modelo;
using PalcoNet.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Palconet.Repositorios
{
    class RolesRepositorio
    {
        public static bool esRolExistente(String nombre)
        {
            SqlDataReader lector = buscarFilasRol(nombre);
            return lector.HasRows;
        }

        public static SqlDataReader buscarFilasRol(String nombre)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", nombre));
            return DataBase.GetDataReader("404_NOT_FOUND.SP_BUSCAR_ROL", "SP", parametros);
        }

        public static void agregar(Rol rol, List<String> funcionalidades)
        {
            List<SqlParameter> parametros_rol = new List<SqlParameter>();
            List<SqlParameter> parametros_funcionalidades_rol = new List<SqlParameter>();

            parametros_rol.Add(new SqlParameter("@nombre", rol.Nombre));
            parametros_rol.Add(new SqlParameter("@habilitado", rol.Habilitado));
            DataBase.WriteInBase("404_NOT_FOUND.SP_AGREGAR_ROL", "SP", parametros_rol);
            
            foreach (String funcionalidad in funcionalidades)
            {
                parametros_funcionalidades_rol.Add(new SqlParameter("@rol", rol.Nombre));
                parametros_funcionalidades_rol.Add(new SqlParameter("@funcionalidad", funcionalidad));
                DataBase.WriteInBase("404_NOT_FOUND.SP_AGREGAR_ROL_FUNCIONALIDAD", "SP", parametros_funcionalidades_rol);
                parametros_funcionalidades_rol.Clear();
            }
        }

        public static List<Rol> getRoles(String nombre)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            List<Rol> roles = new List<Rol>();

            if (String.IsNullOrWhiteSpace(nombre)) parametros.Add(new SqlParameter("@nombre", DBNull.Value));
            else parametros.Add(new SqlParameter("@nombre", nombre));

            SqlDataReader lector = DataBase.GetDataReader("404_NOT_FOUND.SP_BUSCAR_ROL", "SP", parametros);

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol rol = buildRol(lector);
                    roles.Add(rol);
                }
                lector.Close();
            }
            return roles;
        }

        public static List<String> getFuncionalidades(Rol rol)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            List<String> funcionalidades = new List<String>();
            if (rol==null) parametros.Add(new SqlParameter("@rol_id", DBNull.Value));
            else parametros.Add(new SqlParameter("@rol_id", rol.Nombre));
            SqlDataReader lector = DataBase.GetDataReader("404_NOT_FOUND.SP_BUSCAR_ROL_FUNCIONALIDADES", "SP", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    String funcionalidad = lector["func_nombre"].ToString();
                    funcionalidades.Add(funcionalidad);
                }
                lector.Close();
            }
            else 
                return null;
            return funcionalidades;
        }

        public static Rol buildRol(SqlDataReader lector)
        {
            Rol rol = new Rol();
            Dictionary<string, int> camposRol = Ordinales.CamposRol;
            rol.Nombre = lector.GetString(camposRol["nombre"]);
            return rol;
        }

        public static void deshabilitar(String nombre)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", nombre));
            DataBase.WriteInBase("404_NOT_FOUND.SP_DESHABILITAR_ROL", "SP", parametros);
        }

        public static void modificarRol(Rol rol, List<String> funcionalidades)
        {
            List<SqlParameter> parametros_rol = new List<SqlParameter>();
            List<SqlParameter> parametros_funcionalidades_rol = new List<SqlParameter>();
            parametros_rol.Add(new SqlParameter("@nombre", rol.Nombre));
            parametros_rol.Add(new SqlParameter("@habilitado", rol.Habilitado));
            DataBase.WriteInBase("404_NOT_FOUND.SP_MODIFICAR_ROL", "SP", parametros_rol);
            foreach (String funcionalidad in funcionalidades)
            {
                parametros_funcionalidades_rol.Add(new SqlParameter("@rol", rol.Nombre));
                parametros_funcionalidades_rol.Add(new SqlParameter("@funcionalidad", funcionalidad));
                DataBase.WriteInBase("404_NOT_FOUND.SP_AGREGAR_ROL_FUNCIONALIDAD", "SP", parametros_funcionalidades_rol);
                parametros_funcionalidades_rol.Clear();
            }
        }

        public static bool tieneFuncionalidad(int rol_nombre, String funcionalidad)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@rol_nombre", rol_nombre));
            parametros.Add(new SqlParameter("@funcionalidad", funcionalidad));
            SqlDataReader lector = DataBase.GetDataReader("404_NOT_FOUND.SP_TIENE_FUNCIONALIDAD", "SP", parametros);
            return lector.HasRows;
        }
    }
}
