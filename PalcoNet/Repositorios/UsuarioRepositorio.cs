using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Modelo;

namespace PalcoNet.Repositorios
{
    public class UsuarioRepositorio
    {

        public void validarUsuario(String username, String contrasenia) 
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            int salida = 1;
            SqlParameter output = new SqlParameter("@salida", salida);
            output.Direction = ParameterDirection.Output;
            parametros.Add(output);
            parametros.Add(new SqlParameter("@user", username));
            parametros.Add(new SqlParameter("@password",contrasenia));
            SqlCommand sqlCommand = DataBase.ejecutarSP("[dbo].[sp_autenticar_usuario]", parametros);
            switch ((int) sqlCommand.Parameters["@salida"].Value)
            {
                case 0:
                    throw new LoginIncorrecto();
                case -1:
                    throw new UsuarioInhabilitadoException(username);
                default:
                    break;
            }
        }

        public Usuario buscarUsuario(String username)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@username", username));
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

    }
}
