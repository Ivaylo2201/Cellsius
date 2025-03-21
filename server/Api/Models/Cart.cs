namespace Api.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; } = [];

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
