using System.ComponentModel.DataAnnotations;

namespace Paulo.Web.ViewModels
{
    public class FilmeViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public int GeneroId { get; set; }
        public virtual GeneroViewModel Genero { get; set; }
    }
}