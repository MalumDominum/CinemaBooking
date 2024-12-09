using CinemaBooking.Domain.Common;

namespace CinemaBooking.Domain.Users.Events;

public record ReminderDismissedEvent(Guid ReminderId) : IDomainEvent;