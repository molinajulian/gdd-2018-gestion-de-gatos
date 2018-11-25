using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
    class RubroRepositorio
    {
        public static List<SqlParameter> GenerarParametrosRubro(Rubro rubro)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@Descripcion", rubro.Descripcion));
            
           
            return parametros;
        }
        public static void CreateRubro(Rubro rubro)
        {
            List<SqlParameter> parametros = GenerarParametrosRubro(rubro);
            DataBase.WriteInBase("Ingresarrubros", "SP", parametros);

        }


        public static void UpdateRubro(Rubro rubro)
        {
            List<SqlParameter> parametros = GenerarParametrosRubro(rubro);
            DataBase.WriteInBase("Updaterubro", "SP", parametros);

        }


        public static void DeleteRubro(Rubro rubro)
        {
            List<SqlParameter> parametros = GenerarParametrosRubro(rubro);
            DataBase.WriteInBase("Deleterubro", "SP", parametros);

        }

        public static Rubro ReadRubroFromDb(SqlDataReader reader)
        {
            return new Rubro()
            {
                Descripcion = reader.GetValue(Ordinales.Rubro["descripcion"]).ToString(),
                Codigo = (int)reader.GetValue(Ordinales.Rubro["codigo"])            

            };
        }

       
    }
}
