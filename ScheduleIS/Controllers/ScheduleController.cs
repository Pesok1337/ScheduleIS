using Microsoft.AspNetCore.Mvc;
using ScheduleIS.API.Contracts;
using ScheduleIS.Application;
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


        [HttpGet]
        public async Task<ActionResult<List<ScheduleResponse>>> GetSchedule()
        {
            var schedule = await _scheduleService.GetAllSchedule();

            var response = schedule.Select(b => new ScheduleResponse(b.Id, b.Name, b.Description, b.Group));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateSchedule([FromBody] ScheduleRequest request)
        {
            var (schedule, error) = Schedule.Create(
                Guid.NewGuid(),
                request.Group,
                request.Description,
                request.Name);

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
            var scheduleId = await _scheduleService.UpdateSchedule(id, request.Description, request.Group);

            return Ok(scheduleId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteSchedule(Guid id)
        {
            return Ok(await _scheduleService.DeleteSchedule(id));
        }

    }
}
