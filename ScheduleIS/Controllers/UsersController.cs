using Microsoft.AspNetCore.Mvc;
using ScheduleIS.API.Contracts.Users;
using ScheduleIS.Application.Services;

namespace ScheduleIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            await _userService.Register(request.UserName, request.Email, request.Password);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            var token = await _userService.Login(request.Email, request.Password);
            Response.Cookies.Append("secretCookie", token);
            return Ok(token);
        }
    }
}
