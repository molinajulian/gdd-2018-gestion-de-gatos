using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class Grado
    {
        public Grado(int codigo, double comision, string descripcion)
        {
            Id = codigo;
            Comision = codigo;
            Descripcion = descripcion;
        }

        public int Id { get; set; }
        public int Comision { get; set; }
        public string Descripcion { get; set; }
    }
}
