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

        public static Usuario buscarUsuario(int idUsuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idUsuario", idUsuario));
            return Usuario.buildUsuario(DataBase.GetDataReader("[dbo].[sp_buscar_usuario]", "SP", parametros));
        }

        public static Usuario buscarUsuario(string username)
        {
            return Usuario.buildUsuario(
                DataBase.GetDataReader(
                    "SELECT [Usuario_Id],[Usuario_Username],[Usuario_Estado], [Usuario_Primer_Logueo] " +
                    "FROM GESTION_DE_GATOS.Usuarios WHERE [Usuario_Username] = '" + username + "'",
                    "T",
                    new List<SqlParameter>()
                    )
                );
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

        internal Usuario validarIntentosFallidos(string username, string tipoUsuario, int TipoDocumento)
        {
            string query;
            if (tipoUsuario == "C")
            {
                query = "SELECT * FROM GESTION_DE_GATOS.Usuarios u JOIN GESTION_DE_GATOS.Clientes c ON c.Cli_Usuario_Id = u.Usuario_Id WHERE c.Cli_Tipo_Doc_Id =" + TipoDocumento + " and c.Cli_Doc ='"+username+"'";
            }
            else
            {
                if (tipoUsuario == "E")
                {
                    query = "SELECT * FROM GESTION_DE_GATOS.Usuarios u JOIN GESTION_DE_GATOS.Empresas e ON e.Emp_Usuario_Id = u.Usuario_Id WHERE e.Emp_Cuit='" + username+"'";
                }
                else
                {
                    query = "SELECT * FROM GESTION_DE_GATOS.Usuarios where Usuario_Username='"+username+"'";
                }
            }
            SqlDataReader usuario = DataBase.GetDataReader(query,"T",new List<SqlParameter>());
            return usuario.HasRows && usuario.Read() ? new Usuario() { id = usuario.GetInt32(0), username=usuario.GetString(1),isActive = usuario.GetBoolean(3),primerLogueo = usuario.GetBoolean(4),intentosFallidos = usuario.GetInt32(5)} : new Usuario();
        }

        internal void deshabilitar(int idUsuario)
        {
            SqlDataReader usuario = DataBase.GetDataReader("UPDATE GESTION_DE_GATOS.Usuarios SET Usuario_Estado=0 WHERE Usuario_Id ="+idUsuario, "T", new List<SqlParameter>());
        }
    }
}
