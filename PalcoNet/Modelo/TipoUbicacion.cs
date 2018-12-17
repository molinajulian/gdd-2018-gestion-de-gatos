using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PalcoNet.Modelo
{
    public class TipoUbicacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoUbicacion(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }

        public static TipoUbicacion build(SqlDataReader lector)
        {
            Dictionary<string, int> camposTipo = Ordinales.TipoUbicacion;
            return new TipoUbicacion(Convert.ToInt32(lector[camposTipo["Ubic_Tipo_Codigo"]]), 
                lector[camposTipo["Ubic_Tipo_Descr"]].ToString());
        }
    }

}