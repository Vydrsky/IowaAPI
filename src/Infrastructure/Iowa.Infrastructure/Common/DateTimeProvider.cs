using Iowa.Application.Common.Interfaces.Services;

namespace Iowa.Infrastructure.Common;

public class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
}