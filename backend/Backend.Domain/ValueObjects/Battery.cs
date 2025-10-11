using Backend.Domain.Enums;

namespace Backend.Domain.ValueObjects;

public record Battery
{
    public required int Capacity { get; init; }
    public required BatteryType Type { get; init; }
}