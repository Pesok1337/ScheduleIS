using Microsoft.EntityFrameworkCore;
using ScheduleIS.Core;
using ScheduleIS.Core.Models;
using ScheduleIS.DataAccess.Entites;


namespace ScheduleIS.DataAccess.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleISDbContext _context;

        public ScheduleRepository(ScheduleISDbContext context)
        {
            _context = context;
        }

        public async Task<List<Schedule>> Get()
        {
            var scheduleEntities = await _context.Schedules
                .AsNoTracking()
                .ToListAsync();

            var schedule = scheduleEntities
                .Select(b => Schedule.Create(b.Id, b.Date, b.TeacherId, b.CourseId, b.GroupId, b.TimepairId).Schedule)
                .ToList();

            return schedule;
        }

        public async Task<Guid> Create(Schedule schedule)
        {
            var scheduleEntity = new ScheduleEntity
            {
                Id = schedule.Id,
                Date = schedule.Date,
                GroupId = schedule.GroupId,
                CourseId = schedule.CourseId,
                TimepairId = schedule.TimepairId,
                TeacherId = schedule.TeacherId,
            };

            await _context.Schedules.AddAsync(scheduleEntity);
            await _context.SaveChangesAsync();

            return scheduleEntity.Id;
        }

        public async Task<Guid> Update(Guid id, DateTime date, Guid teacherId, Guid courseId, Guid groupId, int timepairId)
        {
            await _context.Schedules
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Date, b => date)
                .SetProperty(b => b.TeacherId, b => teacherId)
                .SetProperty(b => b.CourseId, b => courseId)
                .SetProperty(b => b.GroupId, b => groupId)
                .SetProperty(b => b.TimepairId, b => timepairId)
                );

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Schedules
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
        public async Task<List<ScheduleDto>> GetWithNames()
        {
            var scheduleEntities = await _context.Schedules
                .AsNoTracking()
                .Include(s => s.Group)
                .Include(s => s.Course)
                .Include(s => s.Teacher)
                .Include(s => s.Timepair)
                .ToListAsync();

            var schedules = scheduleEntities
                .Select(b => new ScheduleDto
                {
                    Id = b.Id,
                    Date = b.Date,
                    TeacherName = b.Teacher.Name,
                    CourseName = b.Course.Name,
                    GroupName = b.Group.Name,
                    TimepairId = b.TimepairId
                }).ToList();

            return schedules;
        }
        
    }
}
