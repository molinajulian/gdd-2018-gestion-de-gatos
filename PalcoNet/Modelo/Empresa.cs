using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Repositorios;

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
            string telefono, Direccion direccion, bool habilitada)
        {
            RazonSocial = razonSocial;
            Cuit = cuit;
            Email = email;
            Telefono = telefono;
            Direccion = direccion;
            Habilitada = habilitada;
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
        }

        public static Empresa buildEmrpesa(SqlDataReader lector)
        {
            Usuario usuario = null;
            Dictionary<string, int> camposEmpresa = Ordinales.Empresa;
                return new Empresa(
                    lector[camposEmpresa["razonSocial"]].ToString(),
                    lector[camposEmpresa["cuit"]].ToString(),
                    lector[camposEmpresa["email"]].ToString(),
                    lector[camposEmpresa["telefono"]].ToString(),
                    DireccionRepositorio.ReadDireccionFromDb(
                        Convert.ToString(lector.GetInt32(camposEmpresa["domicilioId"]))),
                    ((int) lector[camposEmpresa["habilitada"]]) == 1 ? true : false);
        }

        public class EmpresaNoEncontradaException : Exception
        {
            public EmpresaNoEncontradaException() : base("No se encontro la empresa buscada")
            {

            }
        }
    }
}
