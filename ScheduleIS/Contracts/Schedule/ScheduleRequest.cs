namespace ScheduleIS.API.Contracts.Schedule
{
    public record ScheduleRequest(
        DateTime Date,
        Guid TeacherId,
        Guid CourseId,
        Guid GroupId,
        int TimepairId
        );

}