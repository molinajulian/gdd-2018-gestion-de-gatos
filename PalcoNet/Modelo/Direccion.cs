using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    class Direccion
    {
        public Direccion(string calle, string numero, string departamento,string localidad,string cp)
        {
            Calle = calle;
            Numero = numero;
            Departamento = departamento;
            Localidad = localidad;
            CodPostal = cp;
        }
        public Direccion(){}
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public string CodPostal { get; set; }
        public string Piso { get; set; }
    }
}
