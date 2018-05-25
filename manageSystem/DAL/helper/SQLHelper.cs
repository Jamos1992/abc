using System;
using System.Data.SQLite;
using System.Reflection;

namespace DAL
{
    public class SQLHelper
    {
        private static SQLiteConnection dbConnection;
        private static SQLiteCommand dbCommand;
        private static SQLiteDataReader dataReader;
        private static string connectionString = @"data source=d:\workspace\manageSystem\database\storehouse.db";
        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <returns>The query.</returns>
        /// <param name="queryString">SQL命令字符串</param>
        public static SQLiteDataReader ExecuteQuery(string queryString)
        {
            dbConnection = new SQLiteConnection(connectionString);
            try
            {                
                dbConnection.Open();
                dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = queryString;
                dataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                throw e;
            }
            return dataReader;
        }

        public static int ExecuteNonQuery(string queryString)
        {
            dbConnection = new SQLiteConnection(connectionString);
            try
            {               
                dbConnection.Open();
                dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = queryString;
                return dbCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dbConnection.Close();
            }
        }
        /// <summary>
        /// 读取整张数据表
        /// </summary>
        /// <returns>The full table.</returns>
        /// <param name="tableName">数据表名称</param>
        public static SQLiteDataReader ReadFullTable(string tableName)
        {
            string queryString = "SELECT * FROM " + tableName;
            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 向指定数据表中插入数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="values">插入的数值</param>
        public static int InsertValues(string tableName, string[] values)
        {
            //获取数据表中字段数目
            SQLiteDataReader reader = ReadFullTable(tableName);
            //当插入的数据长度不等于字段数目时引发异常
            if (values.Length != reader.FieldCount)
            {
                throw new SQLiteException("values.Length!=fieldCount");
            }
            reader.Close();
            string queryString = "INSERT INTO " + tableName + " VALUES (" + "'" + values[0] + "'";
            for (int i = 1; i < values.Length; i++)
            {
                queryString += ", " + "'" + values[i] + "'";
            }
            queryString += " )";
            return ExecuteNonQuery(queryString);
        }

        public static int InsertValuesByStruct(string tableName, object obj)
        {
            PropertyInfo[] propertys = obj.GetType().GetProperties();
            SQLiteDataReader reader = ReadFullTable(tableName);
            //当插入的数据长度不等于字段数目时引发异常
            if (propertys.Length != reader.FieldCount)
            {
                throw new SQLiteException("propertys.Length!=fieldCount");
            }
            reader.Close();
            int i = 0;
            string queryString = "";
            foreach (PropertyInfo pinfo in propertys)
            {
                if (i == 0)
                {
                    queryString = "INSERT INTO " + tableName + " VALUES (" + "'" + pinfo.GetValue(obj, null) + "'";
                }
                else
                {
                    queryString += ", " + "'" + pinfo.GetValue(obj, null) + "'";
                }
                i++;
            }
            queryString += " )";
            Console.WriteLine("sql is {0}", queryString);
            return ExecuteNonQuery(queryString);
        }

        /// <summary>
        /// 更新指定数据表内的数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        /// <param name="key">关键字</param>
        /// <param name="value">关键字对应的值</param>
        /// <param name="operation">运算符：=,<,>,...，默认“=”</param>
        public static int UpdateValues(string tableName, string[] colNames, string[] colValues, string key, string value, string operation = "=")
        {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length!=colValues.Length");
            }

            string queryString = "UPDATE " + tableName + " SET " + colNames[0] + "=" + "'" + colValues[0] + "'";
            for (int i = 1; i < colValues.Length; i++)
            {
                queryString += ", " + colNames[i] + "=" + "'" + colValues[i] + "'";
            }
            queryString += " WHERE " + key + operation + "'" + value + "'";
            return ExecuteNonQuery(queryString);
        }

        public static int UpdateValuesByStruct(string tableName, object obj, string[] colNames, string[] values)
        {
            PropertyInfo[] propertys = obj.GetType().GetProperties();
            //当字段名称和字段数值不对应时引发异常
            SQLiteDataReader reader = ReadFullTable(tableName);
            if (propertys.Length != reader.FieldCount || colNames.Length != values.Length)
            {
                throw new SQLiteException("propertys.Length!=fieldCount");
            }
            reader.Close();
            int i = 0;
            string queryString = "";
            foreach (PropertyInfo pinfo in propertys)
            {
                if (i == 0)
                {
                    queryString = "UPDATE " + tableName + " SET " + pinfo.Name + "=" + "'" + pinfo.GetValue(obj, null) + "'";
                }
                else
                {
                    queryString += ", " + "'" + pinfo.GetValue(obj, null) + "'";
                }
                i++;
            }
            for (int j = 0; j < values.Length; j++)
            {
                if (j == 0)
                {
                    queryString += " where " + colNames[j] + "=" + "'" + values[j] + "'";
                }
                else
                {
                    queryString += " and " + colNames[j] + "=" + "'" + values[j] + "'";
                }
            }
            return ExecuteNonQuery(queryString);
        }

        /// <summary>
        /// 删除指定数据表内的数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        public static int DeleteValuesOR(string tableName, string[] colNames, string[] colValues, string[] operations)
        {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length || operations.Length != colNames.Length || operations.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length!=colValues.Length || operations.Length!=colNames.Length || operations.Length!=colValues.Length");
            }

            string queryString = "DELETE FROM " + tableName + " WHERE " + colNames[0] + operations[0] + "'" + colValues[0] + "'";
            for (int i = 1; i < colValues.Length; i++)
            {
                queryString += "OR " + colNames[i] + operations[0] + "'" + colValues[i] + "'";
            }
            return ExecuteNonQuery(queryString);
        }

        /// <summary>
        /// 删除指定数据表内的数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        public static int DeleteValuesAND(string tableName, string[] colNames, string[] colValues, string[] operations)
        {
            //当字段名称和字段数值不对应时引发异常
            if (colNames.Length != colValues.Length || operations.Length != colNames.Length || operations.Length != colValues.Length)
            {
                throw new SQLiteException("colNames.Length!=colValues.Length || operations.Length!=colNames.Length || operations.Length!=colValues.Length");
            }

            string queryString = "DELETE FROM " + tableName + " WHERE " + colNames[0] + operations[0] + "'" + colValues[0] + "'";
            for (int i = 1; i < colValues.Length; i++)
            {
                queryString += " AND " + colNames[i] + operations[i] + "'" + colValues[i] + "'";
            }
            return ExecuteNonQuery(queryString);
        }


        /// <summary>
        /// 创建数据表
        /// </summary> +
        /// <returns>The table.</returns>
        /// <param name="tableName">数据表名</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colTypes">字段名类型</param>
        public static int CreateTable(string tableName, string[] colNames, string[] colTypes)
        {
            string queryString = "CREATE TABLE IF NOT EXISTS " + tableName + "( " + colNames[0] + " " + colTypes[0];
            for (int i = 1; i < colNames.Length; i++)
            {
                queryString += ", " + colNames[i] + " " + colTypes[i];
            }
            queryString += " ) ";
            Console.WriteLine(queryString);
            return ExecuteNonQuery(queryString);
        }

        /// <summary>
        /// Reads the table.
        /// </summary>
        /// <returns>The table.</returns>
        /// <param name="tableName">Table name.</param>
        /// <param name="items">Items.</param>
        /// <param name="colNames">Col names.</param>
        /// <param name="operations">Operations.</param>
        /// <param name="colValues">Col values.</param>
        public static SQLiteDataReader ReadTable(string tableName, string[] items, string[] colNames, string[] operations, string[] colValues)
        {
            string queryString = "SELECT " + items[0];
            for (int i = 1; i < items.Length; i++)
            {
                queryString += ", " + items[i];
            }
            queryString += " FROM " + tableName + " WHERE " + colNames[0] + " " + operations[0] + " " + colValues[0];
            for (int i = 1; i < colNames.Length; i++)
            {
                queryString += " AND " + colNames[i] + " " + operations[i] + " " + colValues[i] + " ";
            }
            //Console.WriteLine("query string is {0}", queryString);
            return ExecuteQuery(queryString);
        }

        public static SQLiteDataReader ReadTableBySql(string sql)
        {
            return ExecuteQuery(sql);
        }

        public static int UpdateTableBySql(string sql)
        {
            return ExecuteNonQuery(sql);
        }

        public static int InsertTableBySql(string sql)
        {
            return ExecuteNonQuery(sql);
        }
    }
}
