using System;
using System.ComponentModel.DataAnnotations;

namespace Paulo.Web.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Digite o CPF!")]
        [StringLength(11, ErrorMessage = "O CPF deve conter no máximo 11 caracteres.")]
        public string CPF { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public virtual string Email { get; set; }

        [Display(Name = "Nome do Usuário")]
        public virtual string Name { get; set; }
    }
}