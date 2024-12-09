using CinemaBooking.Application.Authentication.Queries.Login;
using CinemaBooking.Domain.Users;

using ErrorOr;

using MediatR;

namespace CinemaBooking.Application.Tokens.Queries.Generate;

public record GenerateTokenQuery(
    Guid? Id,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType,
    List<string> Permissions,
    List<string> Roles) : IRequest<ErrorOr<GenerateTokenResult>>;