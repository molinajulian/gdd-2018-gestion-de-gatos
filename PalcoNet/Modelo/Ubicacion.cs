using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PalcoNet.Repositorios;

namespace PalcoNet.Modelo
{
   public class Ubicacion
   {
       private Ubicacion(int id, char fila, int asiento, int especId, TipoUbicacion tipoUbicacion, int compraId)
       {
           Id = id;
           Fila = fila;
           Asiento = asiento;
           EspectaculoId = especId;
           TipoUbicacion = tipoUbicacion;
           CompraID = compraId;
       }

        public int Id{ get; set; }
        public char Fila { get; set; }
        public int Asiento { get; set; }
        public double Precio { get; set; }
        public bool SinNumerar { get; set; }
        public int EspectaculoId { get; set; }
        public int CompraID { get; set; }
        public TipoUbicacion TipoUbicacion { get; set; }

        public static Ubicacion build(SqlDataReader lector)
        {
            Dictionary<string, int> camposUbicacion = Ordinales.Ubicacion;
            return new Ubicacion(
                 Convert.ToInt32(lector[camposUbicacion["id"]]),
                 Convert.ToChar(lector[camposUbicacion["fila"]].ToString()),
                 Convert.ToInt32(lector[camposUbicacion["asiento"]]),
                 Convert.ToInt32(lector[camposUbicacion["espec_cod"]]),
                 TipoUbicacionRepositorio.ReadTipoUbicacionFromDb(Convert.ToInt32(lector[camposUbicacion["tipo_cod"]])),
                 lector[camposUbicacion["compra_id"]].Equals("{}") ? -1 : Convert.ToInt32(lector[camposUbicacion["compra_id"]])
                );
        }
   }
}
