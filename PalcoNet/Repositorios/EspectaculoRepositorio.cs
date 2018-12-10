using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class EspectaculoRepositorio
    {
        public static List<SqlParameter> GenerarParametrosEspectaculo(Espectaculo espectaculo,string username)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Descripcion", espectaculo.Descripcion));
            parametros.Add(new SqlParameter("@Id", espectaculo.Id));
            parametros.Add(new SqlParameter("@Fecha", espectaculo.Fecha));
            parametros.Add(new SqlParameter("@Hora", espectaculo.Hora));
            parametros.Add(new SqlParameter("@Descripcion", espectaculo.Descripcion));
                        return parametros;
        }
        public static void CreateEspectaculo(Espectaculo espectaculo,string username)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@descripcion", espectaculo.Descripcion));
            parametros.Add(new SqlParameter("@fecha", espectaculo.Fecha));
            parametros.Add(new SqlParameter("@hora", espectaculo.Hora));
            parametros.Add(new SqlParameter("@fechaVencimiento", espectaculo.FechaVencimiento));
            parametros.Add(new SqlParameter("@rubroId", espectaculo.Rubro.Codigo));
            parametros.Add(new SqlParameter("@empresaId", espectaculo.Empresa.Cuit));
            parametros.Add(new SqlParameter("@domicilioId", espectaculo.Empresa.Direccion.Id));



            DataBase.WriteInBase("[dbo].[sp.crear_espectaculo]", "SP", parametros);

        }


        public static void UpdateEspectaculo(Espectaculo espectaculo,string username)
        {
            List<SqlParameter> parametros = GenerarParametrosEspectaculo(espectaculo,username);
            DataBase.WriteInBase("Updateespectaculo", "SP", parametros);

        }


        public static void DeleteEspectaculo(Espectaculo espectaculo,string username)
        {
            List<SqlParameter> parametros = GenerarParametrosEspectaculo(espectaculo,username);
            DataBase.WriteInBase("Deleteespectaculo", "SP", parametros);

        }

        public static Espectaculo ReadEspectaculoFromDb(int id)
        {
            var espectaculo = new Espectaculo();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            var query = DataBase.ejecutarFuncion("Select top 1 * from espectaculo r where r.Espectaculo_Cod = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                espectaculo = new Espectaculo()
                {
                    Id = (int)reader.GetValue(Ordinales.Espectaculo["codigo"]),
                    Descripcion = reader.GetValue(Ordinales.Espectaculo["descripcion"]).ToString(),
                    Fecha = (DateTime)reader.GetValue(Ordinales.Espectaculo["descripcion"]),
                    Hora = (TimeSpan)reader.GetValue(Ordinales.Espectaculo["descripcion"]),
                    Empresa= EmpresasRepositorio.GetempresaByCuit(reader.GetValue(Ordinales.Espectaculo["idEmpresa"]).ToString()).First(),
                    Rubro= RubroRepositorio.ReadRubroFromDb((int)reader.GetValue(Ordinales.Espectaculo["idRubro"])),
                    Ubicaciones=UbicacionRepositorio.ReadUbicacionesFromDb(espectaculo.Id)

                };

            }
            return espectaculo;
        }

    }
}
