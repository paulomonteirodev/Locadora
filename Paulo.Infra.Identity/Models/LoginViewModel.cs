using System.ComponentModel.DataAnnotations;

namespace Paulo.Infra.Identity.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembra Login?")]
        public bool RememberMe { get; set; }
    }
}
