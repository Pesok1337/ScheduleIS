using ScheduleIS.Core;
using ScheduleIS.Core.Models;

namespace ScheduleIS.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> GetAllCourse()
        {
            return await _courseRepository.Get();
        }

        public async Task<Guid> CreateCourse(Course course)
        {
            return await _courseRepository.Create(course);
        }

        public async Task<Guid> UpdateCourse(
            Guid id,
            string name,
            string description,
            int duration,
            bool status)
        {
            return await _courseRepository.Update(
                id,
                name,
                description,
                duration,
                status);
        }

        public async Task<Guid> DeleteCourse(Guid id)
        {
            return await _courseRepository.Delete(id);
        }
    }
}
