using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkRegistry.model
{
    public class Worker
    {
        public Worker()
        {
            this.Id = null;
        }

        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public int DailyFee { get; set; }
        public String Comment { get; set; }

        [ManyToMany(typeof(WorkerTeam))]
        public List<Team> Teams { get; set; }
    }
}
