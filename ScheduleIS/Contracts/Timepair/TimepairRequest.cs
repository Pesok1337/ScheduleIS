namespace ScheduleIS.API.Contracts.Timepair
{
    public record TimepairRequest(
        int id,
        string startPair,
        string endPair);

}
