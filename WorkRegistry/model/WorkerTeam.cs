using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkRegistry.model
{
    class WorkerTeam
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int WorkerId { get; set; }
        [Indexed]
        public int TeamId { get; set; }
    }
}
