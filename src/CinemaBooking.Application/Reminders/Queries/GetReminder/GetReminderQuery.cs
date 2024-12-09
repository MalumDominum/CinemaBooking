using CinemaBooking.Application.Common.Security.Permissions;
using CinemaBooking.Application.Common.Security.Policies;
using CinemaBooking.Application.Common.Security.Request;
using CinemaBooking.Domain.Reminders;

using ErrorOr;

namespace CinemaBooking.Application.Reminders.Queries.GetReminder;

[Authorize(Permissions = Permission.Reminder.Get, Policies = Policy.SelfOrAdmin)]
public record GetReminderQuery(Guid UserId, Guid SubscriptionId, Guid ReminderId) : IAuthorizeableRequest<ErrorOr<Reminder>>;