namespace ScheduleIS.API.Contracts.Student
{
    public record TeacherResponse(
        Guid Id,
        string Name,    
        string Phone,
        string Email 
        );
    
}
