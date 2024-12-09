using CinemaBooking.Domain.Common;

namespace CinemaBooking.Domain.Users.Events;

public record SubscriptionCanceledEvent(User User, Guid SubscriptionId) : IDomainEvent;