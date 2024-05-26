using Microsoft.EntityFrameworkCore;
using ScheduleIS.Core.Models;
using ScheduleIS.DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .Select(b => Schedule.Create(b.Id, b.Name, b.Description, b.Group).Schedule)
                .ToList();

            return schedule;
        }

        public async Task<Guid> Create(Schedule schedule)
        {
            var scheduleEntity = new ScheduleEntity
            {
                Id = schedule.Id,
                //Created = schedule.Created,
                Description = schedule.Description,
                Group = schedule.Group,
                Name = schedule.Name
            };

            await _context.Schedules.AddAsync(scheduleEntity);
            await _context.SaveChangesAsync();

            return scheduleEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string description, string group)
        {
            await _context.Schedules
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.Group, b => group));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Schedules
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
