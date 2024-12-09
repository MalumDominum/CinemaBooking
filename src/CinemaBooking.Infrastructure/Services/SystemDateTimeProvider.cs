using CinemaBooking.Application.Common.Interfaces;

namespace CinemaBooking.Infrastructure.Services;

public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
