using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Repositorios
{
  public  class RubroRepositorio
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

        public static Rubro ReadRubroFromDb(int id)
        {
            var rubro = new Rubro();
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));    
            var query = DataBase.ejecutarFuncion("Select top 1 * from rubro r where r.Rubro_Cod = @id", parametros);
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                rubro= new Rubro()
                        {
                            Codigo= (int)reader.GetValue(Ordinales.Rubro["codigo"]),
                            Descripcion= reader.GetValue(Ordinales.Rubro["descripcion"]).ToString()

                        };
                    
            }
            return rubro;
        }

       
    }
}
