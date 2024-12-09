using CinemaBooking.Application.Common.Interfaces;
using CinemaBooking.Domain.Users.Events;

using MediatR;

namespace CinemaBooking.Application.Reminders.Events;

public class ReminderSetEventHandler(IRemindersRepository _remindersRepository) : INotificationHandler<ReminderSetEvent>
{
    public async Task Handle(ReminderSetEvent @event, CancellationToken cancellationToken)
    {
        await _remindersRepository.AddAsync(@event.Reminder, cancellationToken);
    }
}
