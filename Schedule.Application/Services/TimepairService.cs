using ScheduleIS.Core;
using ScheduleIS.Core.Models;
using System;
namespace ScheduleIS.Application.Services
{
    public class TimepairService : ITimepairService
    {
        private readonly ITimepairRepository _timepairRepository;
        public TimepairService(ITimepairRepository timepairRepository)
        {
            _timepairRepository = timepairRepository;
        }

        public async Task<List<Timepair>> GetAllTimepair()
        {
            return await _timepairRepository.Get();
        }

        public async Task<int> CreateTimepair(Timepair timepair)
        {
            return await _timepairRepository.Create(timepair);
        }

        public async Task<int> UpdateTimepair(int id, string startPair, string endPair)
        {
            return await _timepairRepository.Update(id, startPair, endPair);
        }

        public async Task<int> DeleteTimepair(int id)
        {
            return await _timepairRepository.Delete(id);
        }
    }
}
