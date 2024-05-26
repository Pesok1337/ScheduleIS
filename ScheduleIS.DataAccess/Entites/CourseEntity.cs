using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.DataAccess.Entites
{
    public class CourseEntity
    {
        public Guid Id { get; set; }
        public string Organization_id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string lessons { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime Date_added { get; set; } = DateTime.MinValue;

        public DateTime Date_updated { get; set;} = DateTime.MinValue;
    }
}
