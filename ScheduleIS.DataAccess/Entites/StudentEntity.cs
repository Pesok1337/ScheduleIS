using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.DataAccess.Entites
{
    public class StudentEntity
    {
        public Guid Id { get; set; }
        public string Student_code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Gender {  get; set; } = string.Empty;
        public string Dob { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public DateTime Date_added { get; set; } = DateTime.MinValue;
        public DateTime Date_update {  get; set; } = DateTime.MinValue;
        public int Course_id { get; set; } = int.MinValue;
    }
}
