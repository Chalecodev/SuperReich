using SuperReich.Application.Contracts.Persistence;

namespace SuperReich.Infrastructure.Repositories
{
    public class DateTimeChile : IDateTimeChile
    {
        public DateTime GetCurrentChileTime()
        {
            TimeZoneInfo chileTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific SA Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, chileTimeZone);
        }

        public DateTime GetSpecificChileTime(DateTime dateTime)
        {
            TimeZoneInfo chileTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific SA Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime.ToUniversalTime(), chileTimeZone);
        }
    }
}
