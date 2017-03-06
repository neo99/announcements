using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Microsoft.Data.Sqlite;
using System.Data.Common;
using System.Data;
using System;
using Announcements.Models;
using Npgsql;

namespace Announcements.Services
{
    public class AnnouncementService
    {
        public IEnumerable<Announcement> List()
        {
            Console.WriteLine("aaa");
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Database=announcements;IntegratedSecurity=true;"))
            {
                List<Announcement> result = new List<Announcement>();
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select * from t_announcements", conn);
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
        }

        public IEnumerable<Announcement> ListSqlite()
        {
            Console.WriteLine("aaa");
            using (SqliteConnection conn = new SqliteConnection("Data Source=/Users/nwang/Sites/announcements/doc/database/sqlite/announcements.db;"))
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
        }

        public IEnumerable<Announcement> List2()
        {
                    Console.WriteLine("aaa");
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = "Datasource=localhost;Database=announcements;uid=root;pwd=;";
                    Console.WriteLine("conn");
                List<Announcement> result = new List<Announcement>();
                conn.Open();
                    Console.WriteLine("Sesame open");
                MySqlCommand cmd = conn.CreateCommand();
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
        }

        public Announcement Get()
        {
            using (MySqlConnection conn = new MySqlConnection())
            {
                conn.ConnectionString = "Datasource=localhost;Database=announcements;uid=root;pwd;";
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
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
