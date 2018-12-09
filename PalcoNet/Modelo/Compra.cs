using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
  public  class Compra
    {
        public int Id { get; set; }
        public Publicacion Publicacion { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
    }
}
