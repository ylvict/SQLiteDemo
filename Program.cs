using System;
using System.Data.SQLite;

namespace SQLiteDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection conn = null;

            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            conn = new SQLiteConnection(dbPath);//Create database connection
            conn.Open();//open database connection, if the data file not exist, it will create an empty one.

            string sql = "CREATE TABLE IF NOT EXISTS student(id integer, name varchar(20), sex boolean);"; //create data table command
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();//if datatable not exist, create datatable

            SQLiteCommand cmdInsert = new SQLiteCommand(conn);
            cmdInsert.CommandText = "INSERT INTO student VALUES(1, 'Jack', 'True')"; //insert sample data
            cmdInsert.ExecuteNonQuery();
            cmdInsert.CommandText = "INSERT INTO student VALUES(2, 'Winnie', 'False')";
            cmdInsert.ExecuteNonQuery();
            cmdInsert.CommandText = "INSERT INTO student VALUES(3, 'Ben', 'True')";
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }

    }
}
