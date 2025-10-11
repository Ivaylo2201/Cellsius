using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class Display
{
    public int Id { get; init; }
    public required DisplayType DisplayType { get; init; }
}