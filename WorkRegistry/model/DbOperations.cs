using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace WorkRegistry.model
{
    public static class DbOperations
    {
        // Stores the connection object to the database
        public static SQLiteConnection Db;
        public static String DbPath = "C:\\Db\\workRegistryDb.sqlite";

        public static void InitDatabase()
        {
            if (!File.Exists(DbPath))
                /*if (!Directory.Exists(DbPath))
                    Directory.CreateDirectory(DbPath);*/
                File.Create("C:\\Db\\workRegistryDb.sqlite");
            var Connection = new SQLiteConnection(DbPath);
            Connection.CreateTable<Worker>();
            Connection.CreateTable<Event>();
            Connection.CreateTable<WorkerTeam>();
            Connection.CreateTable<Team>();
            Db = Connection;
        }

        // Returns true if the add to the database is successful
        public static Boolean AddWorker(Worker worker)
        {
            var result = Db.Insert(worker);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int DeleteWorker(Worker worker)
        {
            var result = Db.Delete(worker);
            return result;
        }

        public static List<Worker> GetAllWorkers()
        {
            return Db.Query<Worker>("SELECT * FROM WORKER");
        }
    }
}
