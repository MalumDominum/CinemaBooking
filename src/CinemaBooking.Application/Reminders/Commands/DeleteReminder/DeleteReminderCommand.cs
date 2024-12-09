using CinemaBooking.Application.Common.Security.Permissions;
using CinemaBooking.Application.Common.Security.Policies;
using CinemaBooking.Application.Common.Security.Request;

using ErrorOr;

namespace CinemaBooking.Application.Reminders.Commands.DeleteReminder;

[Authorize(Permissions = Permission.Reminder.Delete, Policies = Policy.SelfOrAdmin)]
public record DeleteReminderCommand(Guid UserId, Guid SubscriptionId, Guid ReminderId)
    : IAuthorizeableRequest<ErrorOr<Success>>;