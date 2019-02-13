using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class ItemFacturaRepositorio
    {
        public static List<SqlParameter> GenerarParametrosItemFactura(ItemFactura itemFactura)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Numero", itemFactura.FacturaId));
            parametros.Add(new SqlParameter("@Descuento", itemFactura.Cantidad));
            parametros.Add(new SqlParameter("@Tipo", itemFactura.Monto));


            return parametros;
        }
        public static void CreateItemFactura(ItemFactura itemFactura)
        {
            List<SqlParameter> parametros = GenerarParametrosItemFactura(itemFactura);
            DataBase.WriteInBase("IngresaritemFacturas", "SP", parametros);

        }


        public static void UpdateItemFactura(ItemFactura itemFactura)
        {
            List<SqlParameter> parametros = GenerarParametrosItemFactura(itemFactura);
            DataBase.WriteInBase("UpdateitemFactura", "SP", parametros);

        }


        public static void DeleteItemFactura(ItemFactura itemFactura)
        {
            List<SqlParameter> parametros = GenerarParametrosItemFactura(itemFactura);
            DataBase.WriteInBase("DeleteitemFactura", "SP", parametros);

        }

        public static List<ItemFactura> ReadItemFacturaFromDb(int id)
        {
            var itemsFactura = new List<ItemFactura>();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from itemFactura g where g.Item_Fact_Num  = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                itemsFactura.Add( new ItemFactura()
                {   Id= (int)reader.GetValue(Ordinales.ItemFactura["itemFact_Id"]),
                    FacturaId = (int)reader.GetValue(Ordinales.ItemFactura["itemFact_FactId"]),
                    Cantidad = (int)reader.GetValue(Ordinales.ItemFactura["itemFact_Cantidad"]),
                    Monto = (double)reader.GetValue(Ordinales.ItemFactura["itemFact_Monto"])

                });

            }
            return itemsFactura;

        }
    }
}
