namespace Api.Models
{
    public class Phone
    {
        public int Id { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int ModelId { get; set; }
        public virtual Model Model { get; set; }

        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        public int Memory { get; set; }

        public decimal Price { get; set; }
        public required string ImagePath { get; set; }

        public List<Item> Items { get; set; } = [];
    }
}
