using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BettyGram.DL
{
   public class DtoHelper
   {
      public static T GetDto<T>(IDataReader reader)
      {
         Type type = typeof(T);
         T dto = Activator.CreateInstance<T>();

         PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
             .Where(p => p.GetCustomAttribute<IgnoreColumnAttribute>() == null).ToArray();

         foreach (PropertyInfo prop in properties)
         {
            prop.SetValue(dto, ExtractValue(reader, prop));
         }

         return dto;
      }

      private static object ExtractValue(IDataReader reader, PropertyInfo prop)
      {
         Type propType = prop.PropertyType;
         string dbColumnName = prop.Name;
         DbColumnAttribute dbColumnAttr = prop.GetCustomAttribute<DbColumnAttribute>();

         if (null != dbColumnAttr)
         {
            dbColumnName = dbColumnAttr.ColumnName;
         }

         switch (propType.Name.ToLower())
         {
            case "byte":
               return reader.GetByte(reader.GetOrdinal(dbColumnName));
            case "int16":
               return reader.GetInt16(reader.GetOrdinal(dbColumnName));
            case "int32":
               return reader.GetInt32(reader.GetOrdinal(dbColumnName));
            case "int64":
               return reader.GetInt64(reader.GetOrdinal(dbColumnName));
            case "decimal":
               return reader.GetDecimal(reader.GetOrdinal(dbColumnName));
            case "double":
               return reader.GetDouble(reader.GetOrdinal(dbColumnName));
            case "string":
               return
                   !reader.IsDBNull(reader.GetOrdinal(dbColumnName)) ?
                   reader.GetString(reader.GetOrdinal(dbColumnName)) : string.Empty;
            case "enum":
               return Enum.Parse(propType, reader.GetByte(reader.GetOrdinal(dbColumnName)).ToString(), true);
            case "guid":
               return reader.GetGuid(reader.GetOrdinal(dbColumnName));
            case "datetime":
               return reader.GetDateTime(reader.GetOrdinal(dbColumnName));
            case "boolean":
               return reader.GetBoolean(reader.GetOrdinal(dbColumnName));
            default:
               return null;
         }
      }
   }
   public class IgnoreColumnAttribute : Attribute
   {
   }

   public class DbColumnAttribute : Attribute
   {
      public string ColumnName { get; set; }

      public DbColumnAttribute(string columnName)
      {
         ColumnName = columnName;
      }
   }
}