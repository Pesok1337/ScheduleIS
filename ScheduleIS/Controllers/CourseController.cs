using Microsoft.AspNetCore.Mvc;
using ScheduleIS.API.Contracts.Course;
using ScheduleIS.Core;
using ScheduleIS.Core.Models;

namespace ScheduleIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController: ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpGet]
        public async Task<ActionResult<List<CourseResponse>>> GetGroup()
        {
            var course = await _courseService.GetAllCourse();

            var response = course.Select(b => new CourseResponse(b.Id, b.Name, b.Description, b.Duration, b.Status));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCourse([FromBody] CourseRequest request)
        {
            var (course, error) = Course.Create(
                Guid.NewGuid(),
                request.name,
                request.description,
                request.duration,
                request.status
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var courseId = await _courseService.CreateCourse(course);

            return Ok(courseId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateCourse(Guid id, [FromBody] CourseRequest request)
        {
            var courseId = await _courseService.UpdateCourse(
                id, 
                request.name,
                request.description,
                request.duration,
                request.status);

            return Ok(courseId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteCourse(Guid id)
        {
            return Ok(await _courseService.DeleteCourse(id));
        }
    }
}
