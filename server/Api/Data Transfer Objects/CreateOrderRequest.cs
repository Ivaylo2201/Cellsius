using System.ComponentModel.DataAnnotations;

namespace Api.Data_Transfer_Objects
{
    public class CreateOrderRequest
    {
        [Required(ErrorMessage = "Shipping Id is required.")]
        public int ShippingId { get; set; }
    }
}
