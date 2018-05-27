using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class CommonManage
    {
        private CommonService commonService = new CommonService();
        public Dictionary<string, int> ConvertStr2Dic(string str)
        {
            return commonService.ConvertStr2Dic(str);
        }

        public string ConvertDic2Str(Dictionary<string, int> dic)
        {
            return commonService.ConvertDic2Str(dic);
        }
    }
}
