using System.ComponentModel.DataAnnotations;

namespace Api.Data_Transfer_Objects
{
    public class CreatePhoneRequest
    {
        [Required(ErrorMessage = "BrandId is required.")]
        public required int BrandId { get; set; }

        [Required(ErrorMessage = "ModelId is required.")]
        public required int ModelId { get; set; }

        [Required(ErrorMessage = "ColorId is required.")]
        public required int ColorId { get; set; }

        [Range(1, 5000, ErrorMessage = "Price must be between 1 and 5000.")]
        public required decimal Price { get; set; }

        [Range(4, 1024, ErrorMessage = "Memory must be between 4 and 1024.")]
        public required int Memory { get; set; }

        [Required(ErrorMessage = "Image is required.")]
        public required IFormFile Image { get; set; }
    }
}
