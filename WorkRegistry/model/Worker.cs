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
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public int DailyFee { get; set; }
        public String Comment { get; set; }
        public DateTime BirthDate { get; set; }
        public String BirthPlace { get; set; }
        public Boolean Active { get; set; }
        public String PhoneNumber { get; set; }


        [ManyToMany(typeof(WorkerTeam))]
        public List<Team> Teams { get; set; }

        public Worker()
        {
            this.Id = null;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Worker ExaminedWorker = obj as Worker;
            return this.Id == ExaminedWorker.Id;
        }

        public override int GetHashCode()
        {
            return Id == null ? -1 : (int)Id;
        }
    }
}
