using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
   public  class Ubicacion
   {
       public int Id{ get; set; }
        public char Fila { get; set; }
        public int Asiento { get; set; }
        public string TipoUbicacion { get; set; }
    }
}
