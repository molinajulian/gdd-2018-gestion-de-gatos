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
        public Espectaculo Espectaculo { get; set; }
        public List<Sector> sectores { get; set; }

        public Publicacion()
        {

        }
        public Publicacion(string descripcion, DateTime fechaPublicacion, Grado grado,
            EstadoPublicacion estado, Espectaculo espectaculo, List<Sector> sectores)
        {
            Descripcion = descripcion;
            FechaPublicacion = fechaPublicacion;
            Grado = grado;
            Estado = estado;
            Espectaculo = espectaculo;
            this.sectores = sectores;
        }
    }
}
