using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class EstadoPublicacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool EsPosibleCambio { get; set; }
    }
}
