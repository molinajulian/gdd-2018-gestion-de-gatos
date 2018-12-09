using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class TiposDocumento 
    {

        public TiposDocumento(int id,string descripcion)
        {
            Id=id.ToString();
            Descripcion = descripcion;
        }
        public string Id { get; set; }
        public string Descripcion { get; set; }


        internal static TiposDocumento buildGetTiposDoc(System.Data.SqlClient.SqlDataReader lector)
        {
            Dictionary<string, int> camposTiposDoc = Ordinales.camposGetTiposDoc;
            return new TiposDocumento(lector.GetInt32(camposTiposDoc["tipos_doc_id"]), lector.GetString(camposTiposDoc["tipos_doc_descr"]));
        }
    }
}
