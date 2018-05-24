using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Model;
using System.Data.OleDb;
using System.Data;
using System.Reflection;
using System.Configuration;

namespace DAL
{
    public class ToolsInfoService
    {

        public bool IsToolExist(ToolsInfo toolsInfo)
        {
            return getOneToolsInfoBySerial(toolsInfo.SerialNum) != null;
        }
        public int AddTools(ToolsInfo toolsInfo)
        {
            return SQLHelper.InsertValuesByStruct("ToolsInfo", toolsInfo);
        }

        public ToolsInfo getOneToolsInfoBySerial(string SerialNum)
        {
            SQLiteDataReader reader = SQLHelper.ReadTable("ToolsInfo", new string[] { "*" }, new string[] { "SerialNum" }, new string[] { "=" }, new string[] { SerialNum });
            ToolsInfo toolsInfo = new ToolsInfo();
            while (reader.Read())
            {
                toolsInfo.SerialNum = reader["SerialNum"].ToString();
                toolsInfo.Model = reader["Model"].ToString();
                toolsInfo.Torque = reader["Torque"].ToString();
                toolsInfo.Status = reader["Status"].ToString();
                toolsInfo.QualityAssureDate = reader["QualityAssureDate"].ToString();
                toolsInfo.RepoSpareTool = reader["RepoSpareTool"].ToString();
                toolsInfo.MaintainContractDateStart = reader["MaintainContractDateStart"].ToString();
                toolsInfo.MaintainContractDateEnd = reader["MaintainContractDateEnd"].ToString();
                toolsInfo.Remark = reader["Reader"].ToString();
                toolsInfo.MaintainInfo = reader["MaintainInfo"].ToString();
                toolsInfo.RepairList = reader["RepairList"].ToString();
            }
            if (reader != null) reader.Close();
            return toolsInfo;
        }

        public ToolsInfo getOneToolsInfoBySerialAndModel(string SerialNum, string Model)
        {
            SQLiteDataReader reader = SQLHelper.ReadTable("ToolsInfo", new string[] { "*" }, new string[] { "SerialNum", "Model" }, new string[] { "=", "=" }, new string[] { SerialNum, Model });
            ToolsInfo toolsInfo = new ToolsInfo();
            while (reader.Read())
            {
                toolsInfo.SerialNum = reader["SerialNum"].ToString();
                toolsInfo.Model = reader["Model"].ToString();
                toolsInfo.Torque = reader["Torque"].ToString();
                toolsInfo.Status = reader["Status"].ToString();
                toolsInfo.QualityAssureDate = reader["QualityAssureDate"].ToString();
                toolsInfo.RepoSpareTool = reader["RepoSpareTool"].ToString();
                toolsInfo.MaintainContractDateStart = reader["MaintainContractDateStart"].ToString();
                toolsInfo.MaintainContractDateEnd = reader["MaintainContractDateEnd"].ToString();
                toolsInfo.Remark = reader["Reader"].ToString();
                toolsInfo.MaintainInfo = reader["MaintainInfo"].ToString();
                toolsInfo.RepairList = reader["RepairList"].ToString();
            }
            if (reader != null) reader.Close();
            return toolsInfo;
        }

        public int updateToolsInfo(ToolsInfo toolsInfo, string SerialNum)
        {
            return SQLHelper.UpdateValuesByStruct("ToolsInfo", toolsInfo, new string[] { "SerialNum" }, new string[] { SerialNum });
        }

        public List<ToolsInfo> getAllToolsInfo()
        {
            SQLiteDataReader reader = SQLHelper.ReadFullTable("ToolsInfo");
            List<ToolsInfo> list = new List<ToolsInfo>();
            while (reader.Read())
            {
                list.Add(new ToolsInfo
                {
                    SerialNum = reader["SerialNum"].ToString(),
                    Model = reader["Model"].ToString(),
                    Torque = reader["Torque"].ToString(),
                    Status = reader["Status"].ToString(),
                    QualityAssureDate = reader["QualityAssureDate"].ToString(),
                    RepoSpareTool = reader["RepoSpareTool"].ToString(),
                    MaintainContractDateStart = reader["MaintainContractDateStart"].ToString(),
                    MaintainContractDateEnd = reader["MaintainContractDateEnd"].ToString(),
                    Remark = reader["Reader"].ToString(),
                    MaintainInfo = reader["MaintainInfo"].ToString(),
                    RepairList = reader["RepairList"].ToString(),
                });
            }
            if (reader != null) reader.Close();
            return list;
        }

        public List<ToolsInfo> getAllToolsInfoByModel(string model)
        {
            SQLiteDataReader reader = SQLHelper.ReadTableBySql("select * from ToolsInfo where Model='" + model + "'");
            List<ToolsInfo> list = new List<ToolsInfo>();
            while (reader.Read())
            {
                list.Add(new ToolsInfo
                {
                    SerialNum = reader["SerialNum"].ToString(),
                    Model = reader["Model"].ToString(),
                    Torque = reader["Torque"].ToString(),
                    Status = reader["Status"].ToString(),
                    QualityAssureDate = reader["QualityAssureDate"].ToString(),
                    RepoSpareTool = reader["RepoSpareTool"].ToString(),
                    MaintainContractDateStart = reader["MaintainContractDateStart"].ToString(),
                    MaintainContractDateEnd = reader["MaintainContractDateEnd"].ToString(),
                    Remark = reader["Reader"].ToString(),
                    MaintainInfo = reader["MaintainInfo"].ToString(),
                    RepairList = reader["RepairList"].ToString(),
                });
            }
            if (reader != null) reader.Close();
            return list;
        }

        //excel operation
        public int CreateToolsInfoExcelTable(string filePath)
        {
            return EXCELHelper.CreateExcelTable(filePath, ConfigurationManager.AppSettings["CreateExcelString"]);
        }

        public int InsertToolsInfo2ExcelTable(string filePath, object obj)
        {
            string sql = "insert into 工具信息(序列号,型号,工位信息,扭矩信息,工具当前状态,质保期,仓库中备件,保养合同类型,保养合同起止,备注信息,保养信息,维修记录)";
            return EXCELHelper.InsertExcelTable(filePath, obj, sql);
        }


        //public bool CreateAndSaveDateToExcel(object obj, string filePath)
        //{
        //    int affected = 
        //    if(affected < 1)
        //    {

        //    }
        //    try
        //    {
        //        String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties='Excel 8.0;HDR=Yes;'";
        //        //实例化一个Oledbconnection类(实现了IDisposable,要using)
        //        OleDbConnection ole_conn = new OleDbConnection(sConnectionString);
        //        ole_conn.Open();
        //        OleDbCommand ole_cmd = ole_conn.CreateCommand();
        //        ole_cmd.CommandText = ConfigurationManager.AppSettings["CreateExcelString"];
        //        ole_cmd.ExecuteNonQuery();
        //        PropertyInfo[] propertys = obj.GetType().GetProperties();
        //        int i = 0;
        //        foreach (PropertyInfo pinfo in propertys)
        //        {
        //            if (i == 0)
        //            {
        //                ole_cmd.CommandText = "insert into 工具信息(序列号,型号,工位信息,扭矩信息,工具当前状态,质保期,仓库中备件,保养合同类型,保养合同起止,备注信息,保养信息,维修记录) values(" + "'" + pinfo.GetValue(obj, null) + "'";
        //            }
        //            else
        //            {
        //                ole_cmd.CommandText += ", " + "'" + pinfo.GetValue(obj, null) + "'";
        //            }
        //            i++;
        //        }
        //        ole_cmd.CommandText += ")";
        //        ole_cmd.ExecuteNonQuery();
        //        //MessageBox.Show("生成Excel文件成功并写入一条数据......");
        //        return true;
        //    }
        //    catch (Exception err)
        //    {
        //        Console.Write(err);
        //        //MessageBox.Show("导出Excel出错！错误原因：" + err.Message, "提示信息",
        //        //MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return false;
        //    }
        //}
    }
}
