using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class Rol
    {
        public int id { get; set;}
        public string nombre { get; set; }
        public List<Funcionalidad> Funcionalidades { get; set; }
        public bool Habilitado { get; set; }

        public Rol()
        {
            this.id = -1;
            this.nombre = "";
        }

        public Rol(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
        public Rol(int id, string nombre,bool habilitado)
        {
            this.id = id;
            this.nombre = nombre;
            this.Habilitado = habilitado;
        }

        public static Rol buildRol(SqlDataReader lector)
        {
            Dictionary<string, int> camposRol = Ordinales.camposRol;
            return new Rol(lector.GetInt32(camposRol["id"]), lector.GetString(camposRol["nombre"]));
        }
        public static Rol buildRolListado(SqlDataReader lector)
        {
            Dictionary<string, int> camposRol = Ordinales.camposRolListado;
            return new Rol(lector.GetInt32(camposRol["id"]), lector.GetString(camposRol["nombre"]),lector.GetBoolean(camposRol["habilitado"]));
        }
    }
}
