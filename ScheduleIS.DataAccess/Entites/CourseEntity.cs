using ScheduleIS.Core.Models;
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
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; } = int.MinValue;
        public bool Status { get; set; } = false;
        public ICollection<ScheduleEntity> Schedules { get; set; }
    }
}
