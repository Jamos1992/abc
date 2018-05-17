using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace manageSystem.src.maintain_manage
{
    public partial class RepairOperatorForm : Form
    {
        public RepairOperatorForm()
        {
            InitializeComponent();
            comboBox1.Text = RepairManageForm.ToolSerialName;
        }

        private string[] getHintFromDb()
        {
            string[] records = new string[] { };
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            try
            {
                SQLiteDataReader reader = db.ReadTable("ToolsInfo", new string[] { "Model" }, new string[] { "Model" }, new string[] { "like" }, new string[] { "'%%'" });
                if (!reader.HasRows)
                {
                    Console.Write("no such record");
                    return null;
                }
                List<string> recordList = records.ToList();
                while (reader.Read())
                {
                    recordList.Add(reader.GetString(reader.GetOrdinal("Model")));

                }
                records = recordList.ToArray();
            }
            catch
            {
                Console.WriteLine("query db fail");
                return null;
            }

            return records;
        }

        private void InitTextBoxHint()
        {
            string[] str = this.getHintFromDb();
            if (str == null)
            {
                return;
            }
            Console.WriteLine(str);
            comboBox1.Items.AddRange(str);
        }
    }
}
