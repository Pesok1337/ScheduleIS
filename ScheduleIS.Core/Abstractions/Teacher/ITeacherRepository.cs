using ScheduleIS.Core.Models;

namespace ScheduleIS.Core
{
    public interface ITeacherRepository
    {
        Task<Guid> Create(Teacher student);
        Task<Guid> Delete(Guid id);
        Task<List<Teacher>> Get();
        Task<Guid> Update(Guid id, string name, string phone, string email);
    }
}