using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkRegistry.model
{
    public class Team
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public string Name { get; set; }
        [ManyToMany(typeof(WorkerTeam))]
        public List<Worker> Workers { get; set; }

        public int DailyFeeSum
        {
            get
            {
                var result = 0;
                foreach (Worker worker in Workers)
                {
                    result += worker.DailyFee;
                }
                return result;
            }
        }
        public Team()
        {
            Workers = new List<Worker>();
            Name = "";
        }
    }
}
