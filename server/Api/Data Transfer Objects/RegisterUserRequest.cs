using System.ComponentModel.DataAnnotations;

namespace Api.Data_Transfer_Objects
{
    public class RegisterUserRequest
    {
        [Required(ErrorMessage = "Email is required.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required.")]
        public required string PasswordConfirmation { get; set; }
    }
}
