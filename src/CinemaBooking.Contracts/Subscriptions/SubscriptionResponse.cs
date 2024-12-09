using CinemaBooking.Contracts.Common;

namespace CinemaBooking.Contracts.Subscriptions;

public record SubscriptionResponse(
    Guid Id,
    Guid UserId,
    SubscriptionType SubscriptionType);