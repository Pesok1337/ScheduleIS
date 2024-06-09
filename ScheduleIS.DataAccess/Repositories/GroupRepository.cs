using Microsoft.EntityFrameworkCore;
using ScheduleIS.Core;
using ScheduleIS.Core.Models;
using ScheduleIS.DataAccess.Entites;

namespace ScheduleIS.DataAccess.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ScheduleISDbContext _context;

        public GroupRepository(ScheduleISDbContext context)
        {
            _context = context;
        }

        public async Task<List<Group>> Get()
        {
            var groupEntities = await _context.Groups
                .AsNoTracking()
                .ToListAsync();

            var group = groupEntities
                .Select(b => Group.Create(
                    b.Id,
                    b.Name).Group)
                .ToList();

            return group;
        }

        public async Task<Guid> Create(Group group)
        {
            var groupEntity = new GroupEntity
            {
                Id = group.Id,
                Name = group.Name,             
            };

            await _context.Groups.AddAsync(groupEntity);
            await _context.SaveChangesAsync();

            return groupEntity.Id;
        }

        public async Task<Guid> Update(
            Guid id,
            string name)
        {
            await _context.Groups
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => name));
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Groups
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
