using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace WorkRegistry.model
{
    public static class DbOperations
    {
        // Stores the connection object to the database
        public static SQLiteConnection db;

        public static void InitDatabase()
        {
            var Connection = new SQLiteConnection("C:\\db\\workRegistryDb.sqlite");
            Connection.CreateTable<Worker>();
            Connection.CreateTable<Event>();
            Connection.CreateTable<WorkerTeam>();
            Connection.CreateTable<Team>();
            db = Connection;
        }

        // Returns true if the add to the database is successful
        public static Boolean AddWorker(Worker worker)
        {
            var result = db.Insert(worker);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Worker> GetAllWorkers()
        {
            return db.Query<Worker>("SELECT * FROM WORKER");
        }
    }
}
