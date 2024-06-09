using ScheduleIS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.Core.Abstractions
{
    public interface IUsersRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);

    }
}
