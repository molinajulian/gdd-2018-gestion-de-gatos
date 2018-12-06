using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PalcoNet.Repositorios;
using PalcoNet.Modelo;


namespace PalcoNet.Repositorios
{
    class EmpresasRepositorio
    {  
        public static List<SqlParameter> GenerarParametrosEmpresa(Empresa empresa,string username)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@dni", empresa.Cuit));
            parametros.Add(new SqlParameter("@apellido", empresa.RazonSocial));
            parametros.Add(new SqlParameter("@mail", empresa.Email));
            parametros.Add(new SqlParameter("@telefono", empresa.Telefono));
            parametros.Add(new SqlParameter("@localidad", empresa.Direccion.Localidad));
            parametros.Add(new SqlParameter("@ciudad",empresa.Ciudad));
            parametros.Add(new SqlParameter("@username", username));
            return parametros;
        }
        public static void CreateEmpresa(Empresa empresa,string username)
        {
            List<SqlParameter> parametros = GenerarParametrosEmpresa(empresa,username);
            DataBase.WriteInBase("Ingresarempresas", "SP", parametros);

        }

        
        public static void UpdateEmpresa(Empresa empresa,string username)
        {
            List<SqlParameter> parametros = GenerarParametrosEmpresa(empresa,username);
            DataBase.WriteInBase("Updateempresa", "SP", parametros);

        }

        
        public static void DeleteEmpresa(Empresa empresa,string username)
        {
            List<SqlParameter> parametros = GenerarParametrosEmpresa(empresa,username);
            DataBase.WriteInBase("Deleteempresa", "SP", parametros);

        }
        
        public static Empresa ReadempresaFromDb(SqlDataReader reader)
        {
            return new Empresa()
                         {
                        RazonSocial=reader.GetValue(Ordinales.Empresa["razonSocial"]).ToString(),
                        Ciudad=reader.GetValue(Ordinales.Empresa["ciudad"]).ToString(),
                        Cuit=reader.GetValue(Ordinales.Empresa["cuit"]).ToString(),
                        Email = reader.GetValue(Ordinales.Empresa["email"]).ToString(),
                        Telefono = reader.GetValue(Ordinales.Empresa["telefono"]).ToString()

                         };
        }
       
        public static List<Empresa> GetempresaByRazonSocial(string unaRazon)
        {
            var empresas = new List<Empresa>();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Razon", unaRazon));
            var query = DataBase.ejecutarFuncion("Select * from empresa e where e.empr_razon like('@Razon%')", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                empresas.Add(
                    ReadempresaFromDb(reader));
            }
            reader.Close();
            return empresas;
        }
        public static List<Empresa> GetempresaByCuit(string unNumero)
        {
            var empresas = new List<Empresa>();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@numero", unNumero));
            var query = DataBase.ejecutarFuncion("Select * from empresa e where e.empr_cuit like('@numero%')", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                empresas.Add(
                    ReadempresaFromDb(reader));
            }
            reader.Close();
            return empresas;
        }
        public static List<Empresa> GetEmpresasByEmail(string unEmail)
        {
            var empresas = new List<Empresa>();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@email", unEmail));
            var query = DataBase.ejecutarFuncion("Select * from empresa e where e.empr_email like('@email%')", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                empresas.Add(
                    ReadempresaFromDb(reader));
            }
            reader.Close();
            return empresas;
        }

        public static bool verificaConformacionCuit()
        {
            return true;
        }


        internal static void deshabilitar(string empresa_cuit)
        {
            throw new NotImplementedException();
        }
    }
}



