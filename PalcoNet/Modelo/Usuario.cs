using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PalcoNet.Modelo;
using System.Security.Cryptography;
using System.Data.SqlClient;
using PalcoNet.Repositorios;

namespace PalcoNet.Modelo
{
    public class Usuario
    {
        public String username { get; set; }
        public String contrasenaCifrada { get; set; } //Se almacena en la instancia solo la version cifrada
        public Rol rol { get; set; }
        public Boolean isActive { get; set; }

        public Usuario(String username, String contrasena, Rol rol, Boolean isActive)
        {
            this.username = username;
            this.contrasenaCifrada = cifrar(contrasena);
            this.rol = rol;
            this.isActive = isActive;
        }

        public static string cifrar(string contrasena)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static Usuario buildUsuario(SqlDataReader lector)
        {
            Usuario usuario = null;
            if (lector.HasRows)
            {
                lector.Read();
                usuario = new Usuario(lector.GetString(0), lector.GetString(1),
                    RolRepositorio.buscarRol(lector.GetString(2)), lector.GetBoolean(3));
            }
            return usuario;

        }
    }
}
