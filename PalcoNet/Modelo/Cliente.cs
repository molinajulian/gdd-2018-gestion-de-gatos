using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
    public class Cliente:Rol
    {
        public string NombreCliente { get; set; }
        public string Apellido { get; set; }
        public TiposDocumento TipoDeDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public string Cuil { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Direccion Direccion { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public List<Tarjeta> Tarjeta { get; set; }
        public bool Activo { get; set; }

        public Cliente(string tipoDeDocumento,int numeroDocumento,string cuil,string nombre,string apellido,string mail,string calle,string nro,string depto,string piso,string localidad,string cp ) 
        { 
            NombreCliente=nombre;
            Apellido=apellido;
            TipoDeDocumento.Descripcion=tipoDeDocumento;
            NumeroDocumento=numeroDocumento;
            Cuil=cuil;
            Email=mail;
            Direccion = new Direccion(calle,nro,depto,localidad,cp);
        }

        public Cliente()
        {
            
        }
        public static Cliente buildGetClientes(SqlDataReader lector)
        {
            Dictionary<string, int> camposGetCliente = Ordinales.camposGetClientes;
            return new Cliente(lector.GetString(camposGetCliente["tipo_doc_descr"]), (int)lector.GetDecimal(camposGetCliente["cli_doc"]),lector.GetString(camposGetCliente["cli_cuil"]),
                lector.GetString(camposGetCliente["cli_nombre"]),lector.GetString(camposGetCliente["cli_apellido"]),lector.GetString(camposGetCliente["cli_mail"]),
                lector.GetString(camposGetCliente["dom_calle"]),lector.GetDecimal(camposGetCliente["dom_nro_calle"]).ToString(),lector.GetString(camposGetCliente["dom_depto"]),
                lector.GetDecimal(camposGetCliente["dom_piso"]).ToString(),lector.GetString(camposGetCliente["dom_localidad"]),lector.GetString(camposGetCliente["dom_cod_postal"])
                );
        }
        public static int buildClienteExistente(SqlDataReader lector)
        {
            Dictionary<string, int> campoClienteExistente = Ordinales.campoClienteExistente;
            return lector.GetInt32(campoClienteExistente["cantidad"]);
        }
    }
}
