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
        public string Time { get; set; }                            //入库时间
    }
}
