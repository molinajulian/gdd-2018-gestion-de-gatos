using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
   public class Tarjeta
    {
        private string p1;
        private string Text;
        private string p2;

        public Tarjeta() {  }
        public Tarjeta(string numero, string nombre, DateTime fechavenc, string ccv) 
        {
            Numero = numero;
            Nombre = nombre;
            FechaVencimiento = fechavenc;
            CCV = ccv;
        }

        public Tarjeta(string numero, string banco, DateTime fecha)
        {
            // TODO: Complete member initialization
            Numero = numero;
            Banco = banco;
            FechaVencimiento=fecha;
        }
        public string   Numero { get; set; }
        public string   Nombre { get; set; }
        public string   Banco { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string   CCV { get; set; }
    }
}
