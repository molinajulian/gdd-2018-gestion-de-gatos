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
        
        public static Empresa ReadEmpresaFromDb(SqlDataReader reader)
        {
            return new Empresa()
                         {
                        RazonSocial=reader.GetValue(Ordinales.Empresa["razonSocial"]).ToString(),
                        Cuit=reader.GetValue(Ordinales.Empresa["cuit"]).ToString(),
                        Email = reader.GetValue(Ordinales.Empresa["email"]).ToString(),
                        Telefono = reader.GetValue(Ordinales.Empresa["telefono"]).ToString(),
                        Direccion = DireccionRepositorio.ReadDireccionFromDb(reader.GetValue(Ordinales.Empresa["cuit"]).ToString())
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
                    ReadEmpresaFromDb(reader));
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
                    ReadEmpresaFromDb(reader));
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
                    ReadEmpresaFromDb(reader));
            }
            reader.Close();
           
            return empresas;
        }

        public static bool verificaConformacionCuit()
        {
            return true;
        }


        internal static void deshabilitar(string empresa_cuit,string username)
        {
            List<SqlParameter> parametros = DataBase.GenerarParametrosDeleteFromString(empresa_cuit, username);
            DataBase.WriteInBase("[dbo].[eliminarEmpresa]", "SP", parametros);
        }

        internal static Empresa getEmpresa(string cuit)
        {
            throw new NotImplementedException();
        }

        internal static void modificar(Empresa empresa)
        {
            throw new NotImplementedException();
        }

        internal static void agregar(Empresa empresa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@razon_social", empresa.RazonSocial));
            parametros.Add(new SqlParameter("@cuit", empresa.Cuit));
            parametros.Add(new SqlParameter("@mail", empresa.Email));
            parametros.Add(new SqlParameter("@telefono", empresa.Telefono));
            parametros.Add(new SqlParameter("@calle", empresa.Direccion.Calle));
            parametros.Add(new SqlParameter("@nro", empresa.Direccion.Numero));
            parametros.Add(new SqlParameter("@depto", empresa.Direccion.Departamento));
            parametros.Add(new SqlParameter("@localidad", empresa.Direccion.Localidad));
            parametros.Add(new SqlParameter("@piso", empresa.Direccion.Piso));
            parametros.Add(new SqlParameter("@cp", empresa.Direccion.CodPostal));
            DataBase.ejecutarSP("[dbo].[sp_crear_empresa]", parametros);
        }

        internal static void validarEmpresaInexistente(string cuit)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cuit", cuit));
            DataBase.ejecutarSP("sp_validar_empresa_inexistente", parametros);
        }

        internal static bool esEmpresaHabilitada(string empresa_cuit)
        {
            throw new NotImplementedException();
        }

        internal static void deshabilitar(string empresa_cuit)
        {
            throw new NotImplementedException();
        }

        public static List<Empresa> getEmpresas(string razonSocial, string mail, string cuit)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String sql = stringBuilder
                .Append("SELECT Emp_Razon_Social, Emp_Mail, Emp_Tel, Emp_Cuit FROM dbo.GESTION_DE_GATOS.Empresas WHERE ")
                .Append(razonSocial == null ? "" : "Emp_Razon_Social LIKE %" + razonSocial + "% AND")
                .Append(mail == null ? "" : "Emp_Mail LIKE %" + mail + "% AND")
                .Append(cuit == null ? "" : "Emp_Cuit LIKE %" + cuit + "% AND")
                .ToString();
            if (sql.EndsWith("AND"))
            {
                sql = sql.Substring(0, sql.Length - 3);
            }
            List<Empresa> empresas = new List<Empresa>();
            var camposEmpresa = Ordinales.Empresa;
            SqlDataReader reader = DataBase.GetDataReader(sql, "T", new List<SqlParameter>());
            while (reader.Read())
            {
                empresas.Add(new Empresa(reader.GetString("razon_social"), reader.GetString("")));
            }
            reader.Close();
        }
    }
}



