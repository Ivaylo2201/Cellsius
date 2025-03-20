using System.ComponentModel.DataAnnotations;

namespace Api.Data_Transfer_Objects
{
    public class CreateOrderRequest
    {
        [Required(ErrorMessage = "Total is required.")]
        public int Total { get; set; }
    }
}
