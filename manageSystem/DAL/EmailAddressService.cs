﻿using System.Collections.Generic;
using System.Data.SQLite;
using System.Configuration;
using Model;
using System;

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
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new EmailAddress
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        EmailAddr = reader["EmailAddr"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"getAllEmailAddrFromDb failed, error message is: {ex.Message}");
                }
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
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            while (reader.Read())
            {
                try
                {
                    list.Add(new EmailAddress
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        EmailAddr = reader["EmailAddr"].ToString()
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"GetEmailAddresses failed, error message is: {ex.Message}");
                }
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
