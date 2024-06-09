using Microsoft.AspNetCore.Mvc;
using ScheduleIS.Core.Models;
using ScheduleIS.Core;
using ScheduleIS.API.Contracts.Student;

namespace ScheduleIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController: ControllerBase
    {
        private readonly ITeacherService _studentService;
        public TeacherController(ITeacherService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet]
        public async Task<ActionResult<List<TeacherResponse>>> GetSchedule()
        {
            var student = await _studentService.GetAllStudent();

            var response = student.Select(b => new TeacherResponse(
                    b.Id,
                    b.Name,
                    b.Phone,
                    b.Email));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateStudent([FromBody] TeacherRequest request)
        {
            var (student, error) = Teacher.Create(
                Guid.NewGuid(),
                request.Name,
                request.Phone,
                request.Email);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var studentId = await _studentService.CreateStudent(student);

            return Ok(studentId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateStudent(Guid id, [FromBody] TeacherRequest request)
        {
            var studentId = await _studentService.UpdateStudent(
                id, 
                request.Name, 
                request.Phone, 
                request.Email);

            return Ok(studentId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteStudent(Guid id)
        {
            return Ok(await _studentService.DeleteStudent(id));
        }
    }
}
