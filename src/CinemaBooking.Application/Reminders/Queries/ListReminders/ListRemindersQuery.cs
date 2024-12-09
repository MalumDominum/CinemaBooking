using CinemaBooking.Application.Common.Security.Permissions;
using CinemaBooking.Application.Common.Security.Policies;
using CinemaBooking.Application.Common.Security.Request;
using CinemaBooking.Domain.Reminders;

using ErrorOr;

namespace CinemaBooking.Application.Reminders.Queries.ListReminders;

[Authorize(Permissions = Permission.Reminder.Get, Policies = Policy.SelfOrAdmin)]
public record ListRemindersQuery(Guid UserId, Guid SubscriptionId) : IAuthorizeableRequest<ErrorOr<List<Reminder>>>;