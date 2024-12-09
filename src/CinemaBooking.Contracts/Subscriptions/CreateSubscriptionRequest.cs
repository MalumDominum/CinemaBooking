using CinemaBooking.Contracts.Common;

namespace CinemaBooking.Contracts.Subscriptions;

public record CreateSubscriptionRequest(
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType);