using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.DataAccess.Entites
{
    public class TeacherEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public ICollection<ScheduleEntity> Schedules { get; set; }
    }
}
