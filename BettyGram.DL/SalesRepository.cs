using BettyGram.TL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BettyGram.DL
{
   public class SalesRepository : DatabaseRepository,ISalesRepository
   {
      #region CONSTANTS

      //Stored procedures
      private const string GETALL = "GetAllSalesItems";

      //Parameters
      private const string ID = "Id";
      private const string COUNTRY = "Country";
      private const string NUMBER = "Number";

      #endregion

      public IList<SalesDto> GetAll()
      {
         List<SalesDto> salesList = new List<SalesDto>();

         using (SqlConnection connection = DataBaseProvider.GetSqlConnection())
         {
            using (IDataReader reader = DataBaseProvider.ExecuteCommand<IDataReader>(connection, GETALL, CommandType.StoredProcedure))
            {
               while (reader.Read())
               {
                  SalesDto dto = DtoHelper.GetDto<SalesDto>(reader);
                  salesList.Add(dto);
               }
            }
         }

         return salesList;
      }
   }
}