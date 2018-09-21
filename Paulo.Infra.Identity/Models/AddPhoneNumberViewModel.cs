using System.ComponentModel.DataAnnotations;

namespace Paulo.Infra.Identity.Models
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Número de Telefone")]
        public string Number { get; set; }
    }
}
