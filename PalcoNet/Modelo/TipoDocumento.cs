﻿using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class TipoDocumento 
    {

        public TipoDocumento(int id,string descripcion)
        {
            Id=id.ToString();
            Descripcion = descripcion;
        }
        public TipoDocumento(string descripcion)
        {
            Descripcion = descripcion;
        }

        public TipoDocumento()
        {
            // TODO: Complete member initialization
        }
        public string Id { get; set; }
        public string Descripcion { get; set; }


        internal static TipoDocumento buildGetTiposDoc(System.Data.SqlClient.SqlDataReader lector)
        {
            Dictionary<string, int> camposTiposDoc = Ordinales.camposGetTiposDoc;
            return new TipoDocumento(lector.GetInt32(camposTiposDoc["tipos_doc_id"]),
                lector.GetString(camposTiposDoc["tipos_doc_descr"]));
        }
    }
}
