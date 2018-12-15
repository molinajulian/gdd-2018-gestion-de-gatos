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
            SqlParameter output = new SqlParameter("@existencias", 0);
            output.Direction = ParameterDirection.Output;
            parametros.Add(output);
            SqlCommand sqlCommand = DataBase.ejecutarSP("[dbo].[sp_existe_cliente]", parametros);
            return Convert.ToInt32(sqlCommand.Parameters["@existencias"].Value) > 0;
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
            parametros.Add(new SqlParameter("@calle", cliente.Domicilio.Calle));
            parametros.Add(new SqlParameter("@nro", Convert.ToDecimal(cliente.Domicilio.Numero)));
            parametros.Add(new SqlParameter("@depto", cliente.Domicilio.Departamento));
            parametros.Add(new SqlParameter("@localidad", cliente.Domicilio.Localidad));
            parametros.Add(new SqlParameter("@piso", Convert.ToDecimal(cliente.Domicilio.Piso)));
            parametros.Add(new SqlParameter("@cp", cliente.Domicilio.CodPostal));
            parametros.Add(new SqlParameter("@habilitado", cliente.Habilitado));
            DataBase.ejecutarSP("[dbo].[sp_modificar_cliente]", parametros);
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
            parametros.Add(new SqlParameter("@dom_id", cliente.Domicilio.Id));
            parametros.Add(new SqlParameter("@mail", cliente.Email));
            parametros.Add(new SqlParameter("@telefono", cliente.Telefono));
            SqlParameter output = new SqlParameter("@cli_id", -1);
            output.Direction = ParameterDirection.Output;
            parametros.Add(output);
            SqlCommand cmd = DataBase.ejecutarSP("[dbo].[sp_crear_cliente]", parametros);
            return cmd.Parameters["@cli_id"].Value.ToString();
        }

        public static List<Cliente> getClientes(String nombre, String apellido, String numero_documento, String email)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String sql = stringBuilder
                .Append("SELECT * FROM GESTION_DE_GATOS.Clientes WHERE ")
                .Append("Cli_Nombre LIKE ('%" + nombre + "%') AND ")
                .Append("Cli_Apellido LIKE ('%" + apellido+ "%') AND ")
                .Append("Cli_Mail LIKE ('%" + email + "%') ")
                .Append(!numero_documento.Equals("") ? ("AND Cli_Doc = " + numero_documento) : "")
                .ToString();
            List<Cliente> clientes = new List<Cliente>();
            SqlDataReader lector = DataBase.GetDataReader(sql, "T", new List<SqlParameter>());
            while (lector.Read())
            {
                clientes.Add(Cliente.build(lector));
            }
            lector.Close();
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

        public static TiposDocumento getTipoDoc(int tipoDeDocumentoId)
        {
            String sql = "SELECT [Tipo_Doc_Id] ,[Tipo_Doc_Descr] FROM [GESTION_DE_GATOS].[Tipos_Doc]" +
                         " WHERE Tipo_Doc_Id = " + tipoDeDocumentoId;
            SqlDataReader lector = DataBase.GetDataReader(sql, "T", new List<SqlParameter>());
            if(lector.HasRows && lector.Read())
            {
                TiposDocumento tipoDoc = TiposDocumento.buildGetTiposDoc(lector);
                lector.Close();
                return tipoDoc;
            }
            throw new TipoDocNoEncontradoException(tipoDeDocumentoId);
        }

        public class TipoDocNoEncontradoException : Exception
        {
            public TipoDocNoEncontradoException(int id) : base("No se encontro un tipo de documento con id : " + id)
            {

            }
        }
    }
}
