using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Data.Common;
using System.Data;
using System;
using Announcements.Models;

namespace Announcements.Services
{
    public class AnnouncementService
    {
        public IEnumerable<Announcement> List()
        {
                    Console.WriteLine("aaa");
            using (SqliteConnection conn = new SqliteConnection("Data Source=/Users/nwang/Sites/announcements/doc/database/sqlite/announcements.db;FailIfMissing=True;"))
            {
                List<Announcement> result = new List<Announcement>();
                conn.Open();
                SqliteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from t_announcements";
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("bbb");
                    string content = dr.GetString(dr.GetOrdinal("content"));
                    Console.WriteLine(content);
                    Announcement a = new Announcement(content);
                    result.Add(a);
                }
                return result;
            }
                    Console.WriteLine("ccc");
        }

        public Announcement Get()
        {
            using (SqliteConnection conn = new SqliteConnection("Data Source=/Users/nwang/Sites/announcements/doc/database/sqlite/announcements.db;FailIfMissing=True;"))
            {
                conn.Open();
                SqliteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from t_announcements";
                IDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Announcement a = new Announcement(dr.GetString(dr.GetOrdinal("content")));

                    return a;
                } else {
                    return null;
                }
            }
            
        }
    }
}
