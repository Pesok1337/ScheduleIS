using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.Core.Models
{
    public class Teacher
    {
        public const int MAX_NAME_LENGTH = 15;
        private Teacher(Guid id, string name, string phone, string email)
        {
            Id = id;         
            Name = name;
            Phone = phone;
            Email = email;
        }

        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Phone { get; } = string.Empty;
        public string Email { get; } = string.Empty;

        public static (Teacher Teacher, string Error) Create(
            Guid id, 
            string name,  
            string phone, 
            string email)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = "Name can not be empty or longer then 15 symbols";
            }

            var teacher = new Teacher(id, name, phone, email);

            return (teacher, error);
        }

    }
}
