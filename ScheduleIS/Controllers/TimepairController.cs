using Microsoft.AspNetCore.Mvc;
using ScheduleIS.API.Contracts.Timepair;
using ScheduleIS.Core;
using ScheduleIS.Core.Models;

namespace ScheduleIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimepairController: ControllerBase
    {
        private readonly ITimepairService _timepairService;
        public TimepairController(ITimepairService timepairService)
        {
            _timepairService = timepairService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TimepairResponse>>> GetGroup()
        {
            var timepair = await _timepairService.GetAllTimepair();

            var response = timepair.Select(b => new TimepairResponse(b.Id, b.StartPair, b.EndPair));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTimepair([FromBody] TimepairRequest request)
        {
            var (timepair, error) = Timepair.Create(
                request.id,
                request.startPair,
                request.endPair);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var timepairId = await _timepairService.CreateTimepair(timepair);

            return Ok(timepairId);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateTimepair(int id, [FromBody] TimepairRequest request)
        {
            var timepairId = await _timepairService.UpdateTimepair(id, request.startPair, request.endPair);

            return Ok(timepairId);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteTimepair(int id)
        {
            return Ok(await _timepairService.DeleteTimepair(id));
        }
    }
}
