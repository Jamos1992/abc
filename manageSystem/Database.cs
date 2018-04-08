﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.SQLite;
using System.Reflection;

namespace manageSystem
{
    class Database
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\workspace\manageSystem\database\Database1.mdb");
        public Database()
        {
            conn.Open();
            Console.WriteLine("连接数据库成功");
        }

        public DataRowCollection QueryBySql(string sql)
        {
            //获取表1的内容
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, conn); //创建适配对象
            DataTable dt = new DataTable(); //新建表对象
            dbDataAdapter.Fill(dt); //用适配对象填充表对象
            //foreach (DataRow item in dt.Rows)
            //{
            //    Console.WriteLine(item[0] + " | " + item[1] + " | "+item[2]);
            //}
            return dt.Rows;
        }

        public bool InsertBySql(string sql)
        {
            //往表1添加一条记录，昵称是LanQ，账号是2545493686
            OleDbCommand oleDbCommand = new OleDbCommand(sql, conn);
            int i = oleDbCommand.ExecuteNonQuery(); //返回被修改的数目
            return i > 0;
        }

        public bool DeleteBySql(string sql)
        {
            //删除昵称为LanQ的记录
            OleDbCommand oleDbCommand = new OleDbCommand(sql, conn);
            int i = oleDbCommand.ExecuteNonQuery();
            return i > 0;
        }

        public bool UpdateBySql(string sql)
        {
            //将表1中昵称为东熊的账号修改成233333
            OleDbCommand oleDbCommand = new OleDbCommand(sql, conn);
            int i = oleDbCommand.ExecuteNonQuery();
            return i > 0;
        }
    }



    class SqLiteHelper
    {

        /// <summary>
        /// 数据库连接定义
        /// </summary>
        private SQLiteConnection dbConnection;

        /// <summary>
        /// SQL命令定义
        /// </summary>
        private SQLiteCommand dbCommand;

        /// <summary>
        /// 数据读取定义
        /// </summary>
        private SQLiteDataReader dataReader;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="connectionString">连接SQLite库字符串</param>
        public SqLiteHelper(string connectionString)
        {
            try
            {
                dbConnection = new SQLiteConnection(connectionString);
                dbConnection.Open();
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }
        }
        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <returns>The query.</returns>
        /// <param name="queryString">SQL命令字符串</param>
        public SQLiteDataReader ExecuteQuery(string queryString)
        {
            try
            {
                dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = queryString;
                dataReader = dbCommand.ExecuteReader();
            }
            catch (Exception e)
            {
                Log(e.Message);
            }

            return dataReader;
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void CloseConnection()
        {
            //销毁Commend
            if (dbCommand != null)
            {
                dbCommand.Cancel();
            }
            dbCommand = null;
            //销毁Reader
            if (dataReader != null)
            {
                dataReader.Close();
            }
            dataReader = null;
            //销毁Connection
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
            dbConnection = null;

        }

        /// <summary>
        /// 读取整张数据表
        /// </summary>
        /// <returns>The full table.</returns>
        /// <param name="tableName">数据表名称</param>
        public SQLiteDataReader ReadFullTable(string tableName)
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
        public SQLiteDataReader InsertValues(string tableName, string[] values)
        {
            //获取数据表中字段数目
            int fieldCount = ReadFullTable(tableName).FieldCount;
            //当插入的数据长度不等于字段数目时引发异常
            if (values.Length != fieldCount)
            {
                throw new SQLiteException("values.Length!=fieldCount");
            }

            string queryString = "INSERT INTO " + tableName + " VALUES (" + "'" + values[0] + "'";
            for (int i = 1; i < values.Length; i++)
            {
                queryString += ", " + "'" + values[i] + "'";
            }
            queryString += " )";
            return ExecuteQuery(queryString);
        }

        public SQLiteDataReader InsertValuesByStruct(string tableName, object obj)
        {
            PropertyInfo[] propertys = obj.GetType().GetProperties();
            int fieldCount = ReadFullTable(tableName).FieldCount;
            //当插入的数据长度不等于字段数目时引发异常
            if (propertys.Length != fieldCount)
            {
                throw new SQLiteException("propertys.Length!=fieldCount");
            }
            int i = 0;
            string queryString = "";
            foreach (PropertyInfo pinfo in propertys)
            {
                if (i == 0)
                {
                    queryString = "INSERT INTO " + tableName + " VALUES (" + "'" + pinfo.GetValue(obj, null) + "'";
                }else
                {
                    queryString += ", " + "'" + pinfo.GetValue(obj, null) + "'";
                }
                i++;
            }
            queryString += " )";
            return ExecuteQuery(queryString);
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
        public SQLiteDataReader UpdateValues(string tableName, string[] colNames, string[] colValues, string key, string value, string operation = "=")
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
            return ExecuteQuery(queryString);
        }

        public SQLiteDataReader UpdateValuesByStruct(string tableName, object obj, string []colNames, string[] values)
        {
            PropertyInfo[] propertys = obj.GetType().GetProperties();
            //当字段名称和字段数值不对应时引发异常
            int fieldCount = ReadFullTable(tableName).FieldCount;
            if (propertys.Length != fieldCount || colNames.Length != values.Length)
            {
                throw new SQLiteException("propertys.Length!=fieldCount");
            }
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
            for(int j=0;j < values.Length;j++)
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
            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 删除指定数据表内的数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        public SQLiteDataReader DeleteValuesOR(string tableName, string[] colNames, string[] colValues, string[] operations)
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
            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 删除指定数据表内的数据
        /// </summary>
        /// <returns>The values.</returns>
        /// <param name="tableName">数据表名称</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colValues">字段名对应的数据</param>
        public SQLiteDataReader DeleteValuesAND(string tableName, string[] colNames, string[] colValues, string[] operations)
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
            return ExecuteQuery(queryString);
        }


        /// <summary>
        /// 创建数据表
        /// </summary> +
        /// <returns>The table.</returns>
        /// <param name="tableName">数据表名</param>
        /// <param name="colNames">字段名</param>
        /// <param name="colTypes">字段名类型</param>
        public SQLiteDataReader CreateTable(string tableName, string[] colNames, string[] colTypes)
        {
            string queryString = "CREATE TABLE IF NOT EXISTS " + tableName + "( " + colNames[0] + " " + colTypes[0];
            for (int i = 1; i < colNames.Length; i++)
            {
                queryString += ", " + colNames[i] + " " + colTypes[i];
            }
            queryString += "  ) ";
            return ExecuteQuery(queryString);
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
        public SQLiteDataReader ReadTable(string tableName, string[] items, string[] colNames, string[] operations, string[] colValues)
        {
            string queryString = "SELECT " + items[0];
            for (int i = 1; i < items.Length; i++)
            {
                queryString += ", " + items[i];
            }
            queryString += " FROM " + tableName + " WHERE " + colNames[0] + " " + operations[0] + " " + colValues[0];
            for (int i = 0; i < colNames.Length; i++)
            {
                queryString += " AND " + colNames[i] + " " + operations[i] + " " + colValues[0] + " ";
            }
            return ExecuteQuery(queryString);
        }

        /// <summary>
        /// 本类log
        /// </summary>
        /// <param name="s"></param>
        static void Log(string s)
        {
            Console.WriteLine("class SqLiteHelper:::" + s);
        }

        public void CeateAllTable()
        {
            this.CreateToolsInfoDb();
            this.CreateEmailAddrDb();
        }

        public void CreateToolsInfoDb()
        {
            string[] toolsInfoFeildName = new string[] { "SerialNum", "Model", "Workstation", "Torque", "Status", "QualityAssureDate", "RepoSpareTool", "MaintainContractStyle", "MaintainContractData", "Remark", "MaintainInfo", "RepairList" };
            string[] toolsInfoFeildType = new string[] { "VARCHAR(255) PRIMARY KEY", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)", "VARCHAR(255)" };
            this.CreateTable("ToolsInfo", toolsInfoFeildName, toolsInfoFeildType);
        }

        public void CreateEmailAddrDb()
        {
            string[] emailAddrName = new string[] { "EmailAddr" };
            string[] emailAddrType = new string[] { "VARCHAR(255) PRIMARY KEY" };
            this.CreateTable("EmailAddress", emailAddrName, emailAddrType);
        }
        
    }
}
