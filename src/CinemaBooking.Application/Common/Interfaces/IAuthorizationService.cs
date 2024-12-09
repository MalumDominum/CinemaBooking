using CinemaBooking.Application.Common.Security.Request;

using ErrorOr;

namespace CinemaBooking.Application.Common.Interfaces;

public interface IAuthorizationService
{
    ErrorOr<Success> AuthorizeCurrentUser<T>(
        IAuthorizeableRequest<T> request,
        List<string> requiredRoles,
        List<string> requiredPermissions,
        List<string> requiredPolicies);
}