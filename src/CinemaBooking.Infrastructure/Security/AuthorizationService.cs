using CinemaBooking.Application.Common.Interfaces;
using CinemaBooking.Application.Common.Security.Request;
using CinemaBooking.Infrastructure.Security.CurrentUserProvider;
using CinemaBooking.Infrastructure.Security.PolicyEnforcer;

using ErrorOr;

namespace CinemaBooking.Infrastructure.Security;

public class AuthorizationService(
    IPolicyEnforcer _policyEnforcer,
    ICurrentUserProvider _currentUserProvider)
        : IAuthorizationService
{
    public ErrorOr<Success> AuthorizeCurrentUser<T>(
        IAuthorizeableRequest<T> request,
        List<string> requiredRoles,
        List<string> requiredPermissions,
        List<string> requiredPolicies)
    {
        var currentUser = _currentUserProvider.GetCurrentUser();

        if (requiredPermissions.Except(currentUser.Permissions).Any())
        {
            return Error.Unauthorized(description: "User is missing required permissions for taking this action");
        }

        if (requiredRoles.Except(currentUser.Roles).Any())
        {
            return Error.Unauthorized(description: "User is missing required roles for taking this action");
        }

        foreach (var policy in requiredPolicies)
        {
            var authorizationAgainstPolicyResult = _policyEnforcer.Authorize(request, currentUser, policy);

            if (authorizationAgainstPolicyResult.IsError)
            {
                return authorizationAgainstPolicyResult.Errors;
            }
        }

        return Result.Success;
    }
}