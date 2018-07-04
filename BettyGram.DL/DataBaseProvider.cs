using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;

namespace BettyGram.DL
{
   public static class DataBaseProvider
   {
      /// <summary>
      /// Get sql connection.
      /// </summary>
      /// <returns></returns>
      public static SqlConnection GetSqlConnection()
      {
         SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

         if (connection.State != ConnectionState.Open)
         {
            connection.Open();
         }

         return connection;
      }

      /// <summary>
      /// Executes a SQL command and returns a scalar.This method uses the retry policy specified when 
      /// instantiating the SqlAzureConnection class (or the default retry policy if no policy was set at construction time).
      /// </summary>
      /// <param name="command">A SqlCommand object containing the SQL command to be executed.</param>
      /// <param name="commandType">Type of the command.</param>
      /// <param name="parameters">The parameters.</param>
      /// <returns>An string instance containing the result.</returns>
      /// <remarks></remarks>
      public static string ExecuteScalar(string command, CommandType commandType = CommandType.StoredProcedure, params SqlParameter[] parameters)
      {
         using (SqlConnection connection = GetSqlConnection())
         {
            return ExecuteCommand<string>(connection, command, commandType, parameters);
         }
      }

      /// <summary>
      /// Executes a SQL command and returns a scalar.This method uses the retry policy specified when 
      /// instantiating the SqlAzureConnection class (or the default retry policy if no policy was set at construction time).
      /// </summary>
      /// <param name="command">A SqlCommand object containing the SQL command to be executed.</param>
      /// <param name="commandType">Type of the command.</param>
      /// <param name="commandTimeout">Wait time (in seconds) before terminating the attempt to execute a command and generating an error.</param>
      /// <param name="parameters">The parameters.</param>
      /// <returns>An string instance containing the result.</returns>
      /// <remarks></remarks>
      public static string ExecuteScalar(string command, CommandType commandType, int commandTimeout, params SqlParameter[] parameters)
      {
         using (SqlConnection connection = GetSqlConnection())
         {
            return ExecuteCommand<string>(connection, command, commandType, commandTimeout, parameters);
         }
      }

      /// <summary>
      /// Executes a SQL command and returns the number of rows affected.
      /// </summary>
      /// <param name="command">The command</param>
      /// <param name="parameters">The parameters.</param>
      /// <returns>The number of rows affected.</returns>
      /// <remarks></remarks>
      public static int ExecuteCommand(string command, params SqlParameter[] parameters)
      {
         return ExecuteCommand(command, CommandType.StoredProcedure, parameters);
      }

      /// <summary>
      /// Executes a SQL command and returns the number of rows affected.
      /// </summary>
      /// <param name="command">The command.</param>
      /// <param name="commandType">Type of the command.</param>
      /// <returns>The number of rows affected.</returns>
      /// <remarks></remarks>
      public static int ExecuteCommand(string command, CommandType commandType = CommandType.StoredProcedure)
      {
         using (SqlConnection connection = GetSqlConnection())
         {
            using (SqlCommand sqlCommand = connection.CreateCommand())
            {
               sqlCommand.CommandTimeout = 30 * 60; //30 min
               sqlCommand.CommandText = command;
               sqlCommand.CommandType = commandType;

               return ExecuteCommand(sqlCommand);
            }
         }
      }

      /// <summary>
      /// Executes a SQL command and returns the number of rows affected.
      /// </summary>
      /// <param name="command">The command.</param>
      /// <param name="commandType">Type of the command.</param>
      /// <param name="parameters">The parameters.</param>
      /// <returns>The number of rows affected.</returns>
      /// <remarks></remarks>
      public static int ExecuteCommand(string command, CommandType commandType, params SqlParameter[] parameters)
      {
         return ExecuteCommand(command, commandType, 0, parameters);
      }

      /// <summary>
      /// Executes a SQL command and returns the number of rows affected.
      /// </summary>
      /// <param name="command">The command.</param>
      /// <param name="commandType">Type of the command.</param>
      /// <param name="commandTimeout">Wait time (in seconds) before terminating the attempt to execute a command and generating an error.</param>
      /// <param name="parameters">The parameters.</param>
      /// <returns>The number of rows affected.</returns>
      /// <remarks></remarks>
      public static int ExecuteCommand(string command, CommandType commandType, int commandTimeout, params SqlParameter[] parameters)
      {
         using (SqlConnection connection = GetSqlConnection())
         {
            using (SqlCommand sqlCommand = connection.CreateCommand())
            {
               sqlCommand.CommandTimeout = commandTimeout;
               sqlCommand.CommandText = command;
               sqlCommand.CommandType = commandType;
               AttachParameters(sqlCommand, parameters);

               return ExecuteCommand(sqlCommand);
            }
         }
      }

      /// <summary>
      ///  Executes a SQL command (or store procedure) and returns a result defined by the specified type <typeparamref name="T"/>. This method uses the retry policy specified when 
      /// instantiating the SqlAzureConnection class (or the default retry policy if no policy was set at construction time).
      /// </summary>
      /// <typeparam name="T">Either IDataReader, XmlReader or any .NET type defining the type of result to be returned.</typeparam>
      /// <param name="connection">The connection.</param>
      /// <param name="command">The command.</param>
      /// <param name="commandType">Type of the command.</param>
      /// <param name="parameters">The parameters.</param>
      /// <returns>An instance of an IDataReader, XmlReader or any .NET object containing the result.</returns>
      /// <remarks></remarks>
      public static T ExecuteCommand<T>(SqlConnection connection, string command, CommandType commandType, params SqlParameter[] parameters)
      {
         return ExecuteCommand<T>(connection, command, commandType, 0, parameters);
      }

      /// <summary>
      ///  Executes a SQL command (or store procedure) and returns a result defined by the specified type <typeparamref name="T"/>. This method uses the retry policy specified when 
      /// instantiating the SqlAzureConnection class (or the default retry policy if no policy was set at construction time).
      /// </summary>
      /// <typeparam name="T">Either IDataReader, XmlReader or any .NET type defining the type of result to be returned.</typeparam>
      /// <param name="connection">The connection.</param>
      /// <param name="command">The command.</param>
      /// <param name="commandType">Type of the command.</param>
      /// <param name="commandTimeout">Wait time (in seconds) before terminating the attempt to execute a command and generating an error.</param>
      /// <param name="parameters">The parameters.</param>
      /// <returns>An instance of an IDataReader, XmlReader or any .NET object containing the result.</returns>
      /// <remarks></remarks>
      public static T ExecuteCommand<T>(SqlConnection connection, string command, CommandType commandType, int commandTimeout, params SqlParameter[] parameters)
      {
         using (SqlCommand sqlCommand = connection.CreateCommand())
         {
            sqlCommand.CommandTimeout = commandTimeout;
            sqlCommand.CommandText = command;
            sqlCommand.CommandType = commandType;
            AttachParameters(sqlCommand, parameters);

            return ExecuteCommand<T>(sqlCommand);
         }
      }

      /// <summary>
      ///  Executes a SQL command (or store procedure) and returns a result defined by the specified type <typeparamref name="T"/>. This method uses the retry policy specified when 
      /// instantiating the SqlAzureConnection class (or the default retry policy if no policy was set at construction time).
      /// </summary>
      /// <typeparam name="T">Either IDataReader, XmlReader or any .NET type defining the type of result to be returned.</typeparam>
      /// <param name="connection">The connection.</param>
      /// <param name="transaction">The transaction.</param>
      /// <param name="command">The command.</param>
      /// <param name="commandType">Type of the command.</param>
      /// <param name="parameters">The parameters.</param>
      /// <returns>An instance of an IDataReader, XmlReader or any .NET object containing the result.</returns>
      /// <remarks></remarks>
      public static T ExecuteCommand<T>(SqlConnection connection, SqlTransaction transaction, string command, CommandType commandType, params SqlParameter[] parameters)
      {
         using (SqlCommand sqlCommand = connection.CreateCommand())
         {
            sqlCommand.CommandText = command;
            sqlCommand.CommandType = commandType;
            sqlCommand.Transaction = transaction;
            AttachParameters(sqlCommand, parameters);

            return ExecuteCommand<T>(sqlCommand);
         }
      }

      #region Private methods

      /// <summary>
      /// Attaches the parameters to SqlCommand.
      /// </summary>
      /// <param name="sqlCommand">The SQL command.</param>
      /// <param name="parameters">The parameters.</param>
      private static void AttachParameters(this SqlCommand sqlCommand, SqlParameter[] parameters)
      {
         if (parameters != null)
         {
            foreach (SqlParameter p in parameters)
               if (p != null)
               {
                  // Check for derived output value with no value assigned
                  if (((p.Direction == ParameterDirection.InputOutput) || (p.Direction == ParameterDirection.Input)) && (p.Value == null))
                     p.Value = DBNull.Value;
                  sqlCommand.Parameters.Add(p);
               }
         }
      }

      /// <summary>
      /// Executes a SQL command using the specified retry policy and returns a result defined by the specified type <typeparamref name="T"/>
      /// </summary>
      /// <typeparam name="T">Either IDataReader, XmlReader or any .NET type defining the type of result to be returned.</typeparam>
      /// <param name="command">A SqlCommand object containing the SQL command to be executed.</param>
      /// <param name="retryPolicy">The retry policy defining whether to retry a command if a connection fails while executing the command.</param>
      /// <param name="behavior">Provides a description of the results of the query and its effect on the database.</param>
      /// <returns>An instance of an IDataReader, XmlReader or any .NET object containing the result.</returns>
      private static T ExecuteCommand<T>(IDbCommand command, CommandBehavior behavior = CommandBehavior.Default)
      {
         // Make sure the command has been associated with a valid connection. If not, associate it with an opened SQL connection.
         if (command.Connection == null)
         {
            // Open a new connection and assign it to the command object.
            command.Connection = GetSqlConnection();
         }

         // Verify whether or not the connection is valid and is open. This code may be retried therefore
         // it is important to ensure that a connection is re-established should it have previously failed.
         if (command.Connection.State != ConnectionState.Open)
         {
            command.Connection.Open();
         }

         Type resultType = typeof(T);

         if (resultType.IsAssignableFrom(typeof(IDataReader)))
         {
            return (T)command.ExecuteReader(behavior);
         }
         if (resultType.IsAssignableFrom(typeof(XmlReader)))
         {
            if (command is SqlCommand)
            {
               object result = null;
               XmlReader xmlReader = (command as SqlCommand).ExecuteXmlReader();

               // Implicit conversion from XmlReader to <T> via an intermediary object.
               result = xmlReader;

               return (T)result;
            }
            throw new NotSupportedException();
         }
         if (resultType == typeof(NonQueryResult))
         {
            NonQueryResult result = new NonQueryResult();
            result.RecordsAffected = command.ExecuteNonQuery();

            return (T)Convert.ChangeType(result, resultType);
         }
         else
         {
            object result = command.ExecuteScalar();

            if (result != null)
            {
               return (T)Convert.ChangeType(result, resultType);
            }
            return default(T);
         }
      }

      /// <summary>
      /// Executes a SQL command and returns the number of rows affected.
      /// </summary>
      /// <param name="command">A SqlCommand object containing the SQL command to be executed.</param>
      /// <returns>The number of rows affected.</returns>
      private static int ExecuteCommand(IDbCommand command)
      {
         NonQueryResult result = ExecuteCommand<NonQueryResult>(command);

         return result.RecordsAffected;
      }

      #endregion Private methods

      /// <summary>
      /// This helpers class is intended to be used exclusively for fetching the number of affected records when executing a command using ExecuteNonQuery.
      /// </summary>
      private sealed class NonQueryResult
      {
         public int RecordsAffected { get; set; }
      }
   }
}