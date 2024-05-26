using ScheduleIS.DataAccess.Repositories;
using ScheduleIS.Core.Models;

namespace ScheduleIS.Application
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<Schedule>> GetAllSchedule()
        {
            return await _scheduleRepository.Get();
        }

        public async Task<Guid> CreateSchedule(Schedule schedule)
        {
            return await _scheduleRepository.Create(schedule);
        }

        public async Task<Guid> UpdateSchedule(Guid id, string description, string group)
        {
            return await _scheduleRepository.Update(id, description, group);
        }

        public async Task<Guid> DeleteSchedule(Guid id)
        {
            return await _scheduleRepository.Delete(id);
        }
    }
}
