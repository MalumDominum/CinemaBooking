using CinemaBooking.Domain.Common;
using CinemaBooking.Domain.Reminders;

namespace CinemaBooking.Domain.Users.Events;

public record ReminderSetEvent(Reminder Reminder) : IDomainEvent;