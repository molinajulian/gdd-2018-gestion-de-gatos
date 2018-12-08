using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    class Publicacion
    {
        public int    Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Grado Grado { get; set; }
        public EstadoPublicacion Estado { get; set; }
        public Espectaculo Espectaculo { get; set; }
    }
}
