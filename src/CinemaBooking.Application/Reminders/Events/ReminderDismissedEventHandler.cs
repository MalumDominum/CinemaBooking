using CinemaBooking.Application.Common.Interfaces;
using CinemaBooking.Domain.Users.Events;

using MediatR;

namespace CinemaBooking.Application.Reminders.Events;

public class ReminderDismissedEventHandler(IRemindersRepository _remindersRepository) : INotificationHandler<ReminderDismissedEvent>
{
    public async Task Handle(ReminderDismissedEvent notification, CancellationToken cancellationToken)
    {
        var reminder = await _remindersRepository.GetByIdAsync(notification.ReminderId, cancellationToken)
            ?? throw new InvalidOperationException();

        reminder.Dismiss();

        await _remindersRepository.UpdateAsync(reminder, cancellationToken);
    }
}
