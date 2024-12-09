namespace CinemaBooking.Contracts.Reminders;

public record ReminderResponse(
    Guid Id,
    string Text,
    DateTimeOffset DateTime,
    bool IsDismissed);
