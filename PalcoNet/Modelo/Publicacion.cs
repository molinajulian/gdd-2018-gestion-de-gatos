using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class Publicacion
    {
        public int    Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Grado Grado { get; set; }
        public EstadoPublicacion Estado { get; set; }
        public List<Espectaculo> Espectaculos { get; set; }
        public List<Sector> Sectores { get; set; }

        public Publicacion()
        {

        }
        public Publicacion(string descripcion, Grado grado,
            EstadoPublicacion estado, List<Espectaculo> espectaculos, List<Sector> sectores)
        {
            Descripcion = descripcion;
            FechaPublicacion = DateTime.Now;
            Grado = grado;
            Estado = estado;
            Espectaculos = espectaculos;
            Sectores = sectores;
        }
    }
}
