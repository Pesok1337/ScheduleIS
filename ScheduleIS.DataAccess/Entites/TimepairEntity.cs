using ScheduleIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.DataAccess.Entites
{
    public class TimepairEntity
    {
        public int Id { get; set; }
        public string StartPair { get; set; } = string.Empty;
        public string EndPair { get; set; } = string.Empty;
        public ICollection<ScheduleEntity> Schedules { get; set; }
    }
}
