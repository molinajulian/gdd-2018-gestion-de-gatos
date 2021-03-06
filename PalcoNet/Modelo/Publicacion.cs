﻿using System;
using System.Collections.Generic;
using PalcoNet.Repositorios;

namespace PalcoNet.Modelo
{
    public class Publicacion
    {
        public int    Codigo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Grado Grado { get; set; }
        public EstadoPublicacion Estado { get; set; }
        public List<Espectaculo> Espectaculos { get; set; }
        public List<Sector> Sectores { get; set; }
        public Usuario Editor { get; set; }
        public Publicacion(int codigo, string descripcion, Grado grado, 
                           EstadoPublicacion estado, 
                           List<Espectaculo> espectaculos, List<Sector> sectoresRegistrados,
                           Usuario editor)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Grado = grado;
            Estado = estado;
            Espectaculos = espectaculos;
            Sectores = sectoresRegistrados;
            Editor = editor;
            FechaPublicacion = DataBase.GetFechaHoy();
        }
    }
}
