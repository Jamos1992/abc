﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace manageSystem
{
    class Declare
    {
        public static string DbConnectionString = @"data source=d:\workspace\manageSystem\database\test.db";
        public static string CreateExcelString = "CREATE TABLE 工具信息 ([序列号] VarChar,[型号] VarChar,[工位信息] VarChar,[扭矩信息] VarChar,[工具当前状态] VarChar,[质保期] VarChar,[仓库中备件] VarChar,[保养合同类型] VarChar,[保养合同起止] VarChar,[备注信息] VarChar,[保养信息] VarChar,[维修记录] VarChar)";
    }
}
