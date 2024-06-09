using Microsoft.EntityFrameworkCore;
using ScheduleIS.Core.Models;
using ScheduleIS.Core;
using ScheduleIS.DataAccess.Entites;

namespace ScheduleIS.DataAccess.Repositories
{
    public class TimepairRepository : ITimepairRepository
    {
        private readonly ScheduleISDbContext _context;

        public TimepairRepository(ScheduleISDbContext context)
        {
            _context = context;
        }

        public async Task<List<Timepair>> Get()
        {
            var timepairEntities = await _context.Timepairs
                .AsNoTracking()
                .ToListAsync();

            var timepair = timepairEntities
                .Select(b => Timepair.Create(
                    b.Id,
                    b.StartPair,
                    b.EndPair).Timepair)
                .ToList();

            return timepair;
        }

        public async Task<int> Create(Timepair timepair)
        {
            var timepairEntity = new TimepairEntity
            {
                Id = timepair.Id,
                StartPair = timepair.StartPair,
                EndPair = timepair.EndPair
            };

            await _context.Timepairs.AddAsync(timepairEntity);
            await _context.SaveChangesAsync();

            return timepairEntity.Id;
        }

        public async Task<int> Update(
            int id,
            string startPair,
            string endPair)
        {
            await _context.Timepairs
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.StartPair, b => startPair)
                .SetProperty(b => b.EndPair, b => endPair));
            return id;
        }

        public async Task<int> Delete(int id)
        {
            await _context.Timepairs
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
