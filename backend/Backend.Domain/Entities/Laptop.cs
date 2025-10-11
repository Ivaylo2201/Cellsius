using Backend.Domain.ValueObjects;

namespace Backend.Domain.Entities;

public class Laptop : ProductBase
{
    public int GpuId { get; init; }
    public Gpu Gpu { get; init; } = null!;
    public required Memory Storage { get; init; }
    public required Memory Ram { get; init; }
    public int MatrixId { get; init; }
    public Matrix Matrix { get; init; } = null!;
    public required Battery Battery { get; init; }
}