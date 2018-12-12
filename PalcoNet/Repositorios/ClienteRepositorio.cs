using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PalcoNet.Repositorios
{
    class ClienteRepositorio
    {
        internal static Cliente getCliente(int doc,string descripcionTipoDoc)
        {

            Cliente cli = new Cliente();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@doc", doc));
            parametros.Add(new SqlParameter("@descripcionTipoDoc", descripcionTipoDoc));
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_get_cliente]", "SP", parametros);
            while (lector.Read())
            {
                cli = Cliente.buildGetCliente(lector);
            }
            lector.Close();
            return cli;
        }
        internal static List<Cliente> getClientes()
        {
            var clientes = new List<Cliente>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_get_clientes]", "SP", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Cliente cli = Cliente.buildGetClientes(lector);
                    clientes.Add(cli);
                }
                lector.Close();
            }
            return clientes;
        }

        internal static void eliminarCliente(string tipoDocDescr,string doc)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipoDocDescr", tipoDocDescr));
            parametros.Add(new SqlParameter("@doc", Convert.ToInt32(doc)));
            DataBase.GetDataReader("[dbo].[sp_eliminar_cliente]", "SP", parametros);
        }

        internal static void habilitarCliente(int p)
        {
            throw new NotImplementedException();
        }

        internal static bool esClienteExistente(int tipoDoc,decimal documento,string cuil = "")
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipoDoc", tipoDoc));
            parametros.Add(new SqlParameter("@doc", documento));
            parametros.Add(new SqlParameter("@cuil", cuil));
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_existe_cliente]", "SP", parametros);
            int cantidad = 0 ;
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    cantidad = Cliente.buildClienteExistente(lector);
                }
                lector.Close();
            }
            return cantidad > 0 ? true : false;
        }

        internal static void modificarCliente(Cliente cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipoDoc", Convert.ToInt32(cliente.TipoDeDocumento.Id)));
            parametros.Add(new SqlParameter("@doc", Convert.ToDecimal(cliente.NumeroDocumento)));
            parametros.Add(new SqlParameter("@cuil", cliente.Cuil));
            parametros.Add(new SqlParameter("@nombre", cliente.NombreCliente));
            parametros.Add(new SqlParameter("@apellido", cliente.Apellido));
            parametros.Add(new SqlParameter("@fechaNac", cliente.FechaDeNacimiento));
            parametros.Add(new SqlParameter("@mail", cliente.Email));
            parametros.Add(new SqlParameter("@telefono", Convert.ToDecimal(cliente.Telefono)));
            parametros.Add(new SqlParameter("@calle", cliente.Direccion.Calle));
            parametros.Add(new SqlParameter("@nro", Convert.ToDecimal(cliente.Direccion.Numero)));
            parametros.Add(new SqlParameter("@depto", cliente.Direccion.Departamento));
            parametros.Add(new SqlParameter("@localidad", cliente.Direccion.Localidad));
            parametros.Add(new SqlParameter("@piso", Convert.ToDecimal(cliente.Direccion.Piso)));
            parametros.Add(new SqlParameter("@cp", cliente.Direccion.CodPostal));
            parametros.Add(new SqlParameter("@habilitado", cliente.Habilitado));
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_modificar_cliente]", "SP", parametros);
        }

        internal static string agregar(Cliente cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@tipoDoc", Convert.ToInt32(cliente.TipoDeDocumento.Id)));
            parametros.Add(new SqlParameter("@doc", Convert.ToDecimal(cliente.NumeroDocumento)));
            parametros.Add(new SqlParameter("@cuil", cliente.Cuil));
            parametros.Add(new SqlParameter("@nombre", cliente.NombreCliente));
            parametros.Add(new SqlParameter("@apellido", cliente.Apellido));
            parametros.Add(new SqlParameter("@fechaNac", cliente.FechaDeNacimiento));
            parametros.Add(new SqlParameter("@fechaCreacion", cliente.FechaDeCreacion));
            parametros.Add(new SqlParameter("@mail", cliente.Email));
            parametros.Add(new SqlParameter("@telefono", Convert.ToInt32(cliente.Telefono)));
            parametros.Add(new SqlParameter("@calle", cliente.Direccion.Calle));
            parametros.Add(new SqlParameter("@nro", Convert.ToDecimal(cliente.Direccion.Numero)));
            parametros.Add(new SqlParameter("@depto", cliente.Direccion.Departamento));
            parametros.Add(new SqlParameter("@localidad", cliente.Direccion.Localidad));
            parametros.Add(new SqlParameter("@piso", cliente.Direccion.Piso));
            parametros.Add(new SqlParameter("@cp", cliente.Direccion.CodPostal));
            SqlParameter output = new SqlParameter("@salida", 0);
            output.Direction = ParameterDirection.Output;
            parametros.Add(output);
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_crear_cliente]", "SP", parametros);
            string id = output.Value.ToString();
            return id;
        }

        internal static bool esClienteExistenteMail(string p)
        {
            throw new NotImplementedException();
        }

        private static void añadirParametroDoc(string doc,ref string query)
        {
            query+="where c.Cli_Doc = "+ Convert.ToDecimal(doc)+" ";
        }
        private static void añadirParametroNombre(string nombre, ref string query)
        {
            string subQuery = "c.Cli_Nombre like('%"+nombre+"%')";
            query = query.Contains("where")? query+"and "+subQuery : query+"where "+subQuery;
        }
        private static void añadirParametroApellido(string apellido, ref string query)
        {
            string subQuery = "c.Cli_Apellido like('%"+apellido+"%')";
            query = query.Contains("where") ? query + "and " + subQuery : query + "where " + subQuery;
        }
        private static void añadirParametroEmail(string email, ref string query)
        {
            string subQuery = "c.Cli_Mail like('%"+email+"%') ";
            query = query.Contains("where") ? query + "and " + subQuery : query + "where " + subQuery;
        }
        internal static List<Cliente> getClientes(string doc, string nombre, string apellido, string email)
        {
            var clientes = new List<Cliente>();
            var parametros = new List<SqlParameter>();
            string query = "SELECT td.Tipo_Doc_Descr,c.Cli_Doc,isnull(c.Cli_Cuil,'') as cuil, c.Cli_Nombre,c.Cli_Apellido,c.Cli_Mail,d.Dom_Calle,d.Dom_Nro_Calle,d.Dom_Depto,d.Dom_Piso,isnull(d.Dom_Localidad,'') as localidad,d.Dom_Cod_Postal,c.Cli_Habilitado FROM GESTION_DE_GATOS.Clientes c JOIN GESTION_DE_GATOS.Tipos_Doc td ON td.Tipo_Doc_Id = c.Cli_Tipo_Doc_Id JOIN GESTION_DE_GATOS.Domicilios d  ON d.Dom_Id = c.Cli_Domicilio_Id ";
            if (!string.IsNullOrEmpty(doc)) añadirParametroDoc(doc,ref query);
            if (!string.IsNullOrEmpty(nombre)) añadirParametroNombre(nombre, ref query);
            if (!string.IsNullOrEmpty(apellido)) añadirParametroApellido(apellido, ref query);
            if (!string.IsNullOrEmpty(email)) añadirParametroEmail(email,ref query);
            var resultadoQuery = DataBase.ejecutarFuncion(query, parametros);
            SqlDataReader lector = resultadoQuery.ExecuteReader();
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Cliente cli = Cliente.buildGetClientes(lector);
                    clientes.Add(cli);
                }
                lector.Close();
            }
            return clientes;
        }

        internal static List<TiposDocumento> getTiposDoc()
        {
            var tipos = new List<TiposDocumento>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_get_tipos_doc]", "SP", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    TiposDocumento tipo = TiposDocumento.buildGetTiposDoc(lector);
                    tipos.Add(tipo);
                }
                lector.Close();
            }
            return tipos;
        }
    }
}
