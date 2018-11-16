using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace PalcoNet.Repositorios
{
    class Database
    {
        private static SqlConnection connection = new SqlConnection();

        public static SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.ConnectionString =
                   @System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                // "ConnectionString" se obtiene del app.config
                connection.Open();
            }
            return connection;
        }

       
        public static SqlCommand BuildSQLCommand(string commandtext, List<SqlParameter> parameters)
        {
            
            SqlCommand sqlCommand = new SqlCommand();
            
            sqlCommand.Connection = GetConnection();
            
            sqlCommand.CommandText = commandtext;
            
            if (parameters != null)
            {
                foreach (SqlParameter param in parameters) { sqlCommand.Parameters.Add(param); }
            }
            return sqlCommand;
        }

        public static SqlCommand ejecutarSP(String nombreSP, List<SqlParameter> parametros)
        {

            SqlCommand sqlCommand = DataBase.BuildSQLCommand(nombreSP, parametros);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            return sqlCommand;
        }


        public static SqlDataReader GetDataReader(string commandtext, string commandtype, List<SqlParameter> parameters)
        {
           
            SqlCommand sqlCommand = BuildSQLCommand(commandtext, parameters);
            SetCommandType(commandtype, sqlCommand);
            
            return sqlCommand.ExecuteReader();
        }

        private static void SetCommandType(string commandtype, SqlCommand sqlCommand)
        {
            
            switch (commandtype)
            {
                case "T":
                    sqlCommand.CommandType = CommandType.Text;
                    break;
                case "TD":
                    sqlCommand.CommandType = CommandType.TableDirect;
                    break;
                case "SP":
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    break;
            }
        }

        public static int WriteInBase(string commandtext, string commandtype, List<SqlParameter> parameters)
        {
            
            SqlCommand sqlCommand = BuildSQLCommand(commandtext, parameters);
            SetCommandType(commandtype, sqlCommand);
            return sqlCommand.ExecuteNonQuery();

        }
    
    }
}
