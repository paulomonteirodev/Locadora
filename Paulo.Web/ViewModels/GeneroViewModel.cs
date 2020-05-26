using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paulo.Web.ViewModels
{
    public class GeneroViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public List<int> idsToDelete { get; set; }
        public virtual ICollection<FilmeViewModel> Filmes { get; set; }
    }
}