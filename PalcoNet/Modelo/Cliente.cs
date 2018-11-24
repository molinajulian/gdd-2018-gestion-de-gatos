using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    class Cliente:Rol
    {
        public string NombreCliente { get; set; }
        public string Apellido { get; set; }
        public string TipoDeDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Cuil { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Direccion Direccion { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public Tarjeta Tarjeta { get; set; }
        public bool Activo { get; set; }
    }
}
