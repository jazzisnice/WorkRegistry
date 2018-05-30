using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkRegistry.model
{
    public class Work
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Place { get; set; }
        public String Buyer { get; set; }

        public Work()
        {
            this.StartDate = DateTime.Today;
            this.EndDate = DateTime.Today.AddDays(1);
            this.Id = null;
        }
    }
}
