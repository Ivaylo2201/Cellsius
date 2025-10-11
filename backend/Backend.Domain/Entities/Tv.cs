namespace Backend.Domain.Entities;

public class Tv : ProductBase
{
    public required int EnergyConsumption { get; init; }
    public required double Weight { get; init; }
    public required int SupportedColorsPercentage { get; init; }
    public int MatrixId { get; init; }
    public Matrix Matrix { get; init; } = null!;
}