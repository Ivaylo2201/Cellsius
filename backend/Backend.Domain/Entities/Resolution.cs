using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class Resolution
{
    public int Id { get; init; }
    public required int Width { get; init; }
    public required int Height { get; init; }
    public required ResolutionType ResolutionType { get; init; }
}