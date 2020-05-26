using System.ComponentModel.DataAnnotations;

namespace Paulo.Data.Identity.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[0-9]*", ErrorMessage = "CPF aceita somente números")]
        [MinLength(11, ErrorMessage = "O CPF deve conter no minimo 11 caracteres.")]
        [StringLength(11, ErrorMessage = "O CPF deve conter no máximo 11 caracteres.")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A Senha deve conter pelo menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmPassword { get; set; }
    }
}
