using ScheduleIS.Core.Models;

namespace ScheduleIS.Core
{
    public interface ITimepairRepository
    {
        Task<int> Create(Timepair timepair);
        Task<int> Delete(int id);
        Task<List<Timepair>> Get();
        Task<int> Update(int id, string startPair, string endPair);
    }
}