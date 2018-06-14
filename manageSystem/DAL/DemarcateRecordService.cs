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
            SQLiteDataReader reader = SQLHelper.ReadFullTable("DemarcateTools");
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
            string sql = "select * from DemarcateTools where SerialNum='" + serialNum + "'";
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

        //public string ExportSingleData2Excel(string filePath, RepoSpareTool repoSpareTool)
        //{
        //    int affected = repoSpareToolService.CreatRepoSpareToolExcelTable(filePath);
        //    if (affected < 1) return "创建导出文件失败";
        //    affected = repoSpareToolService.InsertRepoSpareTool2ExcelTable(filePath, repoSpareTool);
        //    if (affected < 1) return "导出数据失败";
        //    return "导出数据成功";
        //}

        //public string ExportBatchData2Excel(string filePath, RepoSpareTool[] repoSpareTools)
        //{
        //    int i = 0;
        //    foreach (RepoSpareTool repoSpareTool in repoSpareTools)
        //    {
        //        if (repoSpareTool == null)
        //        {
        //            continue;
        //        }
        //        if (i == 0)
        //        {
        //            string result = ExportSingleData2Excel(filePath, repoSpareTool);
        //            if (result.Contains("失败"))
        //            {
        //                return result;
        //            }
        //        }
        //        else
        //        {
        //            int affected = repoSpareToolService.InsertRepoSpareTool2ExcelTable(filePath, repoSpareTool);
        //            if (affected < 1) return "导出数据失败";
        //        }
        //    }
        //    return "导出数据成功";
        //}
    }
}
