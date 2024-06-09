using Microsoft.EntityFrameworkCore;
using ScheduleIS.Core.Models;
using ScheduleIS.Core;
using ScheduleIS.DataAccess.Entites;

namespace ScheduleIS.DataAccess.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {

        private readonly ScheduleISDbContext _context;

        public SubjectRepository(ScheduleISDbContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> Get()
        {
            var subjectEntities = await _context.Subjects
                .AsNoTracking()
                .ToListAsync();

            var subject = subjectEntities
                .Select(b => Subject.Create(
                    b.Id,
                    b.Name))
                .ToList();

            return subject;
        }

        public async Task<Guid> Create(Subject subject)
        {
            var subjectEntity = new SubjectEntity
            {
                Id = subject.Id,
                Name = subject.Name
            };

            await _context.Subjects.AddAsync(subjectEntity);
            await _context.SaveChangesAsync();

            return subjectEntity.Id;
        }

        public async Task<Guid> Update(
            Guid id,
            string name)
        {
            await _context.Subjects
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => name));
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Subjects
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
