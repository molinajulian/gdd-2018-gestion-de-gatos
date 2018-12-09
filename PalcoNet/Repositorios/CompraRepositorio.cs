using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class CompraRepositorio
    {
        public static List<SqlParameter> GenerarParametrosCompra(Compra compra)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Descripcion", compra.Cliente.TipoDeDocumento.Descripcion));
            parametros.Add(new SqlParameter("@CompraId", compra.Publicacion.Codigo));
            parametros.Add(new SqlParameter("@Tipo", compra.Cliente.NumeroDocumento));
            parametros.Add(new SqlParameter("@Tipo", compra.Fecha));


            return parametros;
        }
        public static void CreateCompra(Compra compra)
        {
            List<SqlParameter> parametros = GenerarParametrosCompra(compra);
            DataBase.WriteInBase("Ingresarcompras", "SP", parametros);

        }


        public static void UpdateCompra(Compra compra)
        {
            List<SqlParameter> parametros = GenerarParametrosCompra(compra);
            DataBase.WriteInBase("Updatecompra", "SP", parametros);

        }


        public static void DeleteCompra(Compra compra)
        {
            List<SqlParameter> parametros = GenerarParametrosCompra(compra);
            DataBase.WriteInBase("Deletecompra", "SP", parametros);

        }

        public static Compra ReadCompraFromDb(int id)
        {
            var compra = new Compra();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from compra g where g.compra_cod = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                compra = new Compra()
                {
                    Id = (int)reader.GetValue(Ordinales.Compra["Compra_Id"]),
                    Publicacion = PublicacionRepositorio.GetPublicacionById((int)Ordinales.Compra["Compra_Publicacion_Id"]),
                    Cliente = ClienteRepositorio.GetClienteByDNI((int)reader.GetValue(Ordinales.Compra["Compra_Cliente_Documento"])).First(),
                    Fecha= (DateTime)reader.GetValue(Ordinales.Compra["Fecha_Id"])
                };

            }
            return compra;

        }
    }
}
