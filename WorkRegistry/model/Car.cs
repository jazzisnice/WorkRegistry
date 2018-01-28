using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkRegistry.model
{
    public class Car
    {
        [PrimaryKey, AutoIncrement]
        public int? Id
        {
            get; set;
        }
        // TODO should this be an enum??? 
        public String Type { get; set; }
        public String PlateNumber { get; set; }
        public Boolean Active { get; set; }
        public String Comment { get; set; }
    }
}
