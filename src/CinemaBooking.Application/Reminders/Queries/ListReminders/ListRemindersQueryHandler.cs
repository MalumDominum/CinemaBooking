using CinemaBooking.Application.Common.Interfaces;
using CinemaBooking.Domain.Reminders;

using ErrorOr;

using MediatR;

namespace CinemaBooking.Application.Reminders.Queries.ListReminders;

public class ListRemindersQueryHandler(IRemindersRepository _remindersRepository) : IRequestHandler<ListRemindersQuery, ErrorOr<List<Reminder>>>
{
    public async Task<ErrorOr<List<Reminder>>> Handle(ListRemindersQuery request, CancellationToken cancellationToken)
    {
        return await _remindersRepository.ListBySubscriptionIdAsync(request.SubscriptionId, cancellationToken);
    }
}
