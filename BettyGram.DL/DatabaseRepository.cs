using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BettyGram.DL
{
   public class DatabaseRepository
   {
      protected SqlConnection Connection { get; set; }

      //protected DatabaseRepository()
      //{
      //    Database = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnect"].ToString());
      //}

      /// <summary>
      /// Create and open an sql connection.
      /// </summary>
      /// <returns>A new open sql connection</returns>
      protected SqlConnection GetConnection()
      {
         Connection = DataBaseProvider.GetSqlConnection();

         if (Connection.State != ConnectionState.Open)
         {
            Connection.Open();
         }

         return Connection;
      }
      /// <summary>
      /// Create sql command.
      /// </summary>
      /// <param name="name"></param>
      /// <param name="commandType"></param>
      /// <returns>A new sql command.</returns>
      protected SqlCommand GetCommand(string name, CommandType commandType = CommandType.StoredProcedure)
      {
         SqlCommand command = new SqlCommand(name, Connection);
         command.CommandType = commandType;

         return command;
      }
   }
}