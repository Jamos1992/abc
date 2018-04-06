﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace manageSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            db.CeateAllTable();
            db.CloseConnection();
            Application.Run(new LoginForm());
        }
    }
}
