using ScheduleIS.Core.Models;
using ScheduleIS.Core;

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

        public async Task<Guid> UpdateSchedule(Guid id, DateTime date, Guid teacherId, Guid courseId, Guid groupId, int timepairId)
        {
            return await _scheduleRepository.Update(id, date, teacherId, courseId, groupId, timepairId);
        }

        public async Task<Guid> DeleteSchedule(Guid id)
        {
            return await _scheduleRepository.Delete(id);
        }

        public async Task<List<ScheduleDto>> GetAllScheduleWithNames()
        {
            return await _scheduleRepository.GetWithNames();
        }
    }
}
