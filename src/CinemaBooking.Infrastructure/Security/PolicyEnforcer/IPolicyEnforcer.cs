using CinemaBooking.Application.Common.Security.Request;
using CinemaBooking.Infrastructure.Security.CurrentUserProvider;

using ErrorOr;

namespace CinemaBooking.Infrastructure.Security.PolicyEnforcer;

public interface IPolicyEnforcer
{
    public ErrorOr<Success> Authorize<T>(
        IAuthorizeableRequest<T> request,
        CurrentUser currentUser,
        string policy);
}