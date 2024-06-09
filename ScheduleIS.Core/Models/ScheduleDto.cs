namespace ScheduleIS.Core.Models
{
    public class ScheduleDto
    {
        public string CourseName { get; set; }
        public DateTime Date { get; set; }
        public string GroupName { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public int TimepairId { get; set; }
    }
}