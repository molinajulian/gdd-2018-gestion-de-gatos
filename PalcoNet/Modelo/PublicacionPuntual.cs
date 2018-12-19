using System;
using System.Collections.Generic;
using PalcoNet.Repositorios;

namespace PalcoNet.Modelo
{
    public class PublicacionPuntual
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public Grado Grado { get; set; }
        public EstadoPublicacion Estado { get; set; }
        public Espectaculo Espectaculo { get; set; }
        private List<Sector> Sectores { get; set; }
        public Usuario Editor { get; set; }

        public PublicacionPuntual(int codigo, string descripcion, Grado grado, 
                                    EstadoPublicacion estado, Espectaculo espectaculo,
                                    Usuario editor, List<Sector> sectores=null)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Grado = grado;
            Estado = estado;
            Espectaculo = espectaculo;
            Editor = editor;
            Sectores = sectores;
        }

        public List<Sector> getSectores()
        {
            if (this.Sectores == null)
            {
                Sectores = getSectoresDeBDD();
            }
            return Sectores;
        }

        private List<Sector> getSectoresDeBDD()
        {
            return UbicacionRepositorio.getSectoresDeEspectaculo(Espectaculo);
        }
    }
}
