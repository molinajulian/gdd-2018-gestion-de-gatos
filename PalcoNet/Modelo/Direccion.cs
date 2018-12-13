using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class Direccion
    {
        public Direccion(string calle, string numero, string departamento,string localidad,string cp,string piso)
        {
            Calle = calle;
            Numero = numero;
            Departamento = departamento;
            Localidad = localidad;
            CodPostal = cp;
            Piso = piso;
        }
        public Direccion(int id, string calle, string numero, string departamento, string localidad, string cp, string piso)
        {
            Id = id;
            Calle = calle;
            Numero = numero;
            Departamento = departamento;
            Localidad = localidad;
            CodPostal = cp;
            Piso = piso;
        }
        public Direccion(){}
        public int Id { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public string CodPostal { get; set; }
        public string Piso { get; set; }

        public override string ToString()
        {
            return Calle + " " + Numero;
        }
    }
}
