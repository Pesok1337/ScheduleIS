using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.DataAccess.Entites
{
    public class GroupEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date_start { get; set; } = DateTime.MinValue;
        
        public int Course_id { get; set; } = int.MinValue;
        public int Teacher_id {  get; set; } = int.MinValue;

    }
}
