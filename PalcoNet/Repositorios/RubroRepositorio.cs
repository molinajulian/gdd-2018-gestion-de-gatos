using PalcoNet.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PalcoNet.Repositorios
{
  public  class RubroRepositorio
    {
        public static List<Rubro> getRubros()
        {
            List<Rubro> rubros = new List<Rubro>();
            SqlDataReader lector = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Rubros", "T", new List<SqlParameter>());
            Dictionary<string, int> camposRubro = Ordinales.Rubro;
            while (lector.HasRows && lector.Read())
            {
                rubros.Add(new Rubro(
                                    Convert.ToInt32(lector[camposRubro["codigo"]]),
                                    lector[camposRubro["descripcion"]].ToString()));
            }
            lector.Close();
            return rubros;
        }

        public static Rubro ReadRubroFromDb(int idRubro)
        {
            SqlDataReader lector = DataBase.GetDataReader("SELECT * FROM GESTION_DE_GATOS.Rubros WHERE Rubro_Cod = " + idRubro, "T", new List<SqlParameter>());
            Dictionary<string, int> camposRubro = Ordinales.Rubro;
            if (lector.HasRows && lector.Read())
            {
                return new Rubro(
                    Convert.ToInt32(lector[camposRubro["codigo"]]),
                    lector[camposRubro["descripcion"]].ToString());
            }
            return null;
        }
    }
}
