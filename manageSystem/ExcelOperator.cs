using System;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Interop.Excel;


namespace manageSystem
{
    class ExcelOperator
    {

        public DataSet LoadDataFromExcel(string filePath)
        {
            try
            {
                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;IMEX=2'";
                //实例化一个Oledbconnection类(实现了IDisposable,要using)
                OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
                ole_conn.Open();
                OleDbCommand ole_cmd = ole_conn.CreateCommand();
                //类似SQL的查询语句这个[Sheet1$对应Excel文件中的一个工作表]
                ole_cmd.CommandText = "select * from [Sheet1$]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(ole_cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Sheet1");
                ole_conn.Close();
                return ds;
            }
            catch (Exception err)
            {
                MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        public bool SaveDataTableToExcel(string filePath)
        {
            try
            {
                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;IMEX=2'";
                //实例化一个Oledbconnection类(实现了IDisposable,要using)
                OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
                ole_conn.Open();
                OleDbCommand ole_cmd = ole_conn.CreateCommand();
                ole_cmd.CommandText = "insert into [Sheet1$](商户ID,商家名称)values('DJ001','点击科技')";
                ole_cmd.ExecuteNonQuery();
                MessageBox.Show("数据插入成功......");
                return true;
            }           
            catch (Exception err)
            {
                MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ole_cmd.CommandText = Declare.CreateExcelString;
                ole_cmd.ExecuteNonQuery();
                PropertyInfo[] propertys = obj.GetType().GetProperties();
                int i = 0;
                foreach (PropertyInfo pinfo in propertys)
                {
                    if (i == 0)
                    {
                        ole_cmd.CommandText = "insert into 工具信息(序列号,型号,工位信息,扭矩信息,工具当前状态,质保期,仓库中备件,保养合同类型,保养合同起止,备注信息,保养信息,维修记录) values(" +  "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    else
                    {
                        ole_cmd.CommandText += ", " + "'" + pinfo.GetValue(obj, null) + "'";
                    }
                    i++;
                }
                ole_cmd.CommandText += ")";
                ole_cmd.ExecuteNonQuery();
                MessageBox.Show("生成Excel文件成功并写入一条数据......");
                return true;
            }
            catch (Exception err)
            {
                MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
    }
}
