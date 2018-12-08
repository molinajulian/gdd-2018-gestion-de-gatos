using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PalcoNet.Modelo
{
    class Espectaculo
    {
        public int Id { get; set; }
        public List<Ubicacion> Ubicaciones { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora{ get; set; }
        public Rubro Rubro { get; set; }
        public Empresa Empresa { get; set; }
         
    }
}
