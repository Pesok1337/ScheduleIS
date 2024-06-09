using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.Core.Models
{
    public class Schedule
    {
        private Schedule(Guid id,  DateTime date, Guid teacherId, Guid courseId, Guid groupId, int timepairId)
        {
            Id = id; 
            Date = date;
            TeacherId = teacherId;
            CourseId = courseId;
            GroupId = groupId;
            TimepairId = timepairId;    
        }
        

        public Guid Id { get; }
        public DateTime Date { get; }
        public Guid TeacherId { get; }
        public Guid CourseId { get; }
        public Guid GroupId { get; }
        public int TimepairId { get; }

        public static (Schedule Schedule, string Error) Create(Guid id, DateTime date, Guid teacherId, Guid courseId, Guid groupId, int timepairId)
        {
            var error = string.Empty;

            var schedule = new Schedule(id, date, teacherId, courseId, groupId, timepairId);

            return (schedule, error);
        }
        
    }
}
