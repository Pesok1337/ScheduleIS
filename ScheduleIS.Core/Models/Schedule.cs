using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.Core.Models
{
    public class Schedule
    {
        public const int MAX_NAME_LENGTH = 15;
        private Schedule(Guid id, string name, string descriptoin, string group)
        {
            Id = id; 
            Name = name;
            Description = descriptoin;
            //Created = created;
            Group = group;
        }
        

        public Guid Id { get; }
        public string Name { get;} = string.Empty;
        public string Description { get; } = string.Empty;
        //public DateTime Created { get;  }
        public string Group { get;  } = string.Empty;

        public static (Schedule Schedule, string Error) Create(Guid id, string name, string descriptoin, string group)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = "Name can not be empty or longer then 15 symbols";
            }

            var schedule = new Schedule(id, name, descriptoin, group);

            return (schedule, error);
        }
        
    }
}
