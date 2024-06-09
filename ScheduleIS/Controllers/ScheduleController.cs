using Microsoft.AspNetCore.Mvc;
using ScheduleIS.API.Contracts.Schedule;
using ScheduleIS.Core;
using ScheduleIS.Core.Models;

namespace ScheduleIS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController: ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }


        [HttpGet("WithIds")]
        public async Task<ActionResult<List<ScheduleResponse>>> GetSchedule()
        {
            var schedule = await _scheduleService.GetAllSchedule();

            var response = schedule.Select(b => new ScheduleResponse(b.Id, b.Date, b.TeacherId, b.CourseId, b.GroupId, b.TimepairId));

            return Ok(response);
        }
        [HttpGet("WithNames")]
        public async Task<ActionResult<List<ScheduleDtoResponse>>> GetScheduleWithNames()
        {
            var schedule = await _scheduleService.GetAllScheduleWithNames();

            var response = schedule.Select(b => new ScheduleDtoResponse(b.Id, b.Date, b.TeacherName, b.CourseName, b.GroupName, b.TimepairId));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateSchedule([FromBody] ScheduleRequest request)
        {
            var (schedule, error) = Schedule.Create(
                Guid.NewGuid(),
                request.Date, 
                request.TeacherId,
                request.CourseId, 
                request.GroupId, 
                request.TimepairId
            );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var scheduleId = await _scheduleService.CreateSchedule(schedule);

            return Ok(scheduleId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateSchedule(Guid id, [FromBody] ScheduleRequest request)
        {
            var scheduleId = await _scheduleService.UpdateSchedule(id,
                request.Date,
                request.TeacherId,
                request.CourseId,
                request.GroupId,
                request.TimepairId);

            return Ok(scheduleId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteSchedule(Guid id)
        {
            return Ok(await _scheduleService.DeleteSchedule(id));
        }

    }
}
