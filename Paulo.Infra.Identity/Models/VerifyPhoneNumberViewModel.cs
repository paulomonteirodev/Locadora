using System.ComponentModel.DataAnnotations;

namespace Paulo.Infra.Identity.Models
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Número de Telefone")]
        public string PhoneNumber { get; set; }
    }
}
