﻿using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Reflection;

namespace DAL
{
    public class EXCELHelper
    {
        private static OleDbDataReader dataReader;
        public static int CreateExcelTable(string filePath,string sql)
        {
            String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;'";
            //实例化一个Oledbconnection类(实现了IDisposable,要using)
            OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
            try
            {   
                ole_conn.Open();
                OleDbCommand ole_cmd = ole_conn.CreateCommand();
                ole_cmd.CommandText = sql;               
                return ole_cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                ole_conn.Close();
            }
        }

        public static OleDbDataReader LoadDataFromExcel(string filePath,string sql)
        {
            String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;IMEX=2'";
            //实例化一个Oledbconnection类(实现了IDisposable,要using)
            OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
            try
            {  
                ole_conn.Open();
                OleDbCommand ole_cmd = ole_conn.CreateCommand();
                //类似SQL的查询语句这个[Sheet1$对应Excel文件中的一个工作表]
                ole_cmd.CommandText = sql;
                dataReader = ole_cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                throw e;
                //MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return dataReader;
        }

        public static int InsertExcelTable(string filePath, object obj,string sql)
        {
            String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;'";
            //实例化一个Oledbconnection类(实现了IDisposable,要using)
            OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
            try
            {
                ole_conn.Open();
                OleDbCommand ole_cmd = ole_conn.CreateCommand();
                ole_cmd.CommandText = sql;
                return ole_cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                ole_conn.Close();
            }
        }

        public static int UpdateExcelTable(string filePath, object obj, string sql)
        {
            String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;'";
            //实例化一个Oledbconnection类(实现了IDisposable,要using)
            OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
            try
            {
                ole_conn.Open();
                OleDbCommand ole_cmd = ole_conn.CreateCommand();
                ole_cmd.CommandText = sql;
                return ole_cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                ole_conn.Close();
            }
        }

        public bool SaveDataTableToExcel(object obj, string filePath)
        {
            try
            {
                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;IMEX=2'";
                //实例化一个Oledbconnection类(实现了IDisposable,要using)
                OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
                ole_conn.Open();
                OleDbCommand ole_cmd = ole_conn.CreateCommand();
                PropertyInfo[] propertys = obj.GetType().GetProperties();
                int i = 0;
                foreach (PropertyInfo pinfo in propertys)
                {
                    if (i == 0)
                    {
                        ole_cmd.CommandText = "insert into 工具信息(序列号,型号,工位信息,扭矩信息,工具当前状态,质保期,仓库中备件,保养合同类型,保养合同起止,备注信息,保养信息,维修记录) values(" + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    else
                    {
                        ole_cmd.CommandText += ", " + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    i++;
                }
                ole_cmd.CommandText += ")";
                ole_cmd.ExecuteNonQuery();
                //MessageBox.Show("生成Excel文件成功并写入一条数据......");
                return true;
            }
            catch (Exception err)
            {
                Console.Write(err);
                //MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            finally
            {
            }
        }

        public bool CreateAndSaveDateToExcel(object obj, string filePath)
        {
            try
            {
                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;'";
                //实例化一个Oledbconnection类(实现了IDisposable,要using)
                OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
                ole_conn.Open();
                OleDbCommand ole_cmd = ole_conn.CreateCommand();
                ole_cmd.CommandText = ConfigurationManager.AppSettings["CreateExcelString"];
                ole_cmd.ExecuteNonQuery();
                PropertyInfo[] propertys = obj.GetType().GetProperties();
                int i = 0;
                foreach (PropertyInfo pinfo in propertys)
                {
                    if (i == 0)
                    {
                        ole_cmd.CommandText = "insert into 工具信息(序列号,型号,工位信息,扭矩信息,工具当前状态,质保期,仓库中备件,保养合同类型,保养合同起止,备注信息,保养信息,维修记录) values(" + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    else
                    {
                        ole_cmd.CommandText += ", " + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    i++;
                }
                ole_cmd.CommandText += ")";
                ole_cmd.ExecuteNonQuery();
                //MessageBox.Show("生成Excel文件成功并写入一条数据......");
                return true;
            }
            catch (Exception err)
            {
                Console.Write(err);
                //MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                //MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public bool CreateAndSaveOnCallRecordToExcel(object obj, string filePath)
        {
            try
            {
                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;'";
                //实例化一个Oledbconnection类(实现了IDisposable,要using)
                OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
                ole_conn.Open();
                OleDbCommand ole_cmd = ole_conn.CreateCommand();
                ole_cmd.CommandText = ConfigurationManager.AppSettings["CreateOnCallRecordExcelString"];
                //ole_cmd.CommandText = Declare.CreateOnCallRecordExcelString;
                ole_cmd.ExecuteNonQuery();
                PropertyInfo[] propertys = obj.GetType().GetProperties();
                int i = 0;
                foreach (PropertyInfo pinfo in propertys)
                {
                    if (i == 0)
                    {
                        ole_cmd.CommandText = "insert into 巡线记录(客户呼叫时间,达到现场时间,故障工具,故障原因,备注) values(" + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    else
                    {
                        ole_cmd.CommandText += ", " + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    i++;
                }
                ole_cmd.CommandText += ")";
                ole_cmd.ExecuteNonQuery();
                //MessageBox.Show("生成Excel文件成功并写入一条数据......");
                return true;
            }
            catch (Exception err)
            {
                Console.Write(err);
                //MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                //MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public bool CreateAndSaveRepoSpareToolToExcel(object obj, string filePath)
        {
            try
            {
                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;'";
                //实例化一个Oledbconnection类(实现了IDisposable,要using)
                OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
                ole_conn.Open();
                OleDbCommand ole_cmd = ole_conn.CreateCommand();
                ole_cmd.CommandText = ConfigurationManager.AppSettings["CreatRepoSpareToolExcelString"];
                //ole_cmd.CommandText = Declare.CreatRepoSpareToolExcelString;
                ole_cmd.ExecuteNonQuery();
                PropertyInfo[] propertys = obj.GetType().GetProperties();
                int i = 0;
                foreach (PropertyInfo pinfo in propertys)
                {
                    if (i == 0)
                    {
                        ole_cmd.CommandText = "insert into 仓库备件(备件型号,个数,入库时间,备件序列号) values(" + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    else
                    {
                        ole_cmd.CommandText += ", " + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    i++;
                }
                ole_cmd.CommandText += ")";
                ole_cmd.ExecuteNonQuery();
                //MessageBox.Show("生成Excel文件成功并写入一条数据......");
                return true;
            }
            catch (Exception err)
            {
                Console.Write(err);
                //MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                //MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public bool CreateAndSaveMaintainManageInfoToExcel(object obj, string filePath)
        {
            try
            {
                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;'";
                //实例化一个Oledbconnection类(实现了IDisposable,要using)
                OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
                ole_conn.Open();
                OleDbCommand ole_cmd = ole_conn.CreateCommand();
                ole_cmd.CommandText = ConfigurationManager.AppSettings["CreatMaintainManageInfoExcelString"];
                //ole_cmd.CommandText = Declare.CreatMaintainManageInfoExcelString;
                ole_cmd.ExecuteNonQuery();
                PropertyInfo[] propertys = obj.GetType().GetProperties();
                int i = 0;
                foreach (PropertyInfo pinfo in propertys)
                {
                    if (i == 0)
                    {
                        ole_cmd.CommandText = "insert into 工具维修信息(工具型号,工具序列号,送修时间,工具维修状态,送修描述) values(" + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    else
                    {
                        ole_cmd.CommandText += ", " + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    i++;
                }
                ole_cmd.CommandText += ")";
                ole_cmd.ExecuteNonQuery();
                //MessageBox.Show("生成Excel文件成功并写入一条数据......");
                return true;
            }
            catch (Exception err)
            {
                Console.Write(err);
                //MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                //MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public bool SaveDataMaintainManageInfoToExcel(object obj, string filePath)
        {
            try
            {
                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;IMEX=2'";
                //实例化一个Oledbconnection类(实现了IDisposable,要using)
                OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
                ole_conn.Open();
                OleDbCommand ole_cmd = ole_conn.CreateCommand();
                PropertyInfo[] propertys = obj.GetType().GetProperties();
                int i = 0;
                foreach (PropertyInfo pinfo in propertys)
                {
                    if (i == 0)
                    {
                        ole_cmd.CommandText = "insert into 工具维修信息(工具型号,工具序列号,送修时间,工具维修状态,送修描述) values(" + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    else
                    {
                        ole_cmd.CommandText += ", " + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    i++;
                }
                ole_cmd.CommandText += ")";
                ole_cmd.ExecuteNonQuery();
                //MessageBox.Show("生成Excel文件成功并写入一条数据......");
                return true;
            }
            catch (Exception err)
            {
                Console.Write(err);
                //MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                //MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            finally
            {
            }
        }
    }
}
