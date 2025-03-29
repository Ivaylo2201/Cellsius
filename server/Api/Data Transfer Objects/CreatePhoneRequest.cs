using System.ComponentModel.DataAnnotations;

namespace Api.Data_Transfer_Objects
{
    public class CreatePhoneRequest
    {
        [Required(ErrorMessage = "Brand is required.")]
        public required string Brand { get; set; }

        [Required(ErrorMessage = "Model is required.")]
        public required string Model { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        public required string Color { get; set; }

        [Range(1, 5000, ErrorMessage = "Price must be between 1 and 5000.")]
        public required decimal Price { get; set; }

        [Range(4, 1024, ErrorMessage = "Memory must be between 4 and 1024.")]
        public required int Memory { get; set; }

        [Required(ErrorMessage = "Image is required.")]
        public required IFormFile Image { get; set; }
    }
}
