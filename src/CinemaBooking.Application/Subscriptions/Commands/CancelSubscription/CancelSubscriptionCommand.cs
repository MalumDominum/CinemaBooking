using CinemaBooking.Application.Common.Security.Request;
using CinemaBooking.Application.Common.Security.Roles;

using ErrorOr;

namespace CinemaBooking.Application.Subscriptions.Commands.CancelSubscription;

[Authorize(Roles = Role.Admin)]
public record CancelSubscriptionCommand(Guid UserId, Guid SubscriptionId) : IAuthorizeableRequest<ErrorOr<Success>>;