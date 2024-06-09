using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.Core.Models
{
    public class Subject
    {
        private Subject(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; }
        public string Name { get; }    

        public static Subject Create(Guid id, string name)
        {
            var subject = new Subject(id, name);

            return (subject);
        }
    }
}
