using ScheduleIS.Core.Models;

namespace ScheduleIS.Core
{
    public interface ITeacherService
    {
        Task<Guid> CreateStudent(Teacher student);
        Task<Guid> DeleteStudent(Guid id);
        Task<List<Teacher>> GetAllStudent();
        Task<Guid> UpdateStudent(Guid id, string name, string phone, string email);
    }
}