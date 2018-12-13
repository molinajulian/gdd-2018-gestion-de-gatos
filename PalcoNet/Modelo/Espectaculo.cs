using System;
using System.Collections.Generic;

namespace PalcoNet.Modelo
{
  public  class Espectaculo
    {
        public int Id { get; set; }
        public List<Ubicacion> Ubicaciones { get; set; }
        public string Descripcion { get; set; }
        public TimeSpan Hora{ get; set; }
        public Rubro Rubro { get; set; }
        public Empresa Empresa { get; set; }

        public Espectaculo(List<Ubicacion> ubicaciones, string descripcion, Rubro rubro, Empresa empresa)
        {
            Ubicaciones = ubicaciones;
            Descripcion = descripcion;
            Rubro = rubro;
            Empresa = empresa;
        }
    }
}
