namespace Backend.Domain.Entities;

public class Item
{
    public int Id { get; init; }
    public Guid ProductId { get; init; }
    public ProductBase Product { get; init; } = null!;
    public required int Quantity { get; init; }
    public int? CartId { get; set; }
    public Cart? Cart { get; set; }
    public int? OrderId { get; set; }
    public Order? Order { get; set; }

    public double Price => Product.Price * Quantity;
}