namespace CinemaBooking.Contracts.Reminders;

public record CreateReminderRequest(string Text, DateTimeOffset DateTime);