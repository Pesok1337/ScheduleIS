using ScheduleIS.Core.Models;
using ScheduleIS.Core;

namespace ScheduleIS.Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _studentRepository;
        public TeacherService(ITeacherRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Teacher>> GetAllStudent()
        {
            return await _studentRepository.Get();
        }

        public async Task<Guid> CreateStudent(Teacher student)
        {
            return await _studentRepository.Create(student);
        }

        public async Task<Guid> UpdateStudent(Guid id, string name,  string phone, string email)
        {
            return await _studentRepository.Update(id, name, phone, email);
        }

        public async Task<Guid> DeleteStudent(Guid id)
        {
            return await _studentRepository.Delete(id);
        }
    }
}
