using Backend.Domain.Enums;

namespace Backend.Domain.ValueObjects;

public record Memory
{
    public required int Capacity { get; init; } // 5 GB
    public required MemoryType Type { get; init; } // DDR5
    public required Frequency Frequency { get; init; } 
}