using SuperReich.Application.Contracts.Persistence;

namespace SuperReich.Infrastructure.Repositories
{
    public class DateTimeChile : IDateTimeChile
    {
        public DateTime GetCurrentChileTime()
        {
            TimeZoneInfo chileTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific SA Standard Time");

            DateTime localTime = DateTime.Now;
            DateTime chileTime = TimeZoneInfo.ConvertTime(localTime, chileTimeZone);

            return DateTime.Parse(chileTime.ToString());
        }

        public DateTime GetSpecificChileTime(DateTime dateTime)
        {
            TimeZoneInfo chileTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific SA Standard Time");
            DateTime chileTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime.ToUniversalTime(), chileTimeZone);

            return DateTime.Parse(chileTime.ToString());
        }
    }
}