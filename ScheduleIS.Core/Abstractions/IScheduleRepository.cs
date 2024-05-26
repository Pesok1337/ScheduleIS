using ScheduleIS.Core.Models;

namespace ScheduleIS.DataAccess.Repositories
{
    public interface IScheduleRepository
    {
        Task<Guid> Create(Schedule schedule);
        Task<Guid> Delete(Guid id);
        Task<List<Schedule>> Get();
        Task<Guid> Update(Guid id, string description, string group);
    }
}