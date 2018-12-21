using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class FacturaRepositorio
    {
        public static Factura getUltimaFactura()
        {
            SqlDataReader lector = DataBase.GetDataReader("SELECT TOP 1 FROM GESTION_DE_GATOS.Facturas ORDER BY Fact_Num DESC", "T", new List<SqlParameter>());
            return Factura.build(lector);
        }
    }
}
