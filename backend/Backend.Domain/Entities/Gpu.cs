namespace Backend.Domain.Entities;

public class Gpu
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; } = null!;
    public int ModelId { get; set; }
    public Model Model { get; set; } = null!;
    public required int Memory { get; set; }
    public bool IsOverclockable { get; set; } = false;
}