using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class CommonService
    {
        public Dictionary<string, int> ConvertStr2Dic(string str)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string[] kvList = str.Split(',');
            foreach (string kv in kvList)
            {
                string[] kvPair = kv.Split(':');
                if (kvPair.Length < 2)
                {
                    return null;
                }
                dic.Add(kvPair[0], int.Parse(kvPair[1]));
            }
            return dic;
        }

        public string ConvertDic2Str(Dictionary<string, int> dic)
        {
            if (dic == null) return "";
            List<string> kvList = new List<string>();
            foreach (var item in dic)
            {
                string kvPair = string.Join(":", new string[] { item.Key, item.Value.ToString() });
                kvList.Add(kvPair);
            }
            return string.Join(",", kvList.ToArray());
        }
    }
}
