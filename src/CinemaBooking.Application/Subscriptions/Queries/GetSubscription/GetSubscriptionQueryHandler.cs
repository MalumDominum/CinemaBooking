using CinemaBooking.Application.Common.Interfaces;
using CinemaBooking.Application.Subscriptions.Common;
using CinemaBooking.Domain.Users;

using ErrorOr;

using MediatR;

namespace CinemaBooking.Application.Subscriptions.Queries.GetSubscription;

public class GetSubscriptionQueryHandler(IUsersRepository _usersRepository)
    : IRequestHandler<GetSubscriptionQuery, ErrorOr<SubscriptionResult>>
{
    public async Task<ErrorOr<SubscriptionResult>> Handle(GetSubscriptionQuery request, CancellationToken cancellationToken)
    {
        return await _usersRepository.GetByIdAsync(request.UserId, cancellationToken) is User user
            ? SubscriptionResult.FromUser(user)
            : Error.NotFound(description: "Subscription not found.");
    }
}
