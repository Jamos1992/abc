﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Data.SQLite;
using System.Net;
using System.Configuration;
using Model;
using System.Text.RegularExpressions;

namespace DAL
{
    public class EmailAddressService
    {
        public static string EmailAddrFrom = ConfigurationManager.AppSettings["EmailAddrFrom"];
        public static string EmailAddrPasswd = ConfigurationManager.AppSettings["EmailAddrPasswd"];

        public List<EmailAddress> getAllEmailAddrFromDb()
        {
            SQLiteDataReader reader = SQLHelper.ReadFullTable("EmailAddress");
            List<EmailAddress> list = new List<EmailAddress>();
            while (reader.Read())
            {
                list.Add(new EmailAddress
                {
                    EmailAddr = reader["EmailAddr"].ToString(),
                    ID = (int)reader["ID"]
                });
            }
            if (reader != null) reader.Close();
            return list;
        }

        public int InsertEmailAddress(string addr)
        {
            string sql = "INSERT INTO EmailAddress VALUES(null," + "'" + addr + "')";
            return SQLHelper.InsertTableBySql(sql);  
        }

        public List<EmailAddress> GetEmailAddresses(string addr)
        {
            List<EmailAddress> list = new List<EmailAddress>();
            SQLiteDataReader reader = SQLHelper.ReadTable("EmailAddress", new string[] { "*" }, new string[] { "EmailAddr" }, new string[] { "like" }, new string[] { "'%" + addr + "%'" });
            while (reader.Read())
            {
                list.Add(new EmailAddress
                {
                    ID = (int)reader["ID"],
                    EmailAddr = reader["EmailAddr"].ToString()
                });
            }
            if (reader != null) reader.Close();
            return list;
        }

        public int DeleteEmailAddress(string addr)
        {
            return SQLHelper.DeleteValuesAND("EmailAddress", new string[] { "EmailAddr" }, new string[] { addr }, new string[] { "=" });
        }
    }
}