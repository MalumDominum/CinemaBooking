using CinemaBooking.Application.Common.Interfaces;
using CinemaBooking.Application.Subscriptions.Common;
using CinemaBooking.Domain.Subscriptions;
using CinemaBooking.Domain.Users;

using ErrorOr;

using MediatR;

namespace CinemaBooking.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler(
    IUsersRepository _usersRepository) : IRequestHandler<CreateSubscriptionCommand, ErrorOr<SubscriptionResult>>
{
    public async Task<ErrorOr<SubscriptionResult>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        if (await _usersRepository.GetByIdAsync(request.UserId, cancellationToken) is not null)
        {
            return Error.Conflict(description: "User already has an active subscription");
        }

        var subscription = new Subscription(request.SubscriptionType);

        var user = new User(
            request.UserId,
            request.FirstName,
            request.LastName,
            request.Email,
            subscription);

        await _usersRepository.AddAsync(user, cancellationToken);

        return SubscriptionResult.FromUser(user);
    }
}
