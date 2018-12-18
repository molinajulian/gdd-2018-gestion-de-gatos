using System;
using System.Collections.Generic;
using PalcoNet.Repositorios;

namespace PalcoNet.Modelo
{
    public class PublicacionPuntual
    {
        public int    Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Grado Grado { get; set; }
        public EstadoPublicacion Estado { get; set; }
        public Espectaculo Espectaculo { get; set; }
        public List<Sector> Sectores { get; set; }
        public PublicacionPuntual(int codigo, string descripcion, Grado grado, 
                                    EstadoPublicacion estado, Espectaculo espectaculo)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Grado = grado;
            Estado = estado;
            Espectaculo = espectaculo;
            Sectores = getSectores();
        }

        private List<Sector> getSectores()
        {
            return SectoresRepositorio.getSectoresDeEspectaculo(Espectaculo);
        }
    }
}
