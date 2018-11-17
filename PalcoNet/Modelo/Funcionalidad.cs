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
        public int Codigo { get; set; }
        public string Detalle { get; set; }

        public static Funcionalidad buildFuncionalidad(SqlDataReader lector)
        {
            Funcionalidad funcionalidad = new Funcionalidad();
            funcionalidad.Codigo = (int)lector["func_nombre"];
            funcionalidad.Detalle = (String)lector["func_detalle"];
            return funcionalidad;
        }
    }
}
