using System;

namespace PalcoNet.Modelo
{
    public class Sector
    {
        public int CantidadFilas { get; set; }
        public int CantidadAsientos { get; set; }
        public String Detalle { get; set; }
        public TipoUbicacion TipoUbicacion { get; set; }
        public double Precio { get; set; }

        public Sector(int cantidadFilas, int cantidadAsientos,
            string detalle, TipoUbicacion tipoUbicacion, double precio)
        {
            CantidadFilas = cantidadFilas;
            CantidadAsientos = cantidadAsientos;
            Detalle = detalle;
            TipoUbicacion = tipoUbicacion;
            Precio = precio;
        }
        
    }
}