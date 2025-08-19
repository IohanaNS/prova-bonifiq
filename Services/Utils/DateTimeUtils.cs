using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services.Utils;

public class DateTimeUtils : IDateTimeUtils
{
    public DateTime UtcNow => DateTime.UtcNow;
}
