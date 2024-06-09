using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.DataAccess.Entites
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string PasswordHash { get; set; }
        public DateTime LastLogin { get; set; }
        
        public string UserName { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
        public DateTime DateJoined { get; set; }



    }
}
