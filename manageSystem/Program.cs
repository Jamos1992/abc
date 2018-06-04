using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL;
using manageSystem.src.demarcate_manage;

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
 //           SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            new DBUtil().CeateAllTable();
            //            db.CloseConnection();
            //Application.Run(new LoginForm());
            //Application.Run(new QRCodePrintForm());
            //Application.Run(new AddDemarcateForm());
            //Application.Run(new DemarcateOperatorForm());
            Application.Run(new DemarcateOperationForm());
        }
    }
}
