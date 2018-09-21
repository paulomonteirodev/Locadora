using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paulo.Web.ViewModels
{
    public class LocacaoViewModel : BaseViewModel
    {
        [Display(Name = "Data de Locação")]
        public DateTime DataDaLocacao { get; set; }

        public List<int> SelectedFilmesIds { get; set; }
        public virtual ICollection<FilmeViewModel> Filmes { get; set; }

        public int UsuarioId { get; set; }
        public virtual UsuarioViewModel Usuario { get; set; }
    }
}