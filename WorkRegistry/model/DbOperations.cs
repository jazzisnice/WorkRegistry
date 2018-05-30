using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using SQLiteNetExtensions.Extensions;

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
            Connection.CreateTable<Work>();
            Connection.CreateTable<WorkerTeam>();
            Connection.CreateTable<Team>();
            Connection.CreateTable<Car>();
            Db = Connection;
        }

        internal static void AddOrEditCar(Car car)
        {
            Db.InsertOrReplaceWithChildren(car);
        }

        internal static void RemoveCar(Car car)
        {
            Db.Delete(car);
        }

        // Returns true if the add to the database is successful
        public static void AddOrEditTeam(Team newTeam)
        {
            Db.InsertOrReplaceWithChildren(newTeam);
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
            return Db.GetAllWithChildren<Worker>();
        }

        public static List<Team> GetAllTeams()
        {
            return Db.GetAllWithChildren<Team>();
        }

        public static List<Car> GetAllCars()
        {
            return Db.GetAllWithChildren<Car>();
        }

        internal static void DeleteTeam(Team currentTeam)
        {
            Db.Query<Team>("DELETE FROM WorkerTeam WHERE TeamId=?", currentTeam.Id.ToString());
            Db.Delete(currentTeam);
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

        public static List<Work> GetAllTasks()
        {
            return Db.GetAllWithChildren<Work>();
        }

        public static void AddWorkItem(int taskId, WorkItem workItem)
        {

        }
    }
}
