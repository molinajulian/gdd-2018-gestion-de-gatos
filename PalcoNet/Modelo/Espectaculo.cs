using System;
using System.Collections.Generic;

namespace PalcoNet.Modelo
{
  public  class Espectaculo
    {
        public int Id { get; set; }
        public List<Ubicacion> Ubicaciones { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public Rubro Rubro { get; set; }
        public Empresa Empresa { get; set; }
        public DateTime FechaOcurrencia;

        public Espectaculo(string descripcion,
                            DateTime fechaOcurrencia, DateTime fechaVencimiento, Rubro rubro, Empresa empresa)
        {
            Ubicaciones = new List<Ubicacion>();
            Descripcion = descripcion;
            FechaOcurrencia = fechaOcurrencia;
            FechaVencimiento = fechaVencimiento;
            Rubro = rubro;
            Empresa = empresa;
        }
    }
}
