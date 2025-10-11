using Backend.Domain.Enums;

namespace Backend.Domain.Entities;

public class Cpu
{
    public int Id { get; init; }
    public int BrandId { get; init; }
    public Brand Brand { get; init; } = null!;
    public int ModelId { get; init; }
    public Model Model { get; init; } = null!;
    public required int Cores { get; init; }
    public required Frequency Frequency { get; init; }
}