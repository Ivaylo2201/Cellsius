using System.ComponentModel.DataAnnotations;

namespace Api.Data_Transfer_Objects
{
    public class LoginUserRequest
    {
        [Required(ErrorMessage = "Email is required.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; set; }
    }
}
