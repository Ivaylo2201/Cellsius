namespace Backend.Domain.Entities;

public class ProductBase
{
    public Guid Id { get; init; }
    public int BrandId { get; init; }
    public Brand Brand { get; init; } = null!;
    public int ModelId { get; init; }
    public Model Model { get; init; } = null!;
    public int ColorId { get; init; }
    public Color Color { get; init; } = null!;
    public required string ImagePath { get; init; } = string.Empty;
    public required double InitialPrice { get; init; }
    public int DiscountPercentage { get; init; }
    public required double DisplayDiagonalInInches { get; init; }
    public int ResolutionId { get; init; }
    public Resolution Resolution { get; init; } = null!;
    public int? OsId { get; init; }
    public Os? Os { get; init; }
    public int CpuId { get; init; }
    public Cpu Cpu { get; init; } = null!;
    
    public double Price => InitialPrice * (1 - DiscountPercentage / 100.0);
}