using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public static PublicacionPuntual build(SqlDataReader lector)
        {
            Dictionary<string, int> camposPublicacion = Ordinales.Publicacion;
            return new PublicacionPuntual(
                Convert.ToInt32(lector[camposPublicacion["codigo"]]),
                lector[camposPublicacion["descripcion"]].ToString(),
                GradoRepositorio.ReadGradoFromDb(Convert.ToInt32(lector[camposPublicacion["gradoCodigo"]])),
                EstadoPublicacionRepositorio.ReadEstadoPublicacionFromDb(
                    Convert.ToInt32(lector[camposPublicacion["estadoId"]])),
                EspectaculoRepositorio.ReadEspectaculoFromDb(Convert.ToInt32(lector[camposPublicacion["especCodigo"]])),
                UsuarioRepositorio.buscarUsuario(Convert.ToInt32(lector[camposPublicacion["editor"]])));
        }


        public static PublicacionPuntual buildCompuesta(SqlDataReader lector)
        {
            Dictionary<string, int> camposPublicacionCompuesta = Ordinales.PublicacionCompuesta;
            return new PublicacionPuntual(
                Convert.ToInt32(lector[camposPublicacionCompuesta["pub_codigo"]]),
                lector[camposPublicacionCompuesta["pub_desc"]].ToString(),
                GradoRepositorio.ReadGradoFromDb(Convert.ToInt32(lector[camposPublicacionCompuesta["pub_gradoCodigo"]])),
                EstadoPublicacionRepositorio.ReadEstadoPublicacionFromDb(
                    Convert.ToInt32(lector[camposPublicacionCompuesta["pub_estadoId"]])),
                Espectaculo.buildCompuesto(lector),
                null);
        }
    }
}
