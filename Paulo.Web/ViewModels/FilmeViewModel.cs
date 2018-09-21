namespace Paulo.Web.ViewModels
{
    public class FilmeViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public int GeneroId { get; set; }
        public virtual GeneroViewModel Genero { get; set; }
    }
}