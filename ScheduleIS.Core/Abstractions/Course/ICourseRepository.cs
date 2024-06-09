using ScheduleIS.Core.Models;

namespace ScheduleIS.Core
{
    public interface ICourseRepository
    {
        Task<Guid> Create(Course curse);
        Task<Guid> Delete(Guid id);
        Task<List<Course>> Get();
        Task<Guid> Update(
            Guid id,
            string name,
            string description,
            int duration,
            bool status);
    }
}