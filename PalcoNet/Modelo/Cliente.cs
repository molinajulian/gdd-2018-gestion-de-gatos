using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PalcoNet.Repositorios;

namespace PalcoNet.Modelo
{
    public class Cliente:Rol
    {
        public string NombreCliente { get; set; }
        public string Apellido { get; set; }
        public TipoDocumento TipoDeDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public string Cuil { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Domicilio Domicilio { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public List<Tarjeta> Tarjetas { get; set; }
        public Boolean Habilitado { get; set; }
        public static Cliente Actual { get; set; }

        public Cliente(int tipoDeDocumento_id, int numeroDocumento, string cuil, string nombre, string apellido, 
            string mail, string tel, bool habilitado, DateTime fechaNac, Domicilio domicilio)
        {
            NombreCliente = nombre;
            Apellido = apellido;
            TipoDeDocumento = ClienteRepositorio.getTipoDoc(tipoDeDocumento_id);
            NumeroDocumento = numeroDocumento;
            Cuil = cuil;
            Email = mail;
            Domicilio = domicilio;
            Habilitado = habilitado;
            Telefono = tel;
            FechaDeNacimiento = fechaNac;
        }
        public Cliente()
        {
            
        }

        public static Cliente build (SqlDataReader lector)
        {
            Dictionary<string, int> camposGetCliente = Ordinales.camposGetCliente;
            return new Cliente(
                Convert.ToInt32(lector[camposGetCliente["tipo_doc_id"]]),
                Convert.ToInt32(lector[camposGetCliente["cli_doc"]]),
                lector[camposGetCliente["cli_cuil"]].ToString(),
                lector[camposGetCliente["cli_nombre"]].ToString(),
                lector[camposGetCliente["cli_apellido"]].ToString(),
                lector[camposGetCliente["cli_mail"]].ToString(),
                lector[camposGetCliente["cli_tel"]].ToString(),
                lector.GetBoolean(camposGetCliente["cli_habilitado"]),
                lector.GetDateTime(camposGetCliente["cli_fecha_nac"]),
                DomiciliosRepositorio.getDomicilio(lector[camposGetCliente["cli_dom_id"]].ToString()));
        }
    }
}
