using System.ComponentModel.DataAnnotations;

namespace ProcessRUsAssessment.RquestResponseDTOs
{
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(16, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 8)]
        public string Password { get; set; }
    }
}
