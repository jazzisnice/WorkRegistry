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
        public static int AddOrEditTeam(Team newTeam)
        {
            return Db.InsertOrReplace(newTeam);
        }

        // Returns true if the add to the database is successful
        public static int AddOrEditWorker(Worker worker)
        {
            return Db.InsertOrReplace(worker);
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

        public static List<Team> GetAllTeams()
        {
            return Db.Query<Team>("SELECT * FROM TEAM");
        }

        // Returns workers which are NOT in the team given in the parameter
        public static List<Worker> GetExcludedWorkers(Team team)
        {
            List<Worker> AllWorkers = GetAllWorkers();
            List<Worker> TeamWorkers = team.Workers;

            List<Worker> ExcludedWorkers = new List<Worker>();

            foreach (Worker worker in AllWorkers)
            {
                if (!TeamWorkers.Contains(worker))
                {
                    ExcludedWorkers.Add(worker);
                }
            }

            return ExcludedWorkers;
        }
    }
}
