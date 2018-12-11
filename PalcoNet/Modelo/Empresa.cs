using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class Empresa
    {
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Direccion Direccion { get; set; }
        public bool Habilitada { get; set; }

        public Empresa()
        {
            Habilitada = true;
        }

        public Empresa(string razonSocial, string cuit, string email, 
            string telefono, Direccion direccion)
        {
            RazonSocial = razonSocial;
            Cuit = cuit;
            Email = email;
            Telefono = telefono;
            Direccion = direccion;
            Habilitada = true;
        }public static Empresa buildEmrpesa(SqlDataReader lector)
        {
            Usuario usuario = null;
            Dictionary<string, int> camposEmpresa = Ordinales.Empresa;
            if (lector.HasRows)
            {
                lector.Read();
                return new Empresa(
                    lector.GetString(camposEmpresa["razon_social"]),
                    lector.GetString(camposEmpresa["cuit"]),
                    lector.GetString(camposEmpresa["email"]),
                    lector.GetString(camposEmpresa["telefono"]),
                    null);
            }
        }
    }
}
