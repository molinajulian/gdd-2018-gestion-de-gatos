using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    class Empresa
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
        }
    }
}
