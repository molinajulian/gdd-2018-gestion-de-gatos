using System;

namespace PalcoNet.Modelo
{
    public class Sector
    {
        public int CantidadFilas { get; set; }
        public int CantidadAsientos { get; set; }
        public TipoUbicacion TipoUbicacion { get; set; }
        public double Precio { get; set; }

        public Sector(int cantidadFilas, int cantidadAsientos, TipoUbicacion tipoUbicacion, double precio)
        {
            CantidadFilas = cantidadFilas;
            CantidadAsientos = cantidadAsientos;
            TipoUbicacion = tipoUbicacion;
            Precio = precio;
        }

        public void reemplazar(Sector externo)
        {
            CantidadFilas = externo.CantidadFilas;
            CantidadAsientos = externo.CantidadAsientos;
            TipoUbicacion = externo.TipoUbicacion;
            Precio = externo.Precio;
        }
    }
}