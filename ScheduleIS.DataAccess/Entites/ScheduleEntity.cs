using ScheduleIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.DataAccess.Entites
{
    public class ScheduleEntity
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid GroupId { get; set; }
        public Guid CourseId { get; set; }
        public int TimepairId { get; set; }
        public Guid TeacherId { get; set; }

        public GroupEntity Group { get; set; }
        public CourseEntity Course { get; set; }
        public TimepairEntity Timepair { get; set; }
        public TeacherEntity Teacher { get; set; }
    }
}
