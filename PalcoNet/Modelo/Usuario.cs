using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PalcoNet.Modelo;
using System.Security.Cryptography;

namespace PalcoNet.Modelo
{
    public class Usuario
    {
        public String User { get; set; }
        public String Password { get; set; }
        public Rol RolUsuario { get; set; }

        public Usuario(String Nombre, String contrasena)
        {
            this.User = Nombre;
            this.Password = contrasena;
        }
        public string Cifrar(string unString)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(unString));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
