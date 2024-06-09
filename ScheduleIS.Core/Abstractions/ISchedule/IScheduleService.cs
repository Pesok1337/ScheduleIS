using ScheduleIS.Core.Models;

namespace ScheduleIS.Core
{
    public interface IScheduleService
    {
        Task<Guid> CreateSchedule(Schedule schedule);
        Task<Guid> DeleteSchedule(Guid id);
        Task<List<Schedule>> GetAllSchedule();
        Task<List<ScheduleDto>> GetAllScheduleWithNames();
        Task<Guid> UpdateSchedule(Guid id, DateTime date, Guid teacherId, Guid courseId, Guid groupId, int timepairId);
    }
}