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
        public static List<SqlParameter> GenerarParametrosFactura(Factura factura)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@MetodoDePago", factura.MetodoPago));
            parametros.Add(new SqlParameter("@Total", factura.Total));
            parametros.Add(new SqlParameter("@Fecha", factura.Fecha));
            parametros.Add(new SqlParameter("@EmpresaId", factura.EmpresaId));
            parametros.Add(new SqlParameter("@Fecha", factura.Fecha));
            foreach (var item in factura.Items)
            {
                parametros.AddRange(ItemFacturaRepositorio.GenerarParametrosItemFactura(item));

            }


            return parametros;
        }
        public static void CreateFactura(Factura factura)
        {
            List<SqlParameter> parametros = GenerarParametrosFactura(factura);
            DataBase.WriteInBase("Ingresarfacturas", "SP", parametros);

        }


        public static void UpdateFactura(Factura factura)
        {
            List<SqlParameter> parametros = GenerarParametrosFactura(factura);
            DataBase.WriteInBase("Updatefactura", "SP", parametros);

        }


        public static void DeleteFactura(Factura factura)
        {
            List<SqlParameter> parametros = GenerarParametrosFactura(factura);
            DataBase.WriteInBase("Deletefactura", "SP", parametros);

        }

        public static Factura ReadFacturaFromDb(int id)
        {
            var factura = new Factura();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from factura g where g.factura_cod = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                factura = new Factura()
                {
                    Id = (int)reader.GetValue(Ordinales.Factura["Fact_Id"]),
                    MetodoPago = (string)reader.GetValue(Ordinales.Factura["Fact_Metodo_Pago"]),
                    Total = (double)reader.GetValue(Ordinales.Factura["Fact_Total"]),
                    Fecha=(DateTime)reader.GetValue(Ordinales.Factura["Fact_Fecha"]),
                    Empresa=EmpresasRepositorio.getEmpresa((string)reader.GetValue(Ordinales.Factura["Fact_Emoresa_Cuit"])),
                };
                factura.EmpresaId = factura.Empresa.Cuit;
                factura.Items = ItemFacturaRepositorio.ReadItemFacturaFromDb(factura.Id);
            }
            return factura;

        }
    }
}
