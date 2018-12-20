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
            /*var parametros = new List<SqlParameter>();
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

            }*/
            return compra;

        }
        public static List<CompraListado> GetHistorialCompra(int tipoDoc,int doc,int pagina)
        {
            List<CompraListado> historial = new List<CompraListado>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipoDoc", tipoDoc));
            parametros.Add(new SqlParameter("@doc", doc));
            parametros.Add(new SqlParameter("@flag", 2));
            parametros.Add(new SqlParameter("@pagina", pagina));
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_historial_cliente]", "SP", parametros);
            while (lector.Read())
            {
                historial.Add(new CompraListado()
                {
                    Total = lector.GetDecimal(Ordinales.camposHistorialCliente["total"]),
                    FechaCompra = lector.GetDateTime(Ordinales.camposHistorialCliente["fecha_compra"]),
                    FechaEspectaculo = lector.GetDateTime(Ordinales.camposHistorialCliente["fecha_espectaculo"]),
                    EspectaculoDescripción = lector.GetString(Ordinales.camposHistorialCliente["descripcion_espectaculo"]),
                    RubroDescripción = lector.GetString(Ordinales.camposHistorialCliente["tipo_espectaculo"])
                });
            }

            return historial;
        }

        public static void realizarCompra(List<Ubicacion> ubicacionesAComprar, PublicacionPuntual publicacionElegida,
                                            Tarjeta tarjetaElegida)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@public_id", publicacionElegida.Codigo));
            parametros.Add(new SqlParameter("@cli_doc_num", Cliente.Actual.NumeroDocumento));
            parametros.Add(new SqlParameter("@cli_doc_tipo", Cliente.Actual.TipoDeDocumento.Id));
            parametros.Add(new SqlParameter("@fecha", DateTime.Now));
            parametros.Add(new SqlParameter("@cli_tarj_cred_id", tarjetaElegida.Id));
            DataBase.ejecutarSP("[dbo].[sp_realizar_compra]", parametros);
        }

        internal static int GetCantidadHistorial(int tipoDoc, int doc,int pagina=1)
        {

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipoDoc", tipoDoc));
            parametros.Add(new SqlParameter("@doc", doc));
            parametros.Add(new SqlParameter("@flag", 1));
            parametros.Add(new SqlParameter("@pagina", pagina));
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_historial_cliente]","SP", parametros);
            int cantidad=-1;
            while (lector.HasRows && lector.Read())
            {
                cantidad = lector.GetInt32(0);
            }
            return cantidad;
        }
    }
}
