using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PalcoNet.Repositorios;

namespace PalcoNet.Modelo
{
    public class Espectaculo
    {
        public int Id { get; set; }
        public List<Ubicacion> Ubicaciones { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public Rubro Rubro { get; set; }
        public Empresa Empresa { get; set; }
        public DateTime FechaOcurrencia;
        public Domicilio Domicilio { get; set; }
        public Boolean Habilitado { get; set; }

        public Espectaculo(int id, string descripcion,
            DateTime fechaOcurrencia, DateTime fechaVencimiento,
            Rubro rubro, Empresa empresa,
            Domicilio domicilio, Boolean habilitado)
        {
            Id = id;
            Ubicaciones = new List<Ubicacion>();
            Descripcion = descripcion;
            FechaOcurrencia = fechaOcurrencia;
            FechaVencimiento = fechaVencimiento;
            Rubro = rubro;
            Empresa = empresa;
            Domicilio = domicilio;
            Habilitado = habilitado;
        }


        public static Espectaculo build(SqlDataReader lector)
        {
            Dictionary<string, int> camposEspec = Ordinales.Espectaculo;
            return new Espectaculo(
                Convert.ToInt32(lector[camposEspec["id"]]),
                lector[camposEspec["descripcion"]].ToString(),
                Convert.ToDateTime(lector[camposEspec["fecha"]]),
                Convert.ToDateTime(lector[camposEspec["fechaVencimiento"]]),
                RubroRepositorio.ReadRubroFromDb(Convert.ToInt32(lector[camposEspec["idRubro"]])),
                EmpresasRepositorio.getEmpresa(lector[camposEspec["idEmpresa"]].ToString()),
                DomiciliosRepositorio.getDomicilio(lector[camposEspec["idDomicilio"]].ToString()),
                Convert.ToBoolean(lector[camposEspec["estado"]]));
        }

        public static Espectaculo buildCompuesto(SqlDataReader lector)
        {
            Dictionary<string, int> camposEspec = Ordinales.Espectaculo;
            return new Espectaculo(
                Convert.ToInt32(lector[camposEspec["esp_id"]]),
                lector[camposEspec["esp_descripcion"]].ToString(),
                Convert.ToDateTime(lector[camposEspec["esp_fecha"]]),
                Convert.ToDateTime(lector[camposEspec["esp_vencimiento"]]),
                RubroRepositorio.ReadRubroFromDb(Convert.ToInt32(lector[camposEspec["esp_idRubro"]])),
                EmpresasRepositorio.getEmpresa(lector[camposEspec["esp_idEmpresa"]].ToString()),
                DomiciliosRepositorio.getDomicilio(lector[camposEspec["esp_idDomicilio"]].ToString()),
                Convert.ToBoolean(lector[camposEspec["esp_estado"]]));
        }
    }
}
