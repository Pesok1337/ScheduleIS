namespace ScheduleIS.API.Contracts.Schedule
{
    public record ScheduleResponse(
        Guid Id, 
        DateTime Date, 
        Guid TeacherId,
        Guid CourseId,
        Guid GroupId,
        int TimepairId
        );

}