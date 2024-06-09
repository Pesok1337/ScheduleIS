namespace ScheduleIS.API.Contracts.Course
{
    public record CourseRequest(
        string name,
        string description,
        int duration,
        bool status);
    
}
