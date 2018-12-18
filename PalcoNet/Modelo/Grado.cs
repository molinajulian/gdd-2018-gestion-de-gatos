using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class Grado
    {
        public Grado(int codigo, double comision, string descripcion, bool habilitado)
        {
            Id = codigo;
            Comision = comision;
            Descripcion = descripcion;
            Habilitado = habilitado;
        }
        public int Id { get; set; }
        public double Comision { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
    }
}
