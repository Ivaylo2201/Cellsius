namespace Backend.Domain.Entities;

public class Item
{
    public int Id { get; set; }
    public required int Quantity { get; set; }
    public int PhoneId { get; set; }
    public Phone Phone { get; set; } = null!;
    public int CartId { get; set; }
    public Cart Cart { get; set; } = null!;
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public decimal Price => Phone.Price * Quantity;
}