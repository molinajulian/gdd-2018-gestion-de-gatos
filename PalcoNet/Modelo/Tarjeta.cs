using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    class Tarjeta
    {   public Tarjeta(string numero, string nombre, DateTime fechavenc, string ccv) 
        {
            Numero = numero;
            Nombre = nombre;
            FechaVencimiento = fechavenc;
            CCV = ccv;
        }
        public string   Numero { get; set; }
        public string   Nombre { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string   CCV { get; set; }
    }
}
