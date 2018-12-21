using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PalcoNet.Modelo
{
   public  class Factura
    {
        private Factura(long numero, double total, DateTime fecha, string cuit)
        {
            Numero = numero;
            Total = total;
            Fecha = fecha;
            EmpresaCuit = cuit;
        }

        public long Numero { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
        public string EmpresaCuit { get; set; }

        public static Factura build(SqlDataReader lector)
        {
            Dictionary<string, int> camposFactura = Ordinales.Factura;
            return new Factura(
                Convert.ToInt64(lector[camposFactura["Fact_Num"]]),
                Convert.ToDouble(lector[camposFactura["Fact_Total"]]),
                Convert.ToDateTime(lector[camposFactura["Fact_Fecha"]]),
                lector[camposFactura["Fact_Empresa_Cuit"]].ToString()
                );
        }
    }
}
