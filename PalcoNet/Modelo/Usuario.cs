using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using PalcoNet.Repositorios;

namespace PalcoNet.Modelo
{
    public class Usuario
    {
        public int id { get; set; }
        public String username { get; set; }
        public Rol rol { get; set; }
        public Boolean isActive { get; set; }

        public Usuario(int id, String username, Boolean isActive)
        {
            this.id = id;
            this.username = username;
            this.isActive = isActive;
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
                    lector.GetBoolean(camposUsuario["estado"]));
            }
            return usuario;
        }

        internal bool isAdmin()
        {
            return rol.nombre.Equals("ADMINISTRATIVO");
        }
    }
}
