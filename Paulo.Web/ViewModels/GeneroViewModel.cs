using System.Collections.Generic;

namespace Paulo.Web.ViewModels
{
    public class GeneroViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public List<int> idsToDelete { get; set; }
        public virtual ICollection<FilmeViewModel> Filmes { get; set; }
    }
}