using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleIS.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> Login(string email, string password);
        Task Register(string userName, string email, string password);
    }
}
