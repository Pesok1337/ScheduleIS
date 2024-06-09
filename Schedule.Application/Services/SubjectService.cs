using ScheduleIS.Core.Models;
using ScheduleIS.Core;


namespace ScheduleIS.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<List<Subject>> GetAllSubject()
        {
            return await _subjectRepository.Get();
        }

        public async Task<Guid> CreateSubject(Subject timepair)
        {
            return await _subjectRepository.Create(timepair);
        }

        public async Task<Guid> UpdateSubject(Guid id, string name)
        {
            return await _subjectRepository.Update(id, name);
        }

        public async Task<Guid> DeleteSubject(Guid id)
        {
            return await _subjectRepository.Delete(id);
        }
    }
}
