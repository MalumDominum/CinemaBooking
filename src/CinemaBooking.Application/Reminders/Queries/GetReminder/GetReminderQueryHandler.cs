using CinemaBooking.Application.Common.Interfaces;
using CinemaBooking.Domain.Reminders;

using ErrorOr;

using MediatR;

namespace CinemaBooking.Application.Reminders.Queries.GetReminder;

public class GetReminderQueryHandler(IRemindersRepository _remindersRepository)
        : IRequestHandler<GetReminderQuery, ErrorOr<Reminder>>
{
    public async Task<ErrorOr<Reminder>> Handle(GetReminderQuery query, CancellationToken cancellationToken)
    {
        var reminder = await _remindersRepository.GetByIdAsync(query.ReminderId, cancellationToken);

        if (reminder?.UserId != query.UserId)
        {
            return Error.NotFound(description: "Reminder not found");
        }

        return reminder;
    }
}