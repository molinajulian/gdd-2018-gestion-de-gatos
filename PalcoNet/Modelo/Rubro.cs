using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
   public  class Rubro
    {
        public Rubro(int codigo, string descripcion)
        {
            Codigo = codigo;
            Descripcion = descripcion;
        }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
