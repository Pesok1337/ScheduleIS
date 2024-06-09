namespace ScheduleIS.API.Contracts.Course
{
    public record CourseResponse(
        Guid id,
        string name,
        string description,
        int duration,
        bool status);
}
