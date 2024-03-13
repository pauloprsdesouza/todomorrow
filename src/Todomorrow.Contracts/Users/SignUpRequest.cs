using System.ComponentModel.DataAnnotations;

namespace Todomorrow.Contracts.Users
{
    public class SignUpRequest
    {
        [EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }
    }
}
