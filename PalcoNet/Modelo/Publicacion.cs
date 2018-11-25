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
        public List<Ubicacion> Ubicaciones { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public DateTime FechaFuncion { get; set; }
        public Rubro Rubro { get; set; }
        public Grado Grado { get; set; }
        public  Direccion DireccionEspectaculo { get; set; }
        public EstadoPublicacion Estado { get; set; }
    }
}
