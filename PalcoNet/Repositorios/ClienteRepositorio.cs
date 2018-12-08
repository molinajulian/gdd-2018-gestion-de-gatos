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
        public static List<SqlParameter> GenerarParametrosCliente(Cliente cliente,string username)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@dni", cliente.Cuil));
            parametros.Add(new SqlParameter("@apellido", cliente.Apellido));
            parametros.Add(new SqlParameter("@nombre", cliente.NombreCliente));
            parametros.Add(new SqlParameter("@fecha_nac", cliente.FechaDeNacimiento));
            parametros.Add(new SqlParameter("@mail", cliente.Email));
            parametros.Add(new SqlParameter("@telefono", cliente.Telefono));
            parametros.Add(new SqlParameter("@tipoDocumento",cliente.TipoDeDocumento));  
            parametros.Add(new SqlParameter("@documento",cliente.NumeroDocumento));        
            parametros.Add(new SqlParameter("@username", username));
            return parametros;
        }
        public static void CreateCliente(Cliente cliente,string username)
        {
            List<SqlParameter> parametros = GenerarParametrosCliente(cliente,username);
            DataBase.WriteInBase("IngresarClientes", "SP", parametros);

        }
        public static void UpdateCliente(Cliente cliente, string username)
        {
            List<SqlParameter> parametros = GenerarParametrosCliente(cliente,username);
            DataBase.WriteInBase("UpdateCliente", "SP", parametros);

        }
        public static void DeleteCliente(Cliente cliente, string username)
        {
            List<SqlParameter> parametros = GenerarParametrosCliente(cliente,username);
            DataBase.WriteInBase("DeleteCliente", "SP", parametros);

        }
        
        public static Cliente ReadClienteFromDb(SqlDataReader reader)
        {
            /*return new Cliente()
                         {
                             NombreCliente = reader.GetValue(Ordinales.Cliente["nombre"]).ToString(),
                             Apellido = reader.GetValue(Ordinales.Cliente["apellido"]).ToString(),
                             TipoDeDocumento = reader.GetValue(Ordinales.Cliente["tipoDocumento"]).ToString(),
                             NumeroDocumento = reader.GetValue(Ordinales.Cliente["numeroDocumento"]).ToString(),
                             Cuil = reader.GetValue(Ordinales.Cliente["cuil"]).ToString(),
                             Email = reader.GetValue(Ordinales.Cliente["email"]).ToString(),
                             Telefono = reader.GetValue(Ordinales.Cliente["telefono"]).ToString(),
                             FechaDeNacimiento = (DateTime)reader.GetValue(Ordinales.Cliente["fechaNacimiento"]),
                             FechaDeCreacion = (DateTime)reader.GetValue(Ordinales.Cliente["fechaCreacion"]),
                             Direccion = DireccionRepositorio.ReadDireccionFromDb(reader.GetValue(Ordinales.Cliente["cuil"]).ToString()),
                             Tarjeta = TarjetaRepositorio.GetTarjetasById(reader.GetValue(Ordinales.Cliente["cuil"]).ToString()).First()
                             
                            };*/
            return new Cliente();
        }
        public static List<Cliente> GetClienteByNombre(string unNombre)
        {  var clientes = new List<Cliente>();
           var parametros= new List<SqlParameter>();
           parametros.Add(new SqlParameter("@Nombre",unNombre));
           var query =DataBase.ejecutarFuncion("Select * from cliente c where c.clie_nombre like('@Nombre%')",parametros);
           SqlDataReader reader = query.ExecuteReader();
           while (reader.Read())
           {
               clientes.Add(ReadClienteFromDb(reader)
                   );
           }
           reader.Close();
            return clientes;
        }
        public static List<Cliente> GetClienteByApellido(string unApellido)
        {
            var clientes = new List<Cliente>();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Apellido", unApellido));
            var query = DataBase.ejecutarFuncion("Select * from cliente c where c.clie_apellido like('@Apellido%')", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                clientes.Add(
                    ReadClienteFromDb(reader));
            }
            reader.Close();
           
            return clientes;
        }
        public static List<Cliente> GetClienteByDNI(string unNumero)
        {
            var clientes = new List<Cliente>();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@numero", unNumero));
            var query = DataBase.ejecutarFuncion("Select * from cliente c where c.clie_dni like('@numero%')", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                clientes.Add(
                    ReadClienteFromDb(reader));
            }
            reader.Close();
            return clientes;
        }
        public static List<Cliente> GetClienteByEmail(string unEmail)
        {
            var clientes = new List<Cliente>();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@email", unEmail));
            var query = DataBase.ejecutarFuncion("Select * from cliente c where c.clie_email like('@email%')", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                clientes.Add(
                    ReadClienteFromDb(reader));
            }
            reader.Close();
            return clientes;
        }


        internal static List<Cliente> getClientes(int limit,int offset)
        {
            var clientes = new List<Cliente>();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@limit", limit));
            parametros.Add(new SqlParameter("@offset", offset));
            SqlDataReader lector = DataBase.GetDataReader("[dbo].[sp_get_clientes]", "SP", parametros);
            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    Cliente rol = Cliente.buildGetClientes(lector);
                    clientes.Add(rol);
                }
                lector.Close();
            }
            return clientes;
        }

        internal static void eliminarCliente(int p)
        {
            throw new NotImplementedException();
        }

        internal static void habilitarCliente(int p)
        {
            throw new NotImplementedException();
        }

        internal static bool esClienteExistente(int p)
        {
            throw new NotImplementedException();
        }

        internal static void modificarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        internal static void agregar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        internal static bool esClienteExistenteMail(string p)
        {
            throw new NotImplementedException();
        }

        internal static List<Cliente> getClientes(string p1, string p2, string p3)
        {
            throw new NotImplementedException();
        }
    }
}
