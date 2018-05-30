using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkRegistry.model
{
    class WorkerWorkItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(WorkItem))]
        public int WorkItemId { get; set; }
        public int CarId { get; set; }
        public int Hours { get; set; }
    }
}
