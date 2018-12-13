using System;

namespace PalcoNet.Modelo
{
    public class Sector
    {
        public int CantidadFilas { get; set; }
        public int CantidadAsientos { get; set; }
        public String Detalle { get; set; }
        public int TipoUbicacion { get; set; }

        public Sector(int cantidadFilas, int cantidadAsientos,
            string detalle, int tipoUbicacion)
        {
            CantidadFilas = cantidadFilas;
            CantidadAsientos = cantidadAsientos;
            Detalle = detalle;
            TipoUbicacion = tipoUbicacion;
        }
    }
}