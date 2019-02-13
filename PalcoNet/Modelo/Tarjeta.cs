using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PalcoNet.Repositorios;

namespace PalcoNet.Modelo
{
   public class Tarjeta
   {
       public Tarjeta(long numero, string banco, DateTime vencimiento)
       {
           Numero = numero;
           FechaVencimiento = vencimiento;
           Banco = banco;
       }

       private Tarjeta(int id, long numero, DateTime vencimiento, string banco, TipoDocumento tipoDoc, int doc)
       {
           Id = id;
           Numero = numero;
           FechaVencimiento = vencimiento;
           Banco = banco;
           TipoDocCliente = tipoDoc;
           DocumentoCliente = doc;
       }

       public int Id { get; set; }
       public long Numero { get; set; }
       public DateTime FechaVencimiento { get; set; }
       public string Banco { get; set; }
       public TipoDocumento TipoDocCliente { get; set; }
       public int DocumentoCliente { get; set; }
        
        public static Tarjeta build(SqlDataReader lector)
        {
            Dictionary<string, int> camposTarjeta = Ordinales.Tarjeta;
            return new Tarjeta(
                Convert.ToInt32(lector[camposTarjeta["id"]]),
                Convert.ToInt64(lector[camposTarjeta["numero"]]),
                Convert.ToDateTime(lector[camposTarjeta["vencimiento"]]),
                lector[camposTarjeta["banco_desc"]].ToString(),
                ClienteRepositorio.getTipoDoc(Convert.ToInt32(lector[camposTarjeta["cli_tipo_doc"]])),
                Convert.ToInt32(lector[camposTarjeta["cli_doc"]]));
        }
    }
}
