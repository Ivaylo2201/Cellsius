namespace Backend.Domain.Entities;

public class Phone
{
    public Guid Id { get; set; }

    public int BrandId { get; set; }
    public Brand? Brand { get; set; }

    public int ModelId { get; set; }
    public Model? Model { get; set; }

    public int ColorId { get; set; }
    public Color? Color { get; set; }

    public required int Memory { get; set; }
    public int DiscountPercentage { get; set; } = 0;
    public required decimal InitialPrice { get; set; }
    public decimal Price { get; set; }
    public required string ImagePath { get; set; }

    public List<Item> Items { get; set; } = [];
}