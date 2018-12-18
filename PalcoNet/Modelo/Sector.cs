using System;

namespace PalcoNet.Modelo
{
    public class Sector
    {
        private int p1;
        private int p2;
        private string p3;
        private double p4;

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

        public Sector(int p1, int p2, string p3, Modelo.TipoUbicacion tipoUbicacion, double p4)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.TipoUbicacion = tipoUbicacion;
            this.p4 = p4;
        }
        
    }
}