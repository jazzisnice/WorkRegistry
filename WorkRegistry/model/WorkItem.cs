using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkRegistry.model
{
    /*
     * Stores a day of work done for one Work by one Team
     */
    public class WorkItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Work))]
        public int TaskId { get; set; }

        [ForeignKey(typeof(Team))]
        public int TeamId { get; set; }
    }
}
