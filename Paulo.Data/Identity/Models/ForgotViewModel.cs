using System.ComponentModel.DataAnnotations;

namespace Paulo.Data.Identity.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
