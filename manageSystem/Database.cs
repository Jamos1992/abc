using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace manageSystem
{
    class Database
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\database\Database1.mdb");
        public Database()
        {
            conn.Open();
            Console.WriteLine("连接数据库成功");
        }

        public DataRowCollection QueryBySql(string sql)
        {
            //获取表1的内容
            OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter(sql, conn); //创建适配对象
            DataTable dt = new DataTable(); //新建表对象
            dbDataAdapter.Fill(dt); //用适配对象填充表对象
            //foreach (DataRow item in dt.Rows)
            //{
            //    Console.WriteLine(item[0] + " | " + item[1] + " | "+item[2]);
            //}
            return dt.Rows;
        }

        public bool InsertBySql(string sql)
        {
            //往表1添加一条记录，昵称是LanQ，账号是2545493686
            OleDbCommand oleDbCommand = new OleDbCommand(sql, conn);
            int i = oleDbCommand.ExecuteNonQuery(); //返回被修改的数目
            return i > 0;
        }

        public bool DeleteBySql(string sql)
        {
            //删除昵称为LanQ的记录
            OleDbCommand oleDbCommand = new OleDbCommand(sql, conn);
            int i = oleDbCommand.ExecuteNonQuery();
            return i > 0;
        }

        public bool UpdateBySql(string sql)
        {
            //将表1中昵称为东熊的账号修改成233333
            OleDbCommand oleDbCommand = new OleDbCommand(sql, conn);
            int i = oleDbCommand.ExecuteNonQuery();
            return i > 0;
        }
    }
}
