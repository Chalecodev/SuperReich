namespace SuperReich.Application.Contracts.Persistence
{
    public interface IDateTimeChile
    {
        DateTime GetCurrentChileTime();
        DateTime GetSpecificChileTime(DateTime dateTime);
    }
}
