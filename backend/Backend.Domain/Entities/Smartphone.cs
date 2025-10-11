using Backend.Domain.ValueObjects;

namespace Backend.Domain.Entities;

public class Smartphone : ProductBase
{
    public required Memory Storage { get; init; }
    public required Memory Ram { get; init; }
    public required int CameraMegapixels { get; init; }
    public int CommunicationTechnologyId { get; init; }
    public CommunicationTechnology CommunicationTechnology { get; init; } = null!;
    public int DisplayId { get; init; }
    public Display Display { get; init; } = null!;
    public required Battery Battery { get; init; }
}