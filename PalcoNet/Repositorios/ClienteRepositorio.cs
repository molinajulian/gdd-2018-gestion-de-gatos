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
        public static List<SqlParameter> buildCliente(Cliente cliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@dni", cliente.Cuil));
            parametros.Add(new SqlParameter("@apellido", cliente.Apellido));
            parametros.Add(new SqlParameter("@nombre", cliente.Nombre));
            parametros.Add(new SqlParameter("@fecha_nac", cliente.FechaDeNacimiento));
            parametros.Add(new SqlParameter("@mail", cliente.Email));
            parametros.Add(new SqlParameter("@habilitado", cliente.Activo));
            parametros.Add(new SqlParameter("@telefono", cliente.Telefono));
            parametros.Add(new SqlParameter("@localidad", cliente.Direccion.Localidad));
            parametros.Add(new SqlParameter("@cp", cliente.Direccion.CodPostal));
            parametros.Add(new SqlParameter("@calle", cliente.Direccion.Calle));
            parametros.Add(new SqlParameter("@numero",cliente.Direccion.Numero));        
            parametros.Add(new SqlParameter("@departamento",cliente.Direccion.Departamento));        
            parametros.Add(new SqlParameter("@tipoDocumento",cliente.TipoDeDocumento));  
            parametros.Add(new SqlParameter("@documento",cliente.NumeroDocumento));        
            parametros.Add(new SqlParameter("@tarjetaNombre",cliente.Tarjeta.Nombre)); 
            parametros.Add(new SqlParameter("@tarjetaNumero",cliente.Tarjeta.Numero));        
            parametros.Add(new SqlParameter("@tarjetaCCV",cliente.Tarjeta.CCV));        
            parametros.Add(new SqlParameter("@tarjetaFechaVencimiento",cliente.Tarjeta.FechaVencimiento));        
            return parametros;
        }
        public static SqlDataReader obtenerClienteByNombre(string unNombre)
        {
           
            SqlCommand query = new SqlCommand(
                                "SELECT  * FROM Cliente c  where  c.nombre like('"+unNombre+"%') ",DataBase.GetConnection());
            
            
            SqlDataReader reader = query.ExecuteReader();
        
            while (reader.Read())
            { 
                
            }
            return reader;
        }
    }
}
