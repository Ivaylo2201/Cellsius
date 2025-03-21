using System.ComponentModel.DataAnnotations;

namespace Api.Data_Transfer_Objects
{
    public class RegisterUserRequest
    {
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required.")]
        public string? PasswordConfirmation { get; set; }
    }
}
