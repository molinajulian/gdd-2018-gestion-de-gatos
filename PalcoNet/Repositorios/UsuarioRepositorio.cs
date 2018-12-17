using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Modelo;
using PalcoNet.Repositorios;

namespace PalcoNet.Repositorios
{
    public class UsuarioRepositorio
    {

        public int validarUsuario(String username, String contrasenia, String tipoUsuario, int TipoDocumento) 
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            int salida = 1;
            SqlParameter output = new SqlParameter("@salida", salida);
            output.Direction = ParameterDirection.Output;
            parametros.Add(output);
            parametros.Add(new SqlParameter("@user", username));
            parametros.Add(new SqlParameter("@password",contrasenia));
            parametros.Add(new SqlParameter("@tipoUsuario", tipoUsuario));
            parametros.Add(new SqlParameter("@tipoDocumento", TipoDocumento));
            DataBase.ejecutarSP("[dbo].[sp_autenticar_usuario]", parametros);
            return Convert.ToInt32(output.Value);
        }

        public Usuario buscarUsuario(int idUsuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idUsuario", idUsuario));
            return Usuario.buildUsuario(DataBase.GetDataReader("[dbo].[sp_buscar_usuario]", "SP", parametros));
        }


        public class LoginException : Exception {
            public LoginException(): base() { }
            public LoginException(String message) : base(message){ }
        }
        public class LoginIncorrecto : LoginException
        {
            public LoginIncorrecto(): base("Usuario o contraseña invalidos") { }
        }

        public class UsuarioInhabilitadoException : LoginException
        {
            public UsuarioInhabilitadoException(String username)
                : base(String.Format("El ususername {0} se encuentra inhabilitado", username)) { }
        }


        internal static List<Rol> getRoles(Usuario user)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@user_id", user.id));
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_roles_usuario]", "SP", parametros);
            List<Rol> roles = new List<Rol>();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Rol rol = Rol.buildRol(lector);
                    roles.Add(rol);
                }
            }
            lector.Close();
            return roles;
        }

        internal static void cambiarContraseña(int idUsuario,string nuevaContraseña)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idUsuario", idUsuario));
            parametros.Add(new SqlParameter("@contraseña", nuevaContraseña));
            parametros.Add(new SqlParameter("@tamaño", nuevaContraseña.Length));
            DataBase.ejecutarSP("[dbo].[sp_cambiar_contraseña]", parametros);
        }
    }
}
