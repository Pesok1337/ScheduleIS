namespace ScheduleIS.API.Contracts
{
    public record ScheduleResponse(
        Guid Id,
        string Name, 
        string Description, 
        //DateTime Created, 
        string Group);

}