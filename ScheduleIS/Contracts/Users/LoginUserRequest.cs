using System.ComponentModel.DataAnnotations;

namespace ScheduleIS.API.Contracts.Users
{
    public record LoginUserRequest(
    [Required] string Email,
    [Required] string Password);
}
