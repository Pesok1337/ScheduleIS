using ScheduleIS.Core.Models;

namespace ScheduleIS.Core
{
    public interface ISubjectRepository
    {
        Task<Guid> Create(Subject subject);
        Task<Guid> Delete(Guid id);
        Task<List<Subject>> Get();
        Task<Guid> Update(Guid id, string name);
    }
}