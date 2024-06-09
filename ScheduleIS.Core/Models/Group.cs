using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.Core.Models
{
    public class Group
    {
        public const int MAX_NAME_LENGTH = 15;
        private Group(Guid id, string name)
        {
            Id = id;
            Name = name;
        }


        public Guid Id { get; }
        public string Name { get; } = string.Empty;

        public static (Group Group, string Error) Create(Guid id, string name)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
            {
                error = "Name can not be empty or longer then 15 symbols";
            }

            var group = new Group(id, name);

            return (group, error);
        }
    }
}
