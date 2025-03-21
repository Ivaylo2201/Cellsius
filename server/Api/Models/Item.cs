namespace Api.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required int Quantity { get; set; }

        public int PhoneId { get; set; }
        public required Phone Phone { get; set; }

        public int? CartId { get; set; }
        public Cart? Cart { get; set; }

        public int? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
