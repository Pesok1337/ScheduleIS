using ScheduleIS.Core.Models;

namespace ScheduleIS.Core
{
    public interface ITimepairService
    {
        Task<int> CreateTimepair(Timepair timepair);
        Task<int> DeleteTimepair(int id);
        Task<List<Timepair>> GetAllTimepair();
        Task<int> UpdateTimepair(int id, string startPair, string endPair);
    }
}