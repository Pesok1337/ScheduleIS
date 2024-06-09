using ScheduleIS.Core.Models;

namespace ScheduleIS.Core
{
    public interface ISubjectService
    {
        Task<Guid> CreateSubject(Subject timepair);
        Task<Guid> DeleteSubject(Guid id);
        Task<List<Subject>> GetAllSubject();
        Task<Guid> UpdateSubject(Guid id, string name);
    }
}