using ScheduleIS.Core.Models;

namespace ScheduleIS.Core
{
    public interface IScheduleRepository
    {
        Task<Guid> Create(Schedule schedule);
        Task<Guid> Delete(Guid id);
        Task<List<Schedule>> Get();
        Task<List<ScheduleDto>> GetWithNames();
        Task<Guid> Update(Guid id, DateTime Date, Guid TeacherId, Guid CourseId, Guid GroupId, int TimepairId);
    }
}