namespace CinemaBooking.Infrastructure.Security.CurrentUserProvider;

public interface ICurrentUserProvider
{
    CurrentUser GetCurrentUser();
}