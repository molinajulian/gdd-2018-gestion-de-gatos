using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    class Rol
    {
        public string Nombre { get; set; }
        public List<Funcionalidad> Funcionalidades { get; set; }
        public bool Habilitado { get; set; } 
   
    }
}
