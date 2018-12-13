using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class Domicilio
    {
        public Domicilio(string calle, string numero, string departamento,string localidad,string cp,string piso)
        {
            Id = -1;
            Calle = calle;
            Numero = numero;
            Departamento = departamento;
            Localidad = localidad;
            CodPostal = cp;
            Piso = piso;
        }
        public Domicilio(int id, string calle, string numero, string departamento, string localidad, string cp, string piso)
        {
            Id = id;
            Calle = calle;
            Numero = numero;
            Departamento = departamento;
            Localidad = localidad;
            CodPostal = cp;
            Piso = piso;
        }

        public Domicilio()
        {
            Id = -1;
        }
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

        public static Domicilio buildDomicilio(SqlDataReader lector)
        {
            Dictionary<string, int> camposDomicilio = Ordinales.Domicilio;
            return new Domicilio(
                Convert.ToInt32(lector[camposDomicilio["id"]]),
                lector[camposDomicilio["calle"]].ToString(),
                lector[camposDomicilio["numero"]].ToString(),
                lector[camposDomicilio["departamento"]].ToString(),
                lector[camposDomicilio["localidad"]].ToString(),
                lector[camposDomicilio["codPostal"]].ToString(),
                lector[camposDomicilio["piso"]].ToString()
            );
        }
    }
}
