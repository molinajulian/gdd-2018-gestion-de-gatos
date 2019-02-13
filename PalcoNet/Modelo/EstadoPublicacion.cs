using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class EstadoPublicacion
    {
        public EstadoPublicacion(int id, string descripcion, bool editable)
        {
            Id = id;
            Descripcion = descripcion;
            Editable = editable; 
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Editable { get; set; }
    }
}
