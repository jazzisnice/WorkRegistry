using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkRegistry.model
{
    class WorkerTeam
    {
        [ForeignKey(typeof(Worker))]
        public int WorkerId { get; set; }
        [ForeignKey(typeof(Team))]
        public int TeamId { get; set; }
    }
}
