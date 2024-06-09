

namespace ScheduleIS.Core.Models
{
    public class Course
    {
        public const int MAX_NAME_LENGTH = 15;
        private Course(
            Guid id,
            string name,
            string description,
            int duration,
            bool status)
        {
            Id = id;
            Name = name;
            Description = description;
            Duration = duration;
            Status = status;
        }

    
        public Guid Id { get; }
        public string Name { get;} = string.Empty;
        public string Description { get; } = string.Empty;
        public int Duration { get; } = int.MinValue;
        public bool Status { get; } = false;


        public static (Course Course, string Error) Create(
            Guid id,
            string name,
            string description,
            int duration,
            bool status)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = "Name can not be empty or longer then 15 symbols";
            }

            var course = new Course(id,
            name,
            description,
            duration,
            status);

            return (course, error);
        }
    }
}
