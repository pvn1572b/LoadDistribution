using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace LoadDistribution
{
    public static class DBConnection
    {
        public static SQLiteConnection con = new SQLiteConnection();

        static DBConnection()
        {
            string constring = @"DATA SOURCE=" + System.IO.Path.Combine(Environment.CurrentDirectory, "LoadDistribution.db") + "";
            con.ConnectionString = constring;
            con.Open();

        }
    }
}