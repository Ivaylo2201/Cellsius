using System.ComponentModel.DataAnnotations;

namespace Api.Data_Transfer_Objects
{
    public class UpdateItemQuantityRequest
    {
        [Required(ErrorMessage = "Quantity is required.")]
        public required int Quantity { get; set; }
    }
}
