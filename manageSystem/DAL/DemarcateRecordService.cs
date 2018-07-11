using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
using Model;
using System.Data.SQLite;
using Util;
using System.Reflection;

namespace DAL
{
    public class DemarcateRecordService
    {
        private int QRCodeSize = 4;
        private int QRCodeVersion = 7;
        public Bitmap CreateQRCode(string content)
        {
            QRCodeEncoder qrEncoder = new QRCodeEncoder();
            qrEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrEncoder.QRCodeScale = QRCodeSize;
            qrEncoder.QRCodeVersion = QRCodeVersion;
            qrEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            try
            {
                Bitmap qrcode = qrEncoder.Encode(content, Encoding.UTF8);
                return qrcode;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("超出当前二维码版本的容量上限，请选择更高的二维码版本！", "系统提示:" + ex.Message);
                return new Bitmap(100, 100);
            }
            catch (Exception ex)
            {
                Console.WriteLine("生成二维码出错！", "系统提示:" + ex.Message);
                return new Bitmap(100, 100);
            }
        }

        public BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            BitmapImage bImage = new BitmapImage();
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            bImage.BeginInit();
            bImage.StreamSource = new MemoryStream(ms.ToArray());
            bImage.EndInit();
            return bImage;
        }

        public int InsertDemarcateTools2Db(DemarcateTools demarcateTools)
        {
            return SQLHelper.InsertValuesByStruct("DemarcateTools", demarcateTools);
        }

        public bool IsToolExistInDemarcateTools(string serialNum)
        {
            return GetOneDemarcateTool(serialNum) != null;
        }

        public List<DemarcateTools> GetAllDemarcateTools()
        {
            List<DemarcateTools> list = new List<DemarcateTools>();
            string sql = $"select * from DemarcateTools where Status!='{DemarcateStatusDeclare.OffGrade}'";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            if (!reader.HasRows)
            {
                Console.WriteLine("DemarcateTools no reocrd");
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new DemarcateTools
                    {
                        SerialNum = reader["SerialNum"].ToString(),
                        Cycle = Convert.ToInt32(reader["Cycle"]),
                        LastTime = Convert.ToDateTime(reader["LastTime"].ToString()).ToString("yyyy-MM-dd"),
                        NextTime = Convert.ToDateTime(reader["NextTime"].ToString()).ToString("yyyy-MM-dd"),
                        Status = reader["Status"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"GetAllDemarcateTools failed, error message is: {ex.Message}");
                }

            }
            reader.Close();
            return list;
        }

        public List<DemarcateTools> GetDemarcateToolsBySql(string sql)
        {
            List<DemarcateTools> list = new List<DemarcateTools>();
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            if (!reader.HasRows)
            {
                Console.WriteLine("DemarcateTools no reocrd");
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new DemarcateTools
                    {
                        SerialNum = reader["SerialNum"].ToString(),
                        Cycle = Convert.ToInt32(reader["Cycle"]),
                        LastTime = Convert.ToDateTime(reader["LastTime"].ToString()).ToString("yyyy-MM-dd"),
                        NextTime = Convert.ToDateTime(reader["NextTime"].ToString()).ToString("yyyy-MM-dd"),
                        Status = reader["Status"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"GetAllDemarcateTools failed, error message is: {ex.Message}");
                }

            }
            reader.Close();
            return list;
        }

        public List<DemarcateHistory> getDemarcateHistoryBySql(string sql)
        {
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            List<DemarcateHistory> list = new List<DemarcateHistory>();
            if (!reader.HasRows)
            {
                Console.WriteLine("DemarcateHistory no reocrd");
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new DemarcateHistory
                    {
                        DemarcateNum = reader["DemarcateNum"].ToString(),
                        SerialNum = reader["SerialNum"].ToString(),
                        Cycle = int.Parse(reader["Cycle"].ToString()),
                        LastTime = Convert.ToDateTime(reader["LastTime"].ToString()).ToString("yyyy-MM-dd"),
                        DemarcateTime = Convert.ToDateTime(reader["DemarcateTime"].ToString()).ToString("yyyy-MM-dd"),
                        NextTime = Convert.ToDateTime(reader["NextTime"].ToString()).ToString("yyyy-MM-dd"),
                        CheckMan = reader["CheckMan"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getDemarcateHistoryBySql failed, error message is: {ex.Message}");
                }
            }
            reader.Close();
            return list;
        }

        public List<ToolsInfo> GetAllDemarcateToolsBySql(string sql)
        {
            List<ToolsInfo> list = new List<ToolsInfo>();
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            if (!reader.HasRows)
            {
                Console.WriteLine("DemarcateTools no reocrd");
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
                        Workstation = reader["Workstation"].ToString(),
                        Model = reader["Model"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"GetAllDemarcateToolsBySql failed, error message is: {ex.Message}");
                }

            }
            reader.Close();
            return list;
        }

        public DemarcateTools GetOneDemarcateTool(string serialNum)
        {
            string sql = $"select * from DemarcateTools where SerialNum='{serialNum}' and Status!='{DemarcateStatusDeclare.OffGrade}'";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            DemarcateTools demarcateTools = new DemarcateTools();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            if (reader.Read())
            {
                try
                {
                    demarcateTools = new DemarcateTools
                    {
                        SerialNum = reader["SerialNum"].ToString(),
                        Cycle = Convert.ToInt32(reader["Cycle"]),
                        LastTime = Convert.ToDateTime(reader["LastTime"].ToString()).ToString("yyyy-MM-dd"),
                        NextTime = Convert.ToDateTime(reader["NextTime"].ToString()).ToString("yyyy-MM-dd"),
                        Status = reader["Status"].ToString()
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"GetOneDemarcateTool failed, error message is: {ex.Message}");
                }

            }
            reader.Close();
            return demarcateTools;
        }

        public int DeleteOneDemarcateTools(DemarcateTools demarcateTools)
        {
            return SQLHelper.DeleteValuesAND("DemarcateTools", new string[] { "SerialNum" }, new string[] { demarcateTools.SerialNum }, new string[] { "=" });
        }

        public int UpdateOneDemarcateTools(DemarcateTools demarcateTools)
        {
            return SQLHelper.UpdateValuesByStruct("DemarcateTools", demarcateTools, new string[] { "SerialNum" }, new string[] { demarcateTools.SerialNum });
        }

        public int UpdateOneDemarcateToolBySql(string sql)
        {
            return SQLHelper.UpdateTableBySql(sql);
        }

        public int InsertDemarcateHistory(DemarcateHistory demarcateHistory)
        {
            return SQLHelper.InsertValuesByStruct("DemarcateHistory", demarcateHistory);
        }

        public List<DemarcateHistory> GetDemarcateHistoriesBySerial(string serialNum)
        {
            string sql = $"select * from DemarcateHistory, ToolsInfo where DemarcateHistory.SerialNum=ToolsInfo.SerialNum and DemarcateHistory.SerialNum='{serialNum}' order by DemarcateTime desc;";
            SQLiteDataReader reader = SQLHelper.ReadTableBySql(sql);
            List<DemarcateHistory> list = new List<DemarcateHistory>();
            if (!reader.HasRows)
            {
                Console.WriteLine("DemarcateHistory no reocrd");
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new DemarcateHistory
                    {
                        DemarcateNum = reader["DemarcateNum"].ToString(),
                        SerialNum = reader["SerialNum"].ToString(),
                        Cycle = int.Parse(reader["Cycle"].ToString()),
                        LastTime = Convert.ToDateTime(reader["LastTime"].ToString()).ToString("yyyy-MM-dd"),
                        DemarcateTime = Convert.ToDateTime(reader["DemarcateTime"].ToString()).ToString("yyyy-MM-dd"),
                        NextTime = Convert.ToDateTime(reader["NextTime"].ToString()).ToString("yyyy-MM-dd"),
                        CheckMan = reader["CheckMan"].ToString(),
                        Model = reader["Model"].ToString(),
                        Category = reader["Category"].ToString(),
                        Name = reader["Name"].ToString(),
                        TorqueMin = double.Parse(reader["TorqueMin"].ToString()),
                        TorqueMax = double.Parse(reader["TorqueMax"].ToString()),
                        Accuracy = double.Parse(reader["Accuracy"].ToString()),
                        Section = reader["Section"].ToString(),
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
                    Console.WriteLine($"GetDemarcateHistoriesBySerial failed, error message is: {ex.Message}");
                }
            }
            reader.Close();
            return list;
        }

        //excel operation
        public int CreateDemarcateHistoryExcelTable(string filePath)
        {
            return EXCELHelper.CreateExcelTable(filePath, ExcelDeclare.CreateDemarcateHistoryExcelSql);
        }

        public int InsertDemarcateHistory2ExcelTable(string filePath, object obj)
        {
            string sql = ExcelDeclare.InsertDemarcateHistoryExcelSql;
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
    }
}
