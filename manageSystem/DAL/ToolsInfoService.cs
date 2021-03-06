﻿using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Reflection;
using System.Data.OleDb;
using Util;

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

        public int updateToolsInfoBySql(string sql)
        {
            return SQLHelper.UpdateTableBySql(sql);
        }

        public ToolsInfo getOneToolsInfoBySerial(string SerialNum)
        {
            SQLiteDataReader reader = SQLHelper.ReadTable("ToolsInfo", new string[] { "*" }, new string[] { "SerialNum" }, new string[] { "=" }, new string[] { "'" + SerialNum + "'" });
            ToolsInfo toolsInfo = new ToolsInfo();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    toolsInfo.SerialNum = reader["SerialNum"].ToString();
                    toolsInfo.Model = reader["Model"].ToString();
                    toolsInfo.Category = reader["Category"].ToString();
                    toolsInfo.Name = reader["Name"].ToString();
                    toolsInfo.TorqueMin = double.Parse(reader["TorqueMin"].ToString());
                    toolsInfo.TorqueMax = double.Parse(reader["TorqueMax"].ToString());
                    toolsInfo.Accuracy = double.Parse(reader["Accuracy"].ToString());
                    toolsInfo.Section = reader["Section"].ToString();
                    toolsInfo.DemarcateCycle = int.Parse(reader["DemarcateCycle"].ToString());
                    toolsInfo.Workstation = reader["Workstation"].ToString();
                    toolsInfo.Status = reader["Status"].ToString();
                    toolsInfo.QualityAssureDate = reader["QualityAssureDate"].ToString();
                    toolsInfo.MaintainContractStyle = reader["MaintainContractStyle"].ToString();
                    toolsInfo.MaintainContractDate = reader["MaintainContractDate"].ToString();
                    toolsInfo.RepairTimes = int.Parse(reader["RepairTimes"].ToString());
                    toolsInfo.Remark = reader["Remark"].ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getOneToolsInfoBySerial failed, error message is: {ex.Message}");
                }
            }
            if (reader != null) reader.Close();
            return toolsInfo;
        }

        public ToolsInfo getOneToolsInfoBySerialAndModel(string SerialNum, string Model)
        {
            SQLiteDataReader reader = SQLHelper.ReadTable("ToolsInfo", new string[] { "*" }, new string[] { "SerialNum", "Model" }, new string[] { "=", "=" }, new string[] { "'" + SerialNum + "'", "'" + Model + "'" });
            ToolsInfo toolsInfo = new ToolsInfo();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    toolsInfo.SerialNum = reader["SerialNum"].ToString();
                    toolsInfo.Model = reader["Model"].ToString();
                    toolsInfo.Category = reader["Category"].ToString();
                    toolsInfo.Name = reader["Name"].ToString();
                    toolsInfo.TorqueMin = double.Parse(reader["TorqueMin"].ToString());
                    toolsInfo.TorqueMax = double.Parse(reader["TorqueMax"].ToString());
                    toolsInfo.Accuracy = double.Parse(reader["Accuracy"].ToString());
                    toolsInfo.Section = reader["Section"].ToString();
                    toolsInfo.DemarcateCycle = int.Parse(reader["DemarcateCycle"].ToString());
                    toolsInfo.Workstation = reader["Workstation"].ToString();
                    toolsInfo.Status = reader["Status"].ToString();
                    toolsInfo.QualityAssureDate = reader["QualityAssureDate"].ToString();
                    toolsInfo.MaintainContractStyle = reader["MaintainContractStyle"].ToString();
                    toolsInfo.MaintainContractDate = reader["MaintainContractDate"].ToString();
                    toolsInfo.RepairTimes = int.Parse(reader["RepairTimes"].ToString());
                    toolsInfo.Remark = reader["Remark"].ToString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getOneToolsInfoBySerialAndModel failed, error message is: {ex.Message}");
                }
            }
            if (reader != null) reader.Close();
            return toolsInfo;
        }

        public int updateToolsInfo(ToolsInfo toolsInfo)
        {
            return SQLHelper.UpdateValuesByStruct("ToolsInfo", toolsInfo, new string[] { "SerialNum" }, new string[] { toolsInfo.SerialNum });
        }

        public List<ToolsInfo> getAllToolsInfo()
        {
            SQLiteDataReader reader = SQLHelper.ReadFullTable("ToolsInfo");
            List<ToolsInfo> list = new List<ToolsInfo>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new ToolsInfo
                    {
                        SerialNum = reader["SerialNum"].ToString(),
                        Model = reader["Model"].ToString(),
                        Category = reader["Category"].ToString(),
                        Name = reader["Name"].ToString(),
                        TorqueMin = double.Parse(reader["TorqueMin"].ToString()),
                        TorqueMax = double.Parse(reader["TorqueMax"].ToString()),
                        Accuracy = double.Parse(reader["Accuracy"].ToString()),
                        Section = reader["Section"].ToString(),
                        DemarcateCycle = int.Parse(reader["DemarcateCycle"].ToString()),
                        Workstation = reader["Workstation"].ToString(),
                        Status = reader["Status"].ToString(),
                        QualityAssureDate = reader["QualityAssureDate"].ToString(),
                        MaintainContractStyle = reader["MaintainContractStyle"].ToString(),
                        MaintainContractDate = reader["MaintainContractDate"].ToString(),
                        RepairTimes = int.Parse(reader["RepairTimes"].ToString() == "" ? "0" : reader["RepairTimes"].ToString()),
                        Remark = reader["Remark"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getAllToolsInfo failed, error message is: {ex.Message}");
                }
            }
            if (reader != null) reader.Close();
            return list;
        }

        public List<string> getAllSection()
        {
            string sql = "select distinct Section from ToolsInfo";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            List<string> list = new List<string>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(reader["Section"].ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getAllSection failed, error message is: {ex.Message}");
                }
            }
            if (reader != null) reader.Close();
            return list;
        }

        public List<string> getAllWorkstationBySection(string section)
        {
            string sql = $"select distinct Workstation from ToolsInfo where Section='{section}'";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            List<string> list = new List<string>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(reader["Workstation"].ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getAllWorkstationBySection failed, error message is: {ex.Message}");
                }
            }
            if (reader != null) reader.Close();
            return list;
        }

        public List<string> getAllSerilaNumByWorkstation(string workstation)
        {
            string sql = $"select distinct SerialNum from ToolsInfo where Workstation='{workstation}'";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            List<string> list = new List<string>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(reader["SerialNum"].ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getAllSerilaNumByWorkstation failed, error message is: {ex.Message}");
                }
            }
            if (reader != null) reader.Close();
            return list;
        }

        public List<ToolsInfo> getAllToolsInfoByModel(string model)
        {
            SQLiteDataReader reader = SQLHelper.ReadTableBySql("select * from ToolsInfo where Model='" + model + "'");
            List<ToolsInfo> list = new List<ToolsInfo>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new ToolsInfo
                    {
                        SerialNum = reader["SerialNum"].ToString(),
                        Model = reader["Model"].ToString(),
                        Category = reader["Category"].ToString(),
                        Name = reader["Name"].ToString(),
                        TorqueMin = double.Parse(reader["TorqueMin"].ToString()),
                        TorqueMax = double.Parse(reader["TorqueMax"].ToString()),
                        Accuracy = double.Parse(reader["Accuracy"].ToString()),
                        Section = reader["Section"].ToString(),
                        DemarcateCycle = int.Parse(reader["DemarcateCycle"].ToString()),
                        Workstation = reader["Workstation"].ToString(),
                        Status = reader["Status"].ToString(),
                        QualityAssureDate = reader["QualityAssureDate"].ToString(),
                        MaintainContractStyle = reader["MaintainContractStyle"].ToString(),
                        MaintainContractDate = reader["MaintainContractDate"].ToString(),
                        RepairTimes = int.Parse(reader["RepairTimes"].ToString() == "" ? "0" : reader["RepairTimes"].ToString()),
                        Remark = reader["Remark"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getAllToolsInfoByModel failed, error message is: {ex.Message}");
                }

            }
            if (reader != null) reader.Close();
            return list;
        }

        public List<ToolsInfo> getAllToolsInfoBySql(string sql)
        {
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            List<ToolsInfo> list = new List<ToolsInfo>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new ToolsInfo
                    {
                        SerialNum = reader["SerialNum"].ToString(),
                        Model = reader["Model"].ToString(),
                        Category = reader["Category"].ToString(),
                        Name = reader["Name"].ToString(),
                        TorqueMin = double.Parse(reader["TorqueMin"].ToString()),
                        TorqueMax = double.Parse(reader["TorqueMax"].ToString()),
                        Accuracy = double.Parse(reader["Accuracy"].ToString()),
                        Section = reader["Section"].ToString(),
                        DemarcateCycle = int.Parse(reader["DemarcateCycle"].ToString()),
                        Workstation = reader["Workstation"].ToString(),
                        Status = reader["Status"].ToString(),
                        QualityAssureDate = reader["QualityAssureDate"].ToString(),
                        MaintainContractStyle = reader["MaintainContractStyle"].ToString(),
                        MaintainContractDate = reader["MaintainContractDate"].ToString(),
                        RepairTimes = int.Parse(reader["RepairTimes"].ToString() == "" ? "0" : reader["RepairTimes"].ToString()),
                        Remark = reader["Remark"].ToString()
                    });
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"getAllToolsInfoBySql failed, error message is: {ex.Message}");
                }
                
            }
            if (reader != null) reader.Close();
            return list;
        }

        //excel operation
        public bool IsToolsInfoRecordExist(string filePath)
        {
            string sql = "select * from 工具信息";
            OleDbDataReader reader = EXCELHelper.LoadDataFromExcel(filePath, sql);
            if (!reader.HasRows)
            {
                reader.Close();
                return false;
            }
            reader.Close();
            return true;
        }

        public int CreateToolsInfoExcelTable(string filePath)
        {
            string sql = ExcelDeclare.CreateToolsInfoExcelSql;
            return EXCELHelper.CreateExcelTable(filePath, sql);
        }

        public int InsertToolsInfo2ExcelTable(string filePath, object obj)
        {
            string sql = ExcelDeclare.InsertToolsInfoExcelSql;
            PropertyInfo[] propertys = obj.GetType().GetProperties();
            int i = 0;
            foreach (PropertyInfo pinfo in propertys)
            {
                if (i == 0)
                {
                    sql += " values(" + "'" + pinfo.GetValue(obj, null) + "'";
                }
                else
                {
                    sql += ", " + "'" + pinfo.GetValue(obj, null) + "'";
                }
                i++;
            }
            sql += ")";
            return EXCELHelper.InsertExcelTable(filePath, obj, sql);
        }

        public int UpdateCycleInToolsInfo(string serialNum,int cycle)
        {
            string sql = $"update ToolsInfo set DemarcateCycle={cycle} where SerialNum='{serialNum}'";
            return SQLHelper.UpdateTableBySql(sql);
        }
        public List<ToolsInfo> getAllToolsFromExcel(string filePath)
        {
            string sql = "select * from 工具信息";
            OleDbDataReader reader = EXCELHelper.LoadDataFromExcel(filePath, sql);
            List<ToolsInfo> list = new List<ToolsInfo>();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new ToolsInfo
                    {
                        SerialNum = reader["工具序列号"].ToString(),
                        Model = reader["工具型号"].ToString(),
                        Category = reader["工具类别"].ToString(),
                        Name = reader["工具名称"].ToString(),
                        TorqueMin = double.Parse(reader["标定扭矩下限"].ToString()),
                        TorqueMax = double.Parse(reader["标定扭矩上限"].ToString()),
                        Accuracy = double.Parse(reader["精度"].ToString()),
                        Section = reader["工段"].ToString(),
                        DemarcateCycle = int.Parse(reader["标定周期"].ToString()),
                        Workstation = reader["工位"].ToString(),
                        Status = reader["工具状态"].ToString(),
                        QualityAssureDate = reader["质保期至"].ToString(),
                        MaintainContractStyle = reader["保养合同类型"].ToString(),
                        MaintainContractDate = reader["保养合同至"].ToString(),
                        RepairTimes = int.Parse(reader["累计维修次数"].ToString() == "" ? "0" : reader["累计维修次数"].ToString()),
                        Remark = reader["备注信息"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getAllToolsFromExcel failed, error message is: {ex.Message}");
                }

            }
            if (reader != null) reader.Close();
            return list;
        }
    }
}
