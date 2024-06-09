using ScheduleIS.Core.Models;

namespace ScheduleIS.Core
{
    public interface ICourseService
    {
        Task<Guid> CreateCourse(Course course);
        Task<Guid> DeleteCourse(Guid id);
        Task<List<Course>> GetAllCourse();
        Task<Guid> UpdateCourse(Guid id, string name, string description, int duration,  bool status);
    }
}