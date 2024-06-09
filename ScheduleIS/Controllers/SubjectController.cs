using Microsoft.AspNetCore.Mvc;
using ScheduleIS.Core.Models;
using ScheduleIS.Core;
using ScheduleIS.API.Contracts.Subject;

namespace ScheduleIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController: ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubjectResponse>>> GetGroup()
        {
            var subject = await _subjectService.GetAllSubject();

            var response = subject.Select(b => new SubjectResponse(b.Id, b.Name));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateSubject([FromBody] SubjectRequest request)
        {
            var subject = Subject.Create(
                Guid.NewGuid(),
                request.name);

            var subjectId = await _subjectService.CreateSubject(subject);

            return Ok(subjectId);
        }

        [HttpPut("{id:Guid}")]
        public async Task<ActionResult<int>> UpdateSubject(Guid id, [FromBody] SubjectRequest request)
        {
            var subjectId = await _subjectService.UpdateSubject(id, request.name);

            return Ok(subjectId);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<int>> DeleteSubject(Guid id)
        {
            return Ok(await _subjectService.DeleteSubject(id));
        }
    }
}

