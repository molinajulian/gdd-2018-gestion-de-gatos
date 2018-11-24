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
            parametros.Add(new SqlParameter("@nombre", cliente.NombreCliente));
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
        public static List<Cliente> obtenerClienteByNombre(string unNombre)
        {  var clientes = new List<Cliente>();
           var parametros= new List<SqlParameter>();
           parametros.Add(new SqlParameter("@Nombre",unNombre));
           var query =DataBase.ejecutarFuncion("Select * from cliente c where nombre like('@Nombre%')",parametros);
           SqlDataReader reader = query.ExecuteReader();
            var ClieDict=Ordinales.Cliente;
           while (reader.Read())
           {
               clientes.Add(
                   new Cliente() 
                     {
                     NombreCliente=reader.GetValue(Ordinales.Cliente["nombre"]).ToString(),
                     Apellido=reader.GetValue(Ordinales.Cliente["apellido"]).ToString(),
                     TipoDeDocumento=reader.GetValue(Ordinales.Cliente["tipoDocumento"]).ToString(),
                     NumeroDocumento=reader.GetValue(Ordinales.Cliente["numeroDocumento"]).ToString(),
                     Cuil=reader.GetValue(Ordinales.Cliente["cuil"]).ToString(),
                     Email=reader.GetValue(Ordinales.Cliente["email"]).ToString(),
                     Telefono=reader.GetValue(Ordinales.Cliente["telefono"]).ToString(),
                     FechaDeNacimiento=(DateTime)reader.GetValue(Ordinales.Cliente["fechaNacimiento"]),
                     FechaDeCreacion=(DateTime)reader.GetValue(Ordinales.Cliente["fechaCreacion"]),
                     Direccion= 
                        new Direccion(
                        reader.GetValue(Ordinales.Direccion["calle"]).ToString(),
                        reader.GetValue(Ordinales.Direccion["numero"]).ToString(),
                        reader.GetValue(Ordinales.Direccion["departamento"]).ToString(),
                        reader.GetValue(Ordinales.Direccion["localidad"]).ToString(),
                        reader.GetValue(Ordinales.Direccion["codPostal"]).ToString()
                        ),
                        Tarjeta= new Tarjeta(
                        reader.GetValue(Ordinales.Tarjeta["numero"]).ToString(),
                        reader.GetValue(Ordinales.Tarjeta["nombre"]).ToString(),
                        (DateTime)reader.GetValue(Ordinales.Tarjeta["fechaVencimiento"]),
                        reader.GetValue(Ordinales.Tarjeta["ccv"]).ToString()
                        )
                              
                            });
           }
            return clientes;
        }
    }
}
