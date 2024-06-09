namespace ScheduleIS.API.Contracts.Schedule
{
    public record ScheduleDtoResponse(
        Guid Id,
        DateTime Date,
        string TeacherName,
        string CourseName,
        string GroupName,
        int TimepairId
        );
}
