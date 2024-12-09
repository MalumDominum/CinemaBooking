using CinemaBooking.Application.Common.Security.Permissions;
using CinemaBooking.Application.Common.Security.Policies;
using CinemaBooking.Application.Common.Security.Request;

using ErrorOr;

namespace CinemaBooking.Application.Reminders.Commands.DismissReminder;

[Authorize(Permissions = Permission.Reminder.Dismiss, Policies = Policy.SelfOrAdmin)]
public record DismissReminderCommand(Guid UserId, Guid SubscriptionId, Guid ReminderId)
    : IAuthorizeableRequest<ErrorOr<Success>>;