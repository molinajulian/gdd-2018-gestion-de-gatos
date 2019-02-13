using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class Funcionalidad
    {
        public int id { get; set; }
        public string detalle { get; set; }


        public Funcionalidad(int id, string detalle)
        {
            this.id = id;
            this.detalle = detalle;
        }

        public static Funcionalidad buildFuncionalidad(SqlDataReader lector)
        {
            Dictionary<string, int> camposFuncionalidad = Ordinales.camposFuncionalidad;
            return new Funcionalidad(
                lector.GetInt32(camposFuncionalidad["id"]),
                lector.GetString(camposFuncionalidad["descripcion"]));
        }
    }
}
