using Microsoft.EntityFrameworkCore;
using ScheduleIS.Core;
using ScheduleIS.Core.Models;
using ScheduleIS.DataAccess.Entites;

namespace ScheduleIS.DataAccess.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ScheduleISDbContext _context;

        public TeacherRepository(ScheduleISDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> Get()
        {
            var teacherEntities = await _context.Teachers
                .AsNoTracking()
                .ToListAsync();

            var teacher = teacherEntities
                .Select(b => Teacher.Create(
                    b.Id,
                    b.Name,
                    b.Phone,
                    b.Email).Teacher)
                .ToList();

            return teacher;
        }

        public async Task<Guid> Create(Teacher teacher)
        {
            var teacherEntity = new TeacherEntity
            {
                Id = teacher.Id,
                Name = teacher.Name,        
                Phone = teacher.Phone,
                Email = teacher.Email,
            };

            await _context.Teachers.AddAsync(teacherEntity);
            await _context.SaveChangesAsync();

            return teacherEntity.Id;
        }

        public async Task<Guid> Update(
            Guid id,
            string name,      
            string phone,
            string email)
        {
            await _context.Teachers
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => name)
                .SetProperty(b => b.Phone, b => phone)
                .SetProperty(b => b.Email, b => email));
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Teachers
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
