using System;
using System.ComponentModel.DataAnnotations;

namespace Paulo.Web.ViewModels
{
    public class BaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime DataDeCadastro { get; set; }

        [Display(Name = "Data de Atualização")]
        public DateTime? DataDeAtualizacao { get; set; }
        public bool Deleted { get; set; } = false;
    }
}