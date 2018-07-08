using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class RepoSpareTool
    {
        public string SpareToolModel { get; set; }                  //备件型号
        public int Num { get; set; }                                //备件数量
        public string AddTime { get; set; }                         //入库时间
    }

    public class SpareToolUseHistory
    {
        public string SpareToolModel { get; set; }                  //备件型号
        public int Num { get; set; }                                //消耗个数
        public string UseTime { get; set; }                         //消耗时间
    }
}
