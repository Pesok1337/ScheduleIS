using ScheduleIS.Core.Models;

namespace ScheduleIS.Application
{
    public interface IScheduleService
    {
        Task<Guid> CreateSchedule(Schedule schedule);
        Task<Guid> DeleteSchedule(Guid id);
        Task<List<Schedule>> GetAllSchedule();
        Task<Guid> UpdateSchedule(Guid id, string description, string group);
    }
}