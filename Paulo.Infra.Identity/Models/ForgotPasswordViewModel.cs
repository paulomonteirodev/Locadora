using System.ComponentModel.DataAnnotations;

namespace Paulo.Infra.Identity.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
