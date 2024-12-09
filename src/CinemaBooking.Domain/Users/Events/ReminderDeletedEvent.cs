using CinemaBooking.Domain.Common;

namespace CinemaBooking.Domain.Users.Events;

public record ReminderDeletedEvent(Guid ReminderId) : IDomainEvent;