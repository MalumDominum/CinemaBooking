using CinemaBooking.Application.Common.Security.Permissions;
using CinemaBooking.Application.Common.Security.Policies;
using CinemaBooking.Application.Common.Security.Request;
using CinemaBooking.Application.Subscriptions.Common;
using CinemaBooking.Domain.Users;

using ErrorOr;

namespace CinemaBooking.Application.Subscriptions.Commands.CreateSubscription;

[Authorize(Permissions = Permission.Subscription.Create, Policies = Policy.SelfOrAdmin)]
public record CreateSubscriptionCommand(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType)
    : IAuthorizeableRequest<ErrorOr<SubscriptionResult>>;