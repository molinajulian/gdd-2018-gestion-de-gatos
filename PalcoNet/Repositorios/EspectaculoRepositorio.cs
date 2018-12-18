using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Registro_de_usuario;

namespace PalcoNet.Repositorios
{
    class EspectaculoRepositorio
    {
        public static List<SqlParameter> GenerarParametrosEspectaculo(Espectaculo espectaculo,string username)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Descripcion", espectaculo.Descripcion));
            parametros.Add(new SqlParameter("@Id", espectaculo.Id));
            parametros.Add(new SqlParameter("@Descripcion", espectaculo.Descripcion));
                        return parametros;
        }
        public static void CreateEspectaculo(Espectaculo espectaculo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@descripcion", espectaculo.Descripcion));
            parametros.Add(new SqlParameter("@rubroId", espectaculo.Rubro.Codigo));
            parametros.Add(new SqlParameter("@empresaId", espectaculo.Empresa.Cuit));
            parametros.Add(new SqlParameter("@domicilioId", espectaculo.Empresa.Domicilio.Id));
            DataBase.ejecutarSP("[dbo].[sp.crear_espectaculo]", parametros);
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

        public static Espectaculo ReadEspectaculoFromDb(int especId)
        {
            SqlDataReader lector = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Espectaculos WHERE Espec_Cod = " + especId, "T", new List<SqlParameter>());
            Dictionary<string, int> camposEspec = Ordinales.Espectaculo;
            if (lector.HasRows && lector.Read())
            {
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
            throw new EspectaculoNoEncontradoException(especId);
        }

        public class EspectaculoNoEncontradoException : Exception
        {
            public EspectaculoNoEncontradoException(int id) : base("No se encontro un espectaculo con el id " + id)
            {

            }
        }

        public static void crearTodos(List<Espectaculo> espectaculos)
        {
            foreach (Espectaculo espectaculo in espectaculos)
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@espec_desc", espectaculo.Descripcion));
                parametros.Add(new SqlParameter("@espec_fecha", espectaculo.FechaOcurrencia));
                parametros.Add(new SqlParameter("@espec_fecha_vencimiento", espectaculo.FechaVencimiento));
                parametros.Add(new SqlParameter("@espec_rubro_codigo", espectaculo.Rubro.Codigo));
                parametros.Add(new SqlParameter("@espec_emp_cuit", espectaculo.Empresa.Cuit));
                parametros.Add(new SqlParameter("@espec_dom_id", espectaculo.Empresa.Domicilio.Id));
                parametros.Add(new SqlParameter("@espec_estado", espectaculo.Finalizado ? 1 : 0));
                SqlParameter output = new SqlParameter("@espec_cod", 0);
                output.Direction = ParameterDirection.Output;
                parametros.Add(output);
                SqlCommand sqlCommand = DataBase.ejecutarSP("[dbo].[sp_crear_espectaculo]", parametros);
                espectaculo.Id = Convert.ToInt32(output.Value);
            }
        }

        public static void actualizar(Espectaculo espectaculo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@espec_cod", espectaculo.Id));
            parametros.Add(new SqlParameter("@espec_desc", espectaculo.Descripcion));
            parametros.Add(new SqlParameter("@espec_fecha", espectaculo.FechaOcurrencia));
            parametros.Add(new SqlParameter("@espec_fecha_vencimiento", espectaculo.FechaVencimiento));
            parametros.Add(new SqlParameter("@espec_rubro_codigo", espectaculo.Rubro.Codigo));
            parametros.Add(new SqlParameter("@espec_emp_cuit", espectaculo.Empresa.Cuit));
            parametros.Add(new SqlParameter("@espec_dom_id", espectaculo.Empresa.Domicilio.Id));
            parametros.Add(new SqlParameter("@espec_estado", espectaculo.Finalizado ? 1 : 0));
            DataBase.ejecutarSP("[dbo].[sp_actualizar_espectaculo]", parametros);
        }
    }
}
