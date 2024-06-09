using Microsoft.EntityFrameworkCore;
using ScheduleIS.Core.Models;
using ScheduleIS.DataAccess.Entites;
using ScheduleIS.Core;


namespace ScheduleIS.DataAccess.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ScheduleISDbContext _context;

        public CourseRepository(ScheduleISDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> Get()
        {
            var curseEntities = await _context.Courses
                .AsNoTracking()
                .ToListAsync();

            var curse = curseEntities
                .Select(b => Course.Create(
                b.Id,
                b.Name,
                b.Description,
                b.Duration,
                b.Status).Course)
                .ToList();

            return curse;
        }

        public async Task<Guid> Create(Course curse)
        {
            var curseEntity = new CourseEntity
            {
                Id = curse.Id,
                Name = curse.Name,
                Description = curse.Description,
                Duration = curse.Duration,
                Status = curse.Status,
            };

            await _context.Courses.AddAsync(curseEntity);
            await _context.SaveChangesAsync();

            return curseEntity.Id;
        }

        public async Task<Guid> Update(
            Guid id,
            string name,
            string description,
            int duration,
            bool status)
        {
            await _context.Courses
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => name)
                .SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.Duration, b => duration)
                .SetProperty(b => b.Status, b => status));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Courses
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
