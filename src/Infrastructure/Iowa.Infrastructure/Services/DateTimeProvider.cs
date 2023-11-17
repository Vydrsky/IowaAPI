using Iowa.Application.Interfaces.Services;

namespace Iowa.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
}