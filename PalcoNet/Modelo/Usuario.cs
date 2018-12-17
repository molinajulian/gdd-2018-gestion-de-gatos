using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using PalcoNet.Repositorios;

namespace PalcoNet.Modelo
{
    public class Usuario
    {
        public int id { get; set; }
        public String username { get; set; }
        public Rol rol { get; set; }
        public Boolean isActive { get; set; }
        public static Usuario Actual { get; set; }
        public Boolean primerLogueo { get; set; }

        public Usuario(int id, String username, Boolean isActive, Boolean primerLogueo = true)
        {
            this.id = id;
            this.username = username;
            this.isActive = isActive;
            this.primerLogueo = primerLogueo;
        }

        public static Usuario buildUsuario(SqlDataReader lector)
        {
            Usuario usuario = null;
            Dictionary<string, int> camposUsuario = Ordinales.camposUsuario;
            if (lector.HasRows)
            {
                lector.Read();
                return new Usuario(
                    lector.GetInt32(camposUsuario["id"]),
                    lector.GetString(camposUsuario["username"]),
                    lector.GetBoolean(camposUsuario["estado"]),
                    lector.GetBoolean(camposUsuario["primer_logueo"]));
            }
            return usuario;
        }

        internal bool isAdmin()
        {
            return rol.nombre.Equals("ADMINISTRATIVO");
        }

        public List<Rol> obtenerRoles()
        {
            return UsuarioRepositorio.getRoles(this);
        }

        public static void inicializarUsuarioActual(Usuario usuario)
        {
            Actual = usuario;
        }
    }
}
