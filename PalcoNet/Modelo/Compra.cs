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
        public PublicacionPuntual Publicacion { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
    }
  public class CompraListado
  {
      public Decimal Total { get; set; }
      public DateTime FechaCompra { get; set; }
      public DateTime FechaEspectaculo { get; set; }
      public string EspectaculoDescripción { get; set; }
      public string RubroDescripción { get; set; }
  }
}
