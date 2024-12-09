using System.Text.Json.Serialization;

namespace CinemaBooking.Contracts.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SubscriptionType
{
    Basic,
    Pro,
}