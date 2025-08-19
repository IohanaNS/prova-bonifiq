public static class TimeZoneUtils
{
    private static readonly TimeZoneInfo BrasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

    public static DateTime ToBrasiliaTime(DateTime utcDate)
    {
        return TimeZoneInfo.ConvertTimeFromUtc(utcDate, BrasiliaTimeZone);
    }
}